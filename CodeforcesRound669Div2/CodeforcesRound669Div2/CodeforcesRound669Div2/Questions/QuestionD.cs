using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound669Div2.Extensions;
using CodeforcesRound669Div2.Questions;

namespace CodeforcesRound669Div2.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var h = inputStream.ReadIntArray();

            var maxes = new SegmentTree<MaxInt>(h.Select(hi => new MaxInt(hi)).ToArray());
            var mins = new SegmentTree<MinInt>(h.Select(hi => new MinInt(hi)).ToArray());
            var counts = new SegmentTree<MinInt>(Enumerable.Repeat(new MinInt().Identity, n).ToArray());

            counts[0] = new MinInt(0);

            for (int i = 1; i < n; i++)
            {
                var left = i - 1;
                if (h[i - 1] > h[i])
                {
                    left = BoundaryBinarySearch(l => mins.Query(l, i).Value > Math.Max(l > 0 ? h[l - 1] : int.MinValue, h[i]), i, -1);
                    if (left > 0 && h[left - 1] == h[i])
                    {
                        left--;
                    }
                }
                else if (h[i - 1] < h[i])
                {
                    left = BoundaryBinarySearch(l => maxes.Query(l, i).Value < Math.Min(l > 0 ? h[l - 1] : int.MaxValue, h[i]), i, -1);
                    if (left > 0 && h[left - 1] == h[i])
                    {
                        left--;
                    }
                }

                if (left < i)
                {
                    counts[i] = new MinInt(counts.Query(left, i).Value + 1);
                }
                else
                {
                    counts[i] = new MinInt(counts.Query(i - 1, i).Value + 1);
                }
            }

            yield return counts[n - 1];
        }

        public static int BoundaryBinarySearch(Predicate<int> predicate, int ok, int ng)
        {
            // めぐる式二分探索
            while (Math.Abs(ok - ng) > 1)
            {
                int mid = (ok + ng) / 2;
                if (predicate(mid))
                {
                    ok = mid;
                }
                else
                {
                    ng = mid;
                }
            }
            return ok;
        }

        struct MinInt : IMonoid<MinInt>
        {
            public int Value { get; }

            public MinInt Identity => new MinInt(int.MaxValue);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MinInt(int value)
            {
                Value = value;
            }

            public override string ToString() => $"{Value}";

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MinInt Multiply(MinInt other) => new MinInt(Math.Min(Value, other.Value));
        }

        struct MaxInt : IMonoid<MaxInt>
        {
            public int Value { get; }

            public MaxInt Identity => new MaxInt(int.MinValue);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MaxInt(int value)
            {
                Value = value;
            }

            public override string ToString() => $"{Value}";

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public MaxInt Multiply(MaxInt other) => new MaxInt(Math.Max(Value, other.Value));
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
