using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound665Div2.Extensions;
using CodeforcesRound665Div2.Questions;
using System.Diagnostics.CodeAnalysis;

namespace CodeforcesRound665Div2.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, m) = inputStream.ReadValue<int, int>();
            var starts = new Coordinate[n];
            var ends = new Coordinate[n];

            long result = 1;
            for (int i = 0; i < n; i++)
            {
                var (y, lx, rx) = inputStream.ReadValue<int, int, int>();
                starts[i] = new Coordinate(lx, y);
                ends[i] = new Coordinate(rx, y);
                if (lx == 0 && rx == 1000000)
                {
                    result++;
                }
            }

            Array.Sort(starts);
            Array.Sort(ends);

            var startQueue = new Queue<Coordinate>(starts);
            var endQueue = new Queue<Coordinate>(ends);

            var bit = new BinaryIndexedTree(1000001);
            bit.AddAt(0, 1);
            bit.AddAt(1000000, 1);


            var verticals = new (int x, int ly, int ry)[m];
            for (int i = 0; i < verticals.Length; i++)
            {
                verticals[i] = inputStream.ReadValue<int, int, int>();
            }

            Array.Sort(verticals, (a, b) => a.x - b.x);

            for (int i = 0; i < verticals.Length; i++)
            {
                var (x, ly, ry) = verticals[i];
                while (startQueue.Count > 0 && startQueue.Peek().X <= x)
                {
                    var horizontal = startQueue.Dequeue();
                    bit.AddAt(horizontal.Y, 1);
                }
                while (endQueue.Count > 0 && endQueue.Peek().X < x)
                {
                    var horizontal = endQueue.Dequeue();
                    bit.AddAt(horizontal.Y, -1);
                }

                result += Math.Max(bit.Sum(ly, ry + 1) - 1, 0);
            }

            yield return result;
        }

        [StructLayout(LayoutKind.Auto)]
        struct Coordinate : IComparable<Coordinate>
        {
            public int X { get; }
            public int Y { get; }

            public Coordinate(int x, int y)
            {
                X = x;
                Y = y;
            }

            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
            public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";

            public int CompareTo(Coordinate other) => X - other.X;
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

            public long this[int index]
            {
                get => Sum(index, index + 1);
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
            public void AddAt(int i, long value)
            {
                unchecked
                {
                    if ((uint)i >= (uint)Length)
                    {
                        throw new ArgumentOutOfRangeException(nameof(i));
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
            public long Sum(int i)
            {
                unchecked
                {
                    if ((uint)i >= (uint)_data.Length)
                    {
                        throw new ArgumentOutOfRangeException(nameof(i));
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
            /// [<c>start</c>, <c>end</c>)の部分和を返します。
            /// </summary>
            /// <param name="start">部分和を求める半開区間の開始インデックス</param>
            /// <param name="end">部分和を求める半開区間の終了インデックス</param>
            /// <returns>区間の部分和</returns>
            public long Sum(int start, int end) => Sum(end) - Sum(start);
        }
    }
}
