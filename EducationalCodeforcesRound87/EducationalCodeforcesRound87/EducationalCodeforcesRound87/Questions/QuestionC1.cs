using EducationalCodeforcesRound87.Questions;
using EducationalCodeforcesRound87.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EducationalCodeforcesRound87.Questions
{
    public class QuestionC1 : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var polygon = 2 * inputStream.ReadInt();
                var angle = Math.PI * (polygon - 2) / polygon;
                yield return Math.Tan(angle / 2);
            }
        }
    }
}
