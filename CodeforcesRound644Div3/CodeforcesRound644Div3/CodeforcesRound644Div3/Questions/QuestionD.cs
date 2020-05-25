using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeforcesRound644Div3.Extensions;
using CodeforcesRound644Div3.Questions;

namespace CodeforcesRound644Div3.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var times = inputStream.ReadInt();
            for (int t = 0; t < times; t++)
            {
                var (n, k) = inputStream.ReadValue<int, int>();
                var max = GetDivisors(n).Where(i => i <= k).Max();
                yield return n / max;
            }
        }

        IEnumerable<int> GetDivisors(int n)
        {
            for (int i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    var other = n / i;
                    yield return i;
                    if (other != i)
                    {
                        yield return other;
                    }
                }
            }
        }
    }
}
