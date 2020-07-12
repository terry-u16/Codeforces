using EducationalCodeforcesRound87.Questions;
using EducationalCodeforcesRound87.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EducationalCodeforcesRound87.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, queries) = inputStream.ReadValue<int, int>();
            var bit = new BinaryIndexedTree(n + 1);

            for (int i = 0; i < n; i++)
            {
                bit[ScanInt(inputStream)]++;
            }

            if (inputStream.Peek() == '\n')
            {
                inputStream.Read();
            }

            for (int i = 0; i < queries; i++)
            {
                var query = ScanInt(inputStream);

                if (query > 0)
                {
                    bit[query]++;
                }
                else if (query < 0)
                {
                    var toRemove = Math.Abs(query);
                    var index = bit.GetLowerBound(toRemove);

                    bit[index]--;
                }
            }

            var result = 0;
            for (int i = 0; i < bit.Length; i++)
            {
                if (bit[i] > 0)
                {
                    result = i;
                    break;
                }
            }
            yield return result;
        }

        int ScanInt(TextReader reader)
        {
            int c;
            int result = 0;
            int sign = 1;

            while ((c = reader.Read()) >= 0)
            {
                if (c >= '0' && c <= '9')
                {
                    result = result * 10 + ((char)c - '0');
                }
                else if (c == '-')
                {
                    sign *= -1;
                }
                else
                {
                    break;
                }
            }

            return sign * result;
        }

        public class BinaryIndexedTree
        {
            int[] _data;
            public int Length { get; }

            public BinaryIndexedTree(int length)
            {
                _data = new int[length + 1];   // 内部的には1-indexedにする
                Length = length;
            }

            public BinaryIndexedTree(IEnumerable<int> data, int length) : this(length)
            {
                var count = 0;
                foreach (var n in data)
                {
                    AddAt(count++, n);
                }
            }

            public BinaryIndexedTree(ICollection<int> collection) : this(collection, collection.Count) { }

            public int this[int index]
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
            public void AddAt(int index, int value)
            {
                unchecked
                {
                    if ((uint)index >= (uint)Length)
                    {
                        throw new ArgumentOutOfRangeException(nameof(index));
                    }
                }

                index++;  // 1-indexedにする

                while (index <= Length)
                {
                    _data[index] += value;
                    index += index & -index;    // LSBの加算
                }
            }

            /// <summary>
            /// [0, <c>end</c>)の部分和を返します。
            /// </summary>
            /// <param name="end">部分和を求める半開区間の終了インデックス</param>
            /// <returns>区間の部分和</returns>
            public int Sum(int end)
            {
                unchecked
                {
                    if ((uint)end >= (uint)_data.Length)
                    {
                        throw new ArgumentOutOfRangeException(nameof(end));
                    }
                }

                int sum = 0;
                while (end > 0)
                {
                    sum += _data[end];
                    end -= end & -end;    // LSBの減算
                }
                return sum;
            }

            /// <summary>
            /// [<c>start</c>, <c>end</c>)の部分和を返します。
            /// </summary>
            /// <param name="start">部分和を求める半開区間の開始インデックス</param>
            /// <param name="end">部分和を求める半開区間の終了インデックス</param>
            /// <returns>区間の部分和</returns>
            public int Sum(int start, int end) => Sum(end) - Sum(start);

            /// <summary>
            /// [0, <c>index</c>)の部分和が<c>sum</c>未満になる最大の<c>index</c>を返します。
            /// BIT上の各要素は0以上の数である必要があります。
            /// </summary>
            /// <param name="sum"></param>
            /// <returns></returns>
            public int GetLowerBound(int sum)
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
            }


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
