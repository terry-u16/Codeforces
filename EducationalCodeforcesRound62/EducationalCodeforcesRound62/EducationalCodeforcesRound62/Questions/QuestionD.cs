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
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var result = 0;

            for (int i = 2; i + 1 <= n; i++)
            {
                result += i * (i + 1);
            }

            yield return result;
        }
    }
}
