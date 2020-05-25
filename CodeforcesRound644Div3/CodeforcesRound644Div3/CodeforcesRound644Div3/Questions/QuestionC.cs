using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeforcesRound644Div3.Extensions;
using CodeforcesRound644Div3.Questions;

namespace CodeforcesRound644Div3.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var a = inputStream.ReadIntArray();
                var evenRemainders = a.Count(i => i % 2 == 0) % 2;
                var oddRemainders = a.Count(i => i % 2 == 1) % 2;
                var remaindersPair = (evenRemainders + oddRemainders) / 2;

                Array.Sort(a);
                var adjacent = 0;
                for (int i = 0; i + 1 < a.Length; i++)
                {
                    if (a[i + 1] - a[i] == 1)
                    {
                        adjacent++;
                    }
                }

                if (remaindersPair - adjacent <= 0)
                {
                    yield return "YES";
                }
                else
                {
                    yield return "NO";
                }
            }
        }
    }
}
