using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeforcesRound645Div._2.Extensions;
using CodeforcesRound645Div._2.Questions;

namespace CodeforcesRound645Div._2.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (n, m) = inputStream.ReadValue<int, int>();
                if (n % 2 == 0 || m % 2 == 0)
                {
                    yield return n * m / 2;
                }
                else
                {
                    yield return n * m / 2 + 1;
                }
            }
        }
    }
}
