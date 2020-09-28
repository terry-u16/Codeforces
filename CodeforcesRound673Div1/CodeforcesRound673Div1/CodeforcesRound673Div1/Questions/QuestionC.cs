using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound673Div1.Questions;

namespace CodeforcesRound673Div1.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var a = io.ReadIntArray(n);

            var inversions = CountInversions(a, 0);
            var bestX = 0;

            for (int i = 0; i <= 30; i++)
            {
                var x = bestX | (1 << i);
                var currentInversions = CountInversions(a, x);

                if (currentInversions < inversions)
                {
                    bestX = x;
                    inversions = currentInversions;
                }
            }

            io.WriteLine($"{inversions} {bestX}");
        }

        long CountInversions(int[] a, int x)
        {
            var b = a.Select(ai => ai ^ x).ToArray();
            var shrinker = new CoordinateShrinker(b);

            var bit = new BinaryIndexedTree(shrinker.Count);

            long result = 0;

            foreach (var bi in b)
            {
                var c = shrinker.Shrink(bi);
                result += bit.Sum(c + 1, bit.Length);
                bit.AddAt(c, 1);
            }

            return result;
        }

        public class CoordinateShrinker
        {
            Dictionary<int, int> _shrinkMapper;
            int[] _expandMapper;
            public int Count => _expandMapper.Length;

            public CoordinateShrinker(int[] data)
            {
                _expandMapper = data;
                Array.Sort(_expandMapper);

                _shrinkMapper = new Dictionary<int, int>();
                var i = 0;
                var last = -1;

                foreach (var item in _expandMapper)
                {
                    if (last != item)
                    {
                        _shrinkMapper.Add(item, i++);
                        last = item;
                    }
                }
            }

            public int Shrink(int rawCoordinate) => _shrinkMapper[rawCoordinate];
            public int Expand(int shrinkedCoordinate) => _expandMapper[shrinkedCoordinate];
        }


        public class BinaryIndexedTree
        {
            long[] _data;
            public int Length { get; }

            public BinaryIndexedTree(int length)
            {
                _data = new long[length + 1];   // 内部的には1-indexedにする
                Length = length;
            }

            public BinaryIndexedTree(IEnumerable<long> data, int length) : this(length)
            {
                var count = 0;
                foreach (var n in data)
                {
                    AddAt(count++, n);
                }
            }

            public BinaryIndexedTree(ICollection<long> collection) : this(collection, collection.Count) { }

            public long this[Index index]
            {
                get => Sum(index..(index.GetOffset(Length) + 1));
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)}は0以上の値である必要があります。");
                    }
                    AddAt(index, value - this[index]);
                }
            }

            /// <summary>
            /// BITの<c>index</c>番目の要素に<c>n</c>を加算します。
            /// </summary>
            /// <param name="index">加算するインデックス（0-indexed）</param>
            /// <param name="value">加算する数</param>
            public void AddAt(Index index, long value)
            {
                var i = index.GetOffset(Length);
                unchecked
                {
                    if ((uint)i >= (uint)Length)
                    {
                        throw new ArgumentOutOfRangeException(nameof(index));
                    }
                }

                i++;  // 1-indexedにする

                while (i <= Length)
                {
                    _data[i] += value;
                    i += i & -i;    // LSBの加算
                }
            }

            /// <summary>
            /// [0, <c>end</c>)の部分和を返します。
            /// </summary>
            /// <param name="end">部分和を求める半開区間の終了インデックス</param>
            /// <returns>区間の部分和</returns>
            public long Sum(Index end)
            {
                var i = end.GetOffset(Length);  // 0-indexedの半開区間＝1-indexedの閉区間なので+1は不要
                unchecked
                {
                    if ((uint)i >= (uint)_data.Length)
                    {
                        throw new ArgumentOutOfRangeException(nameof(end));
                    }
                }

                long sum = 0;
                while (i > 0)
                {
                    sum += _data[i];
                    i -= i & -i;    // LSBの減算
                }
                return sum;
            }

            /// <summary>
            /// <c>range</c>の部分和を返します。
            /// </summary>
            /// <param name="range">部分和を求める半開区間</param>
            /// <returns>区間の部分和</returns>
            public long Sum(Range range) => Sum(range.End) - Sum(range.Start);

            /// <summary>
            /// [<c>start</c>, <c>end</c>)の部分和を返します。
            /// </summary>
            /// <param name="start">部分和を求める半開区間の開始インデックス</param>
            /// <param name="end">部分和を求める半開区間の終了インデックス</param>
            /// <returns>区間の部分和</returns>
            public long Sum(int start, int end) => Sum(end) - Sum(start);

            /// <summary>
            /// [0, <c>index</c>)の部分和が<c>sum</c>未満になる最大の<c>index</c>を返します。
            /// BIT上の各要素は0以上の数である必要があります。
            /// </summary>
            /// <param name="sum"></param>
            /// <returns></returns>
            public int GetLowerBound(long sum)
            {
                int index = 0;
                for (int offset = GetMostSignificantBitOf(Length); offset > 0; offset >>= 1)
                {
                    if (index + offset < _data.Length && _data[index + offset] < sum)
                    {
                        index += offset;
                        sum -= _data[index];
                    }
                }

                return index;

                int GetMostSignificantBitOf(int n)
                {
                    int k = 1;
                    while ((k << 1) <= n)
                    {
                        k <<= 1;
                    };
                    return k;
                }
            }
        }

    }

    static class UtilExtensions
    {
        public static void ChangeMax<T>(ref this T a, T b) where T : struct, IComparable<T>
        {
            if (a.CompareTo(b) < 0)
            {
                a = b;
            }
        }

        public static void ChangeMin<T>(ref this T a, T b) where T : struct, IComparable<T>
        {
            if (a.CompareTo(b) > 0)
            {
                a = b;
            }
        }
    }
}
