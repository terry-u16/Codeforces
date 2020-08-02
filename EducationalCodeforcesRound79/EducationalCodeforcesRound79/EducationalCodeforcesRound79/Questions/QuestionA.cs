using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound79.Extensions;
using EducationalCodeforcesRound79.Questions;

namespace EducationalCodeforcesRound79.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var counts = inputStream.ReadIntArray();
                Array.Sort(counts);
                yield return counts[0] + counts[1] + 1 >= counts[2] ? "Yes" : "No";
            }
        }
    }
}
