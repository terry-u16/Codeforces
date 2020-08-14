using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound93.Extensions;
using EducationalCodeforcesRound93.Questions;

namespace EducationalCodeforcesRound93.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        const int Colors = 3;
        int[][] lengths;
        int[,,] memo;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (r, g, b) = inputStream.ReadValue<int, int, int>();
            lengths = new int[Colors][];
            memo = new int[r + 1, g + 1, b + 1];

            for (int i = 0; i < Colors; i++)
            {
                lengths[i] = inputStream.ReadIntArray();
                Array.Sort(lengths[i], (x, y) => y - x);
            }

            yield return Dfs(0, 0, 0);
        }

        int Dfs(int r, int g, int b)
        {
            if (End(lengths, r, g, b))
            {
                return 0;
            }
            else if (memo[r, g, b] != 0)
            {
                return memo[r, g, b];
            }
            else
            {
                var max = 0;
                if (lengths[0].Length > r && lengths[1].Length > g)
                {
                    max = Math.Max(max, Dfs(r + 1, g + 1, b) + lengths[0][r] * lengths[1][g]);
                }
                if (lengths[0].Length > r && lengths[2].Length > b)
                {
                    max = Math.Max(max, Dfs(r + 1, g, b + 1) + lengths[0][r] * lengths[2][b]);
                }
                if (lengths[1].Length > g && lengths[2].Length > b)
                {
                    max = Math.Max(max, Dfs(r, g + 1, b + 1) + lengths[1][g] * lengths[2][b]);
                }
                return memo[r, g, b] = max;
            }
        }

        bool End(int[][] lengths, int r, int g, int b)
        {
            var endCount = 0;
            if (lengths[0].Length == r)
            {
                endCount++;
            }
            if (lengths[1].Length == g)
            {
                endCount++;
            }
            if (lengths[2].Length == b)
            {
                endCount++;
            }
            return endCount >= 2;
        }
    }
}
