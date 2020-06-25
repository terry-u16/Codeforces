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
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (a, b, c) = inputStream.ReadValue<long, long, long>();
                long first, second;
                if (a >= c)
                {
                    first = -1;
                    second = b;
                }
                else if (a * b <= c)
                {
                    first = 1;
                    second = -1;
                }
                else
                {
                    first = 1;
                    second = b;
                }

                yield return $"{first} {second}";
            }
        }
    }
}
