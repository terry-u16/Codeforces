using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound62.Extensions;
using EducationalCodeforcesRound62.Questions;

namespace EducationalCodeforcesRound62.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                _ = inputStream.ReadInt();
                var s = inputStream.ReadLine();

                var min = int.MaxValue;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '>')
                    {
                        min = Math.Min(min, i);
                    }
                }

                for (int i = s.Length - 1; i >= 0; i--)
                {
                    if (s[i] == '<')
                    {
                        min = Math.Min(min, s.Length - i - 1);
                    }
                }

                yield return min;
            }
        }
    }
}
