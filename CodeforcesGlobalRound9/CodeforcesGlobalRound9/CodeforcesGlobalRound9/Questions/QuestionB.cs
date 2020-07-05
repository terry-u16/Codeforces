using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesGlobalRound9.Extensions;
using CodeforcesGlobalRound9.Questions;

namespace CodeforcesGlobalRound9.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (text, matrix) = SolveOnce(inputStream);
                yield return text;
                if (matrix != null)
                {
                    for (int row = 0; row < matrix.Length; row++)
                    {
                        yield return string.Join(" ", matrix[row]);
                    }
                }
            }
        }

        private (string answer, int[][] matrix) SolveOnce(TextReader inputStream)
        {
            var (height, width) = inputStream.ReadValue<int, int>();
            var a = new int[height][];
            for (int row = 0; row < height; row++)
            {
                a[row] = inputStream.ReadIntArray();
            }

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    var isTopBottomEdge = row == 0 || row == height - 1;
                    var isSideEdge = column == 0 || column == width - 1;
                    if (isTopBottomEdge && isSideEdge)
                    {
                        if (a[row][column] > 2)
                        {
                            return ("NO", null);
                        }
                        else
                        {
                            a[row][column] = 2;
                        }
                    }
                    else if (isTopBottomEdge || isSideEdge)
                    {
                        if (a[row][column] > 3)
                        {
                            return ("NO", null);
                        }
                        else
                        {
                            a[row][column] = 3;
                        }
                    }
                    else
                    {
                        if (a[row][column] > 4)
                        {
                            return ("NO", null);
                        }
                        else
                        {
                            a[row][column] = 4;
                        }
                    }
                }
            }

            return ("YES", a);
        }
    }
}
