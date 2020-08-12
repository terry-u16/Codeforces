using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound89.Extensions;
using EducationalCodeforcesRound89.Questions;

namespace EducationalCodeforcesRound89.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var primes = Eratosthenes(a.Max());

            var results = Enumerable.Repeat(0, 2).Select(_ => Enumerable.Repeat(-1, n).ToArray()).ToArray();

            for (int i = 0; i < a.Length; i++)
            {
                var factorized = PrimeFactorize(a[i], primes).ToArray();
                if (factorized.Length >= 2)
                {
                    results[0][i] = factorized[0];
                    results[1][i] = 1;
                    for (int j = 1; j < factorized.Length; j++)
                    {
                        results[1][i] *= factorized[j];
                    }
                }
            }

            for (int i = 0; i < results.Length; i++)
            {
                yield return results[i].Join(" ");
            }
        }

        public static long Gcd(long a, long b)
        {
            if (a < b)
            {
                (a, b) = (b, a);
            }

            if (b > 0)
            {
                return Gcd(b, a % b);
            }
            else if (b == 0)
            {
                return a;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"{nameof(a)}, {nameof(b)}は0以上の整数である必要があります。");
            }
        }

        IEnumerable<int> PrimeFactorize(int n, List<int> primes)
        {
            foreach (var prime in primes)
            {
                if (prime * prime > n)
                {
                    break;
                }

                if (n % prime == 0)
                {
                    yield return prime;
                    while (n % prime == 0)
                    {
                        n /= prime;
                    }
                }
            }

            if (n > 1)
            {
                yield return n;
            }
        }

        List<int> Eratosthenes(int max)
        {
            var isPrime = Enumerable.Repeat(true, max + 1).ToArray();
            isPrime[0] = false;
            isPrime[1] = false;

            for (int p = 2; p < isPrime.Length; p++)
            {
                if (isPrime[p])
                {
                    for (int mul = p * 2; mul <= max; mul += p)
                    {
                        isPrime[mul] = false;
                    }
                }
            }

            var results = new List<int>();
            for (int i = 0; i < isPrime.Length; i++)
            {
                if (isPrime[i])
                {
                    results.Add(i);
                }
            }

            return results;
        }
    }
}
