using EducationalCodeforcesRound87.Questions;
using EducationalCodeforcesRound87.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EducationalCodeforcesRound87.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var s = inputStream.ReadLine();

                var counts = new int[s.Length + 1, 3];

                for (int i = 0; i < s.Length; i++)
                {
                    var c = s[i] - '1';
                    counts[i + 1, c] = 1;
                }

                for (int i = 0; i < s.Length; i++)
                {
                    for (int number = 0; number < 3; number++)
                    {
                        counts[i + 1, number] += counts[i, number];
                    }
                }

                var min = int.MaxValue;
                var right = 0;
                for (int left = 0; left < counts.GetLength(0); left++)
                {
                    while (right < counts.GetLength(0) - 1 && !Check(counts, left, right))
                    {
                        right++;
                    }

                    if (!Check(counts, left, right))
                    {
                        break;
                    }

                    min = Math.Min(right - left, min);

                    if (right == left)
                    {
                        right++;
                    }
                }

                yield return min != int.MaxValue ? min : 0;
            }
        }

        bool Check(int[,] counts, int left, int right)
        {
            var included = new int[3];
            for (int i = 0; i < included.Length; i++)
            {
                included[i] = counts[right, i] - counts[left, i];
            }

            return included.All(i => i > 0);
        }
    }
}
