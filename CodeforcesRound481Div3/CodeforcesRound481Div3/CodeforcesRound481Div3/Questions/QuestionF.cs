using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound481Div3.Questions;
using System.Diagnostics.CodeAnalysis;

namespace CodeforcesRound481Div3.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var programmerCount = io.ReadInt();
            var quarrelCount = io.ReadInt();
            var quarrels = Enumerable.Repeat(0, programmerCount).Select(_ => new List<int>()).ToArray();
            var programmers = new Programmer[programmerCount];
            var skills = new int[programmerCount];

            for (int i = 0; i < programmers.Length; i++)
            {
                var r = io.ReadInt();
                programmers[i] = new Programmer(r, i);
                skills[i] = r;
            }

            for (int i = 0; i < quarrelCount; i++)
            {
                var x = io.ReadInt() - 1;
                var y = io.ReadInt() - 1;
                quarrels[x].Add(y);
                quarrels[y].Add(x);
            }

            Array.Sort(programmers);
            var results = new long[programmers.Length];
            var appeared = new HashSet<int>();
            var shrinker = new CoordinateShrinker<int>(programmers.Select(p => p.Skill));
            var bit = new BinaryIndexedTree(shrinker.Count);

            foreach (var programmer in programmers)
            {
                results[programmer.ID] = bit.Sum(shrinker.Shrink(programmer.Skill));
                foreach (var q in quarrels[programmer.ID])
                {
                    if (appeared.Contains(q) && skills[q] < programmer.Skill)
                    {
                        results[programmer.ID]--;
                    }
                }
                appeared.Add(programmer.ID);
                bit.AddAt(shrinker.Shrink(programmer.Skill), 1);
            }

            io.WriteLine(results, ' ');
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Programmer : IComparable<Programmer>
        {
            public int Skill { get; }
            public int ID { get; }

            public Programmer(int skill, int id)
            {
                Skill = skill;
                ID = id;
            }

            public void Deconstruct(out int skill, out int id) => (skill, id) = (Skill, ID);
            public override string ToString() => $"{nameof(Skill)}: {Skill}, {nameof(ID)}: {ID}";

            public int CompareTo([AllowNull] Programmer other) => Skill - other.Skill;
        }

        public class CoordinateShrinker<T> : IEnumerable<(int shrinkedIndex, T rawIndex)> where T : IComparable<T>, IEquatable<T>
        {
            Dictionary<T, int> _shrinkMapper;
            T[] _expandMapper;
            public int Count => _expandMapper.Length;

            public CoordinateShrinker(IEnumerable<T> data)
            {
                _expandMapper = data.Distinct().ToArray();
                Array.Sort(_expandMapper);

                _shrinkMapper = new Dictionary<T, int>();
                for (int i = 0; i < _expandMapper.Length; i++)
                {
                    _shrinkMapper.Add(_expandMapper[i], i);
                }
            }

            public int Shrink(T rawCoordinate) => _shrinkMapper[rawCoordinate];
            public T Expand(int shrinkedCoordinate) => _expandMapper[shrinkedCoordinate];

            public IEnumerator<(int shrinkedIndex, T rawIndex)> GetEnumerator()
            {
                for (int i = 0; i < _expandMapper.Length; i++)
                {
                    yield return (i, _expandMapper[i]);
                }
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
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
}
