using CodeforcesRound641Div2.Questions;
using CodeforcesRound641Div2.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeforcesRound641Div2.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var times = inputStream.ReadInt();
            for (int t = 0; t < times; t++)
            {
                var (n, k) = inputStream.ReadValue<long, long>();

                if (n % 2 == 0)
                {
                    yield return n + 2 * k;
                }
                else
                {
                    n += GetMinimumDivisior(n);
                    yield return n + 2 * (k - 1);
                }
            }
        }

        private long GetMinimumDivisior(long n)
        {
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    return i;
                }
            }
            return n;
        }
    }
}
