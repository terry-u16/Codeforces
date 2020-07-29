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
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (l, r) = inputStream.ReadValue<int, int>();
                if (r < l * 2)
                {
                    yield return "-1 -1";
                }
                else
                {
                    yield return $"{l} {2 * l}";
                }
            }
        }
    }
}
