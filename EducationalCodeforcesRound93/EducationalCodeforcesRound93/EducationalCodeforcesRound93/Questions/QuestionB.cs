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
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var s = inputStream.ReadLine();
                var ones = new List<int>();

                var streak = 0;

                foreach (var c in s)
                {
                    if (c == '1')
                    {
                        streak++;
                    }
                    else
                    {
                        ones.Add(streak);
                        streak = 0;
                    }
                }

                ones.Add(streak);

                ones.Sort((a, b) => b - a);
                var result = 0;
                for (int i = 0; i < ones.Count; i += 2)
                {
                    result += ones[i];
                }

                yield return result;
            }
        }
    }
}
