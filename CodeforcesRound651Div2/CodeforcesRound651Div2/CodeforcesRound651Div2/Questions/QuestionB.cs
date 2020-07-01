using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeforcesRound651Div2.Extensions;
using CodeforcesRound651Div2.Questions;

namespace CodeforcesRound651Div2.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var a = inputStream.ReadIntArray();

                var odds = new Queue<int>();
                var evens = new Queue<int>();

                for (int i = 0; i < a.Length; i++)
                {
                    var index = i + 1;
                    if (a[i] % 2 == 0)
                    {
                        evens.Enqueue(index);
                    }
                    else
                    {
                        odds.Enqueue(index);
                    }
                }

                for (int i = 0; i < n - 1; i++)
                {
                    if (evens.Count >= 2)
                    {
                        var c = evens.Dequeue();
                        var d = evens.Dequeue();
                        yield return $"{c} {d}";
                    }
                    else
                    {
                        var c = odds.Dequeue();
                        var d = odds.Dequeue();
                        yield return $"{c} {d}";
                    }
                }
            }
        }
    }
}
