using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeforcesRound645Div._2.Extensions;
using CodeforcesRound645Div._2.Questions;

namespace CodeforcesRound645Div._2.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                _ = inputStream.ReadInt();
                var grannies = inputStream.ReadIntArray();
                Array.Sort(grannies);
                var show = 1;
                for (int i = 0; i < grannies.Length; i++)
                {
                    if (i + 1 >= grannies[i])
                    {
                        show = i + 2;
                    }
                }
                yield return show;
            }
        }
    }
}
