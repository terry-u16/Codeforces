using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeforcesRound644Div3.Extensions;
using CodeforcesRound644Div3.Questions;

namespace CodeforcesRound644Div3.Questions
{
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (n, m, a, b) = inputStream.ReadValue<int, int, int, int>();
                int[][] matrix;

                if (TryComposeMatrix(n, m, a, b, out matrix))
                {
                    yield return "YES";
                    for (int row = 0; row < n; row++)
                    {
                        yield return string.Concat(matrix[row]);
                    }
                }
                else
                {
                    yield return "NO";
                }
            }
        }

        bool TryComposeMatrix(int n, int m, int a, int b, out int[][] result)
        {
            result = Enumerable.Repeat(0, n).Select(_ => new int[m]).ToArray();

            var column = 0;
            for (int row = 0; row < n; row++)
            {
                for (int i = 0; i < a; i++)
                {
                    result[row][column++ % m] = 1;
                }
            }

            for (int col = 0; col < m; col++)
            {
                var count = 0;
                for (int row = 0; row < n; row++)
                {
                    count += result[row][col];
                }

                if (count != b)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
