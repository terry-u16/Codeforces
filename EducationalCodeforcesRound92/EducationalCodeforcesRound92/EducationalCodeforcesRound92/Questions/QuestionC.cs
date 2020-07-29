using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound92.Extensions;
using EducationalCodeforcesRound92.Questions;

namespace EducationalCodeforcesRound92.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var s = inputStream.ReadLine();
                var min = int.MaxValue;

                for (int i = 0; i < 100; i++)
                {
                    var num = i.ToString("00");
                    var counted = 0;
                    var erased = 0;
                    foreach (var c in s)
                    {
                        if (c != num[counted & 1])
                        {
                            erased++;
                        }
                        else
                        {
                            counted++;
                        }
                    }
                    if ((counted & 1) == 1)
                    {
                        erased++;
                    }
                    min = Math.Min(min, erased);
                }

                for (char i = '0'; i <= '9'; i++)
                {
                    min = Math.Min(min, s.Count(c => c != i));
                }

                yield return min;
            }
        }
    }
}
