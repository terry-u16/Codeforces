using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesGlobalRound9.Extensions;
using CodeforcesGlobalRound9.Questions;

namespace CodeforcesGlobalRound9.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var a = inputStream.ReadIntArray();
                var operations = new Queue<int>();

                var counts = new SegmentTree<NumberAndCount>(Construct(a));

                var last = -1;
                for (int i = 0; i < a.Length; i++)
                {
                    while (true)
                    {
                        var pair = counts.Query(0, n);
                        if (pair.Count == 0 && a[pair.Number] != pair.Number)
                        {
                            operations.Enqueue(Update(a, counts, pair.Number));
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (last + 1 == a[i])
                    {
                        last = a[i];
                        continue;
                    }
                    else
                    {
                        var target = last + 1;

                        var currentPair = counts.Query(0, counts.Length);
                        var currentMex = currentPair.Number;

                        if (currentMex != target)
                        {
                            for (int j = i + 1; j < a.Length; j++)
                            {
                                if (a[j] == target)
                                {
                                    operations.Enqueue(Update(a, counts, j));
                                }
                            }
                        }

                        operations.Enqueue(Update(a, counts, i));
                        last = target;
                    }
                }

                yield return operations.Count;
                yield return string.Join(" ", operations.Select(op => op + 1));
            }
        }

        private int Update(int[] a, SegmentTree<NumberAndCount> counts, int i)
        {
            var nextPair = counts.Query(0, counts.Length);
            var nextMex = nextPair.Number;       // Count must be zero.

            counts[nextMex] = new NumberAndCount(nextMex, 1);
            counts[a[i]] = new NumberAndCount(a[i], counts[a[i]].Count - 1);
            a[i] = nextMex;
            return i;
        }

        NumberAndCount[] Construct(int[] a)
        {
            var numberAndCount = Enumerable.Range(0, a.Length + 1).Select(i => new NumberAndCount(i, 0)).ToArray();
            foreach (var ai in a)
            {
                numberAndCount[ai] = new NumberAndCount(ai, numberAndCount[ai].Count + 1);
            }
            return numberAndCount;
        }

        [StructLayout(LayoutKind.Auto)]
        struct NumberAndCount : IMonoid<NumberAndCount>
        {
            public int Number { get; }
            public int Count { get; }

            public NumberAndCount Identity => new NumberAndCount(-1, int.MaxValue);

            public NumberAndCount(int number, int count)
            {
                Number = number;
                Count = count;
            }

            public void Deconstruct(out int number, out int count) => (number, count) = (Number, Count);
            public override string ToString() => $"{nameof(Number)}: {Number}, {nameof(Count)}: {Count}";

            public NumberAndCount Multiply(NumberAndCount other)
            {
                if (Count < other.Count)
                {
                    return this;
                }
                else if (Count > other.Count)
                {
                    return other;
                }
                else
                {
                    if (Number < other.Number)
                    {
                        return this;
                    }
                    else
                    {
                        return other;
                    }
                }
            }
        }

        public interface ISemigroup<TSet> where TSet : ISemigroup<TSet>
        {
            TSet Multiply(TSet other);
        }

        public interface IMonoid<TSet> : ISemigroup<TSet> where TSet : IMonoid<TSet>, new()
        {
            TSet Identity { get; }
        }

        public class SegmentTree<TMonoid> : IEnumerable<TMonoid> where TMonoid : IMonoid<TMonoid>, new()
        {
            private readonly TMonoid[] _data;
            private readonly TMonoid _identityElement;

            private readonly int _leafOffset;   // n - 1
            private readonly int _leafLength;   // n (= 2^k)

            public int Length { get; }          // 実データ長

            public SegmentTree(ICollection<TMonoid> data)
            {
                Length = data.Count;
                _leafLength = GetMinimumPow2(data.Count);
                _leafOffset = _leafLength - 1;
                _data = new TMonoid[_leafOffset + _leafLength];
                _identityElement = new TMonoid().Identity;

                data.CopyTo(_data, _leafOffset);
                BuildTree();
            }

            public TMonoid this[int index]
            {
                get => _data[_leafOffset + index];
                set
                {
                    if (index < 0 || index >= Length)
                    {
                        throw new IndexOutOfRangeException($"{nameof(index)}がデータの範囲外です。");
                    }
                    index += _leafOffset;
                    _data[index] = value;
                    while (index > 0)
                    {
                        // 一つ上の親の更新
                        index = (index - 1) / 2;
                        _data[index] = _data[index * 2 + 1].Multiply(_data[index * 2 + 2]);
                    }
                }
            }

            public TMonoid Query(int begin, int end)
            {
                if (begin < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(begin), $"{nameof(begin)}は0以上の数でなければなりません。");
                }
                if (end > Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(end), $"{nameof(end)}は{nameof(Length)}以下でなければなりません。");
                }
                if (begin >= end)
                {
                    throw new ArgumentException($"{nameof(begin)},{nameof(end)}", $"{nameof(end)}は{nameof(begin)}より大きい数でなければなりません。");
                }
                return Query(begin, end, 0, 0, _leafLength);
            }

            private TMonoid Query(int begin, int end, int index, int left, int right)
            {
                if (right <= begin || end <= left)      // 範囲外
                {
                    return _identityElement;
                }
                else if (begin <= left && right <= end) // 全部含まれる
                {
                    return _data[index];
                }
                else    // 一部だけ含まれる
                {
                    var leftValue = Query(begin, end, index * 2 + 1, left, (left + right) / 2);     // 左の子
                    var rightValue = Query(begin, end, index * 2 + 2, (left + right) / 2, right);   // 右の子
                    return leftValue.Multiply(rightValue);
                }
            }

            private void BuildTree()
            {

                for (int i = _leafOffset + Length; i < _data.Length; i++)
                {
                    _data[i] = _identityElement;  // 単位元埋め
                }

                for (int i = _leafLength - 2; i >= 0; i--)  // 葉の親から順番に一つずつ上がっていく
                {
                    _data[i] = _data[2 * i + 1].Multiply(_data[2 * i + 2]); // f(left, right)
                }
            }

            private int GetMinimumPow2(int n)
            {
                var p = 1;
                while (p < n)
                {
                    p *= 2;
                }
                return p;
            }

            public IEnumerator<TMonoid> GetEnumerator()
            {
                var upperIndex = _leafOffset + Length;
                for (int i = _leafOffset; i < upperIndex; i++)
                {
                    yield return _data[i];
                }
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        }

    }
}
