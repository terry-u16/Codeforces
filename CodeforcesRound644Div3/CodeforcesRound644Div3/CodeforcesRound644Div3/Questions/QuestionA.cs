using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeforcesRound644Div3.Extensions;
using CodeforcesRound644Div3.Questions;

namespace CodeforcesRound644Div3.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                var min = Math.Min(a, b);
                var max = Math.Max(a, b);
                var length = Math.Max(2 * min, max);
                yield return length * length;
            }
        }
    }
}
