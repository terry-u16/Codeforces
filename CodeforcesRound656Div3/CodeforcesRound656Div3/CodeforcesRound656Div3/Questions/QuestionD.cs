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
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var s = inputStream.ReadLine();
                var k = GetK(n);
                var counts = new int[k + 1][];
                for (int i = 0; i < k; i++)
                {
                    counts[i] = new int[1 << (i + 1)];
                }

                counts[k] = new int[n];

                for (int i = 0; i < s.Length; i++)
                {
                    var c = s[i] - 'a';
                    if (c <= k)
                    {
                        var pow = (c != k) ? i >> (k - c - 1) : i;
                        counts[c][pow]++;
                    }
                }

                yield return Dfs(counts, 0, k, 0, n - 1);
            }
        }

        int Dfs(int[][] counts, int c, int k, int start, int end)
        {
            if (c == k)
            {
                return 1 - counts[c][start];
            }
            else
            {
                var length = end - start + 1;
                var halfLength = length / 2;
                var beginHalf = (halfLength - counts[c][start >> (k - c - 1)]) + Dfs(counts, c + 1, k, start + halfLength, end);
                var endHalf = (halfLength - counts[c][(start + halfLength) >> (k - c - 1)]) + Dfs(counts, c + 1, k, start, end - halfLength);
                return Math.Min(beginHalf, endHalf);
            }
        }

        int GetK(int n)
        {
            var k = 0;
            while (n > 1)
            {
                k++;
                n >>= 1;
            }
            return k;
        }
    }
}
