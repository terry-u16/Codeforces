using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesGlobalRound10.Extensions;
using CodeforcesGlobalRound10.Questions;

namespace CodeforcesGlobalRound10.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        const int Left = 0;
        const int Right = 1;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                _ = inputStream.ReadInt();
                var directions = inputStream.ReadLine().Select(c => c == 'L' ? Direction.L : Direction.R).ToArray();

                var result = int.MaxValue;
                UpdateWhenSmall(ref result, GetResult(directions, Direction.L, Direction.L));
                UpdateWhenSmall(ref result, GetResult(directions, Direction.L, Direction.R));
                UpdateWhenSmall(ref result, GetResult(directions, Direction.R, Direction.L));
                UpdateWhenSmall(ref result, GetResult(directions, Direction.R, Direction.R));

                yield return result;
            }
        }

        int GetResult(Direction[] directions, Direction first, Direction second)
        {
            const int Inf = 1 << 28;
            var changedFirst = directions[0] != first;

            var dp = new int[directions.Length + 3, Right + 1, Right + 1];
            for (int i = 0; i < directions.Length + 3; i++)
            {
                for (int j = 0; j <= Right; j++)
                {
                    for (int k = 0; k <= Right; k++)
                    {
                        dp[i, j, k] = Inf;
                    }
                }
            }

            dp[2, (int)first, (int)second] = 0;

            for (int i = 2; i < directions.Length + 2; i++)
            {
                var cursor = i % directions.Length;
                UpdateWhenSmall(ref dp[i + 1, (int)Direction.L, (int)Direction.L], dp[i, (int)Direction.R, (int)Direction.L] + ChangeCost(directions[cursor], Direction.L));

                UpdateWhenSmall(ref dp[i + 1, (int)Direction.L, (int)Direction.R], dp[i, (int)Direction.R, (int)Direction.L] + ChangeCost(directions[cursor], Direction.R));
                UpdateWhenSmall(ref dp[i + 1, (int)Direction.L, (int)Direction.R], dp[i, (int)Direction.L, (int)Direction.L] + ChangeCost(directions[cursor], Direction.R));

                UpdateWhenSmall(ref dp[i + 1, (int)Direction.R, (int)Direction.L], dp[i, (int)Direction.L, (int)Direction.R] + ChangeCost(directions[cursor], Direction.L));
                UpdateWhenSmall(ref dp[i + 1, (int)Direction.R, (int)Direction.L], dp[i, (int)Direction.R, (int)Direction.R] + ChangeCost(directions[cursor], Direction.L));

                UpdateWhenSmall(ref dp[i + 1, (int)Direction.R, (int)Direction.R], dp[i, (int)Direction.L, (int)Direction.R] + ChangeCost(directions[cursor], Direction.R));
            }

            return dp[directions.Length + 2, (int)first, (int)second];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int ChangeCost(Direction toChange, Direction init) => toChange == init ? 0 : 1;

        enum Direction
        {
            L,
            R
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UpdateWhenSmall<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) < 0)
            {
                value = other;
            }
        }
    }
}
