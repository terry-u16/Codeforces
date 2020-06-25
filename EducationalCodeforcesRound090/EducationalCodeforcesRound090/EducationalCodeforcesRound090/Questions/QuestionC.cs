using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound090.Extensions;
using EducationalCodeforcesRound090.Questions;

namespace EducationalCodeforcesRound090.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var s = inputStream.ReadLine();
                var scores = new int[s.Length + 2];

                for (int i = 0; i < s.Length; i++)
                {
                    scores[i + 1] = scores[i] + (s[i] == '+' ? 1 : -1);
                }

                for (int i = 0; i < s.Length; i++)
                {
                    scores[i + 1] = Math.Min(scores[i], scores[i + 1]);
                }

                scores[scores.Length - 1] = int.MinValue;

                long sum = 0;
                var min = 0;
                for (int i = 0; i < scores.Length; i++)
                {
                    if (scores[i] < min)
                    {
                        sum += i;
                        min = scores[i];
                    }
                }

                yield return sum - 1;
            }
        }
    }
}
