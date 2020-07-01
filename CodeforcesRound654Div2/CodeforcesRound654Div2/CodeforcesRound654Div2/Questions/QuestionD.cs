using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound654Div2.Extensions;
using CodeforcesRound654Div2.Questions;

namespace CodeforcesRound654Div2.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (n, k) = inputStream.ReadValue<int, int>();
                var matrix = new int[n][];
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i] = new int[n];
                }

                if (k % n == 0)
                {
                    yield return 0;
                }
                else
                {
                    yield return 2;
                }

                var column = 0;
                var div = k / n;
                var mod = k % n;
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int j = 0; j < div; j++)
                    {
                        matrix[row][column++ % n] = 1;
                    }
                    if (row < mod)
                    {
                        matrix[row][column++ % n] = 1;
                    }
                }

                for (int row = 0; row < matrix.Length; row++)
                {
                    yield return string.Concat(matrix[row]);
                }
            }
        }
    }
}
