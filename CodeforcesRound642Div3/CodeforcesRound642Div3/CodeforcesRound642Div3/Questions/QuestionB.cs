using CodeforcesRound642Div3.Questions;
using CodeforcesRound642Div3.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeforcesRound642Div3.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var times = inputStream.ReadInt();
            for (int t = 0; t < times; t++)
            {
                var (_, k) = inputStream.ReadValue<int, int>();
                var a = inputStream.ReadIntArray();
                var b = inputStream.ReadIntArray();

                Array.Sort(a);
                Array.Sort(b);
                Array.Reverse(b);

                for (int i = 0; i < k; i++)
                {
                    if (a[i] < b[i])
                    {
                        a[i] = b[i];
                    }
                }

                yield return a.Sum();
            }
        }
    }
}
