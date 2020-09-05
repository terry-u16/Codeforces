using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound667.Extensions;
using CodeforcesRound667.Questions;

namespace CodeforcesRound667.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        char t1, t2;
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, limit) = inputStream.ReadValue<int, int>();
            var s = inputStream.ReadLine();
            var t = inputStream.ReadLine();
            t1 = t[0];
            t2 = t[1];

            if (t1 == t2)
            {
                var count = Math.Min(s.Count(c => c == t1) + limit, s.Length);
                yield return count * (count - 1) / 2;
                yield break;
            }

            var dp = new int[s.Length + 1, limit + 1, s.Length + 1];
            for (int i = 0; i < s.Length + 1; i++)
            {
                for (int j = 0; j < limit + 1; j++)
                {
                    for (int k = 0; k < s.Length + 1; k++)
                    {
                        dp[i, j, k] = int.MinValue;
                    }
                }
            }

            dp[0, 0, 0] = 0;

            for (int i = 0; i < s.Length; i++)
            {
                for (int op = 0; op <= limit; op++)
                {
                    for (int appeared = 0; appeared < s.Length; appeared++)
                    {
                        // 何もしない
                        if (s[i] == t1)
                        {
                            UpdateWhenLarge(ref dp[i + 1, op, appeared + 1], dp[i, op, appeared]);
                        }
                        else if (s[i] == t2)
                        {
                            UpdateWhenLarge(ref dp[i + 1, op, appeared], dp[i, op, appeared] + appeared);
                        }
                        else
                        {
                            UpdateWhenLarge(ref dp[i + 1, op, appeared], dp[i, op, appeared]);
                        }

                        if (s[i] != t1 && op < limit)
                        {
                            // t1に変える
                            UpdateWhenLarge(ref dp[i + 1, op + 1, appeared + 1], dp[i, op, appeared]);
                        }
                        if (s[i] != t2 && op < limit)
                        {
                            // t2に変える
                            UpdateWhenLarge(ref dp[i + 1, op + 1, appeared], dp[i, op, appeared] + appeared);
                        }
                    }
                }
            }

            var max = 0;
            for (int op = 0; op <= limit; op++)
            {
                for (int appeared = 0; appeared < s.Length; appeared++)
                {
                    UpdateWhenLarge(ref max, dp[s.Length, op, appeared]);
                }
            }
            yield return max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UpdateWhenLarge<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) > 0)
            {
                value = other;
            }
        }
    }
}
