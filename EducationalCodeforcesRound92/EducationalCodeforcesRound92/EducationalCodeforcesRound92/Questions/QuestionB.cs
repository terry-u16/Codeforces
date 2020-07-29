using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound92.Extensions;
using EducationalCodeforcesRound92.Questions;

namespace EducationalCodeforcesRound92.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (n, k, z) = inputStream.ReadValue<int, int, int>();
                var a = inputStream.ReadIntArray();
                var dp = new int[n, z + 1, 2];
                dp[0, 0, 0] = a[0];

                for (int reversed = 0; reversed <= z; reversed++)
                {
                    for (int recentryBacked = 0; recentryBacked < 2; recentryBacked++)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            if (i + 1 < n)
                            {
                                UpdateWhenLarge(ref dp[i + 1, reversed, 0], dp[i, reversed, 0] + a[i + 1]);
                                UpdateWhenLarge(ref dp[i + 1, reversed, 0], dp[i, reversed, 1] + a[i + 1]);
                            }

                            if (recentryBacked == 0 && reversed < z && i - 1 >= 0)
                            {
                                UpdateWhenLarge(ref dp[i - 1, reversed + 1, 1], dp[i, reversed, 0] + a[i - 1]);
                            }
                        }
                    }
                }

                var max = 0;
                for (int reversed = 0; reversed <= z; reversed++)
                {
                    for (int recentryBacked = 0; recentryBacked < 2; recentryBacked++)
                    {
                        var x = k - 2 * reversed;
                        if (x >= 0)
                        {
                            UpdateWhenLarge(ref max, dp[x, reversed, 0]);
                            UpdateWhenLarge(ref max, dp[x, reversed, 1]);
                        }
                    }
                }

                yield return max;
            }
        }

        public static void UpdateWhenLarge<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) > 0)
            {
                value = other;
            }
        }
    }
}
