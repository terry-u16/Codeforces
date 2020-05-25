using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeforcesRound644Div3.Extensions;
using CodeforcesRound644Div3.Questions;

namespace CodeforcesRound644Div3.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var result = new int[n + 1][];
                for (int row = 0; row < n; row++)
                {
                    result[row] = inputStream.ReadLine().Select(c => c - '0').Concat(Enumerable.Repeat(1, 1)).ToArray();
                }
                result[n] = Enumerable.Repeat(1, n + 1).ToArray();

                yield return Check(result) ? "YES" : "NO";
            }
        }

        bool Check(int[][] result)
        {
            var n = result.Length - 1;
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    if (result[row][column] == 1 && result[row + 1][column] == 0 && result[row][column + 1] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
