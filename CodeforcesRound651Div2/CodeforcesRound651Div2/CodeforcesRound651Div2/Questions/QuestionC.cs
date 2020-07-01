using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeforcesRound651Div2.Extensions;
using CodeforcesRound651Div2.Questions;

namespace CodeforcesRound651Div2.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const string ashishgup = "Ashishgup";
            const string fastestFinger = "FastestFinger";

            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();

                if (n == 1)
                {
                    yield return fastestFinger;
                }
                else if (n == 2)
                {
                    yield return ashishgup;
                }
                else if (n % 2 == 1)
                {
                    yield return ashishgup;
                }
                else
                {
                    var primes = PrimeFactorize(n).ToArray();
                    var oddCount = primes.Count(p => p % 2 == 1);
                    var evenCount = primes.Length - oddCount;   // 2^k (k > 0)

                    if (oddCount == 0)
                    {
                        yield return fastestFinger;
                    }
                    else if (evenCount >= 2)
                    {
                        yield return ashishgup;
                    }
                    else if (oddCount >= 2)
                    {
                        yield return ashishgup;
                    }
                    else
                    {
                        yield return fastestFinger;
                    }
                }
            }
        }

        IEnumerable<int> PrimeFactorize(int n)
        {
            for (int div = 2; div * div <= n; div++)
            {
                while (n % div == 0)
                {
                    n /= div;
                    yield return div;
                }
            }

            if (n > 1)
            {
                yield return n;
            }
        }
    }
}
