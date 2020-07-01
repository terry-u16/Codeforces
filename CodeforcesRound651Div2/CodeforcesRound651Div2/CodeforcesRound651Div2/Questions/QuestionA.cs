using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeforcesRound651Div2.Extensions;
using CodeforcesRound651Div2.Questions;

namespace CodeforcesRound651Div2.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                yield return n / 2;
            }
        }
    }
}
