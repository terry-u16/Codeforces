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
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var s = inputStream.ReadLine();
                var zeros = s.Count(c => c == '0');
                var ones = s.Count(c => c == '1');
                yield return Math.Min(zeros, ones) % 2 == 0 ? "NET" : "DA";
            }
        }
    }
}
