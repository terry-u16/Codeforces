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
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (m, d, w) = inputStream.ReadValue<long, long, long>();
                var diff = (w * 100000000000L - d) % w;

            }
        }
    }
}
