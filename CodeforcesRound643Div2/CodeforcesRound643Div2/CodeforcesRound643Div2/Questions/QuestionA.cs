using CodeforcesRound643Div2.Questions;
using CodeforcesRound643Div2.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeforcesRound643Div2.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (a, k) = inputStream.ReadValue<long, long>();

                for (long i = 2; i <= k; i++)
                {
                    var (min, max) = GetMinAndMaxDigit(a);
                    var mul = min * max;
                    if (mul == 0)
                    {
                        break;
                    }
                    a += mul;
                }

                yield return a;
            }
        }

        (long minDigit, long maxDigit) GetMinAndMaxDigit(long n)
        {
            long minDigit = 9;
            long maxDigit = 0;

            while (n > 0)
            {
                var digit = n % 10;
                minDigit = Math.Min(minDigit, digit);
                maxDigit = Math.Max(maxDigit, digit);
                n /= 10;
            }

            return (minDigit, maxDigit);
        }
    }
}
