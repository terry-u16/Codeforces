using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound89.Extensions;
using EducationalCodeforcesRound89.Questions;

namespace EducationalCodeforcesRound89.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (height, width) = inputStream.ReadValue<int, int>();
                var map = new bool[height][];
                for (int i = 0; i < map.Length; i++)
                {
                    map[i] = inputStream.ReadIntArray().Select(j => j == 1).ToArray();
                }

                var pathLength = width + height - 2;
                var total = 0;
                for (int shift = 0; shift < (pathLength + 1) / 2; shift++)
                {
                    var zeros = 0;
                    var ones = 0;

                    for (int row = 0; row < height; row++)
                    {
                        for (int column = 0; column < width; column++)
                        {
                            if (row + column == shift || (pathLength - row - column) == shift)
                            {
                                if (map[row][column])
                                {
                                    ones++;
                                }
                                else
                                {
                                    zeros++;
                                }
                            }
                        }
                    }

                    total += Math.Min(zeros, ones);
                }

                yield return total;
            }
        }
    }
}
