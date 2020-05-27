using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeforcesRound645Div._2.Extensions;
using CodeforcesRound645Div._2.Questions;

namespace CodeforcesRound645Div._2.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var times = inputStream.ReadInt();

            for (int t = 0; t < times; t++)
            {
                var (x1, y1, x2, y2) = inputStream.ReadValue<long, long, long, long>();
                yield return (x2 - x1) * (y2 - y1) + 1;
            }
        }
    }
}
