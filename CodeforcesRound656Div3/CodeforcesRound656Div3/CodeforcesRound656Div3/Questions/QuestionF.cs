using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound656Div3.Extensions;
using CodeforcesRound656Div3.Questions;

namespace CodeforcesRound656Div3.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (n, k) = inputStream.ReadValue<int, int>();
                var tree = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
                var leafsCount = new SegmentTree<MaxInt>(Enumerable.Range(0, n).Select(i => new MaxInt(i, 0)).ToArray());
                var isLeaf = new bool[n];
                var removedCounts = new int[n];

                for (int i = 0; i < n - 1; i++)
                {
                    var (a, b) = inputStream.ReadValue<int, int>();
                    a--;
                    b--;
                    tree[a].Add(b);
                    tree[b].Add(a);
                }

                if (k == 1)
                {
                    yield return n - 1;
                    continue;
                }

                for (int i = 0; i < tree.Length; i++)
                {
                    if (tree[i].Count == 1)
                    {
                        var c = leafsCount[tree[i][0]];
                        leafsCount[tree[i][0]] = new MaxInt(c.Index, c.Value + 1);
                        isLeaf[i] = true;
                    }
                }

                var answer = 0;

                while (true)
                {
                    var max = leafsCount.Query(0, n);
                    if (max.Value < k)
                    {
                        break;
                    }
                    answer++;
                    var index = max.Index;
                    var c = leafsCount[index];
                    removedCounts[index] += k;
                    var newCount = c.Value - k;
                    leafsCount[index] = new MaxInt(index, newCount);
                    if (removedCounts[index] == tree[index].Count - 1)
                    {
                        isLeaf[index] = true;
                        for (int i = 0; i < tree[index].Count; i++)
                        {
                            var parent = tree[index][i];
                            if (!isLeaf[parent])
                            {
                                var c2 = leafsCount[parent];
                                leafsCount[parent] = new MaxInt(c2.Index, c2.Value + 1);
                                break;
                            }
                        }
                    }
                }

                yield return answer;
            }
        }

        struct MaxInt : IMonoid<MaxInt>
        {
            public MaxInt Identity => new MaxInt(-1, int.MinValue);

            public int Index { get; }
            public int Value { get; }

            public MaxInt(int index, int value)
            {
                Index = index;
                Value = value;
            }

            public MaxInt Multiply(MaxInt other) => Value >= other.Value ? this : other;
            public override string ToString() => $"Value:{Value}";
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
                get
                {
                    if (index < 0 || index >= Length)
                    {
                        throw new IndexOutOfRangeException($"{nameof(index)}がデータの範囲外です。");
                    }
                    return _data[_leafOffset + index];
                }
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
                    _data[i] = _identityElement;
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
