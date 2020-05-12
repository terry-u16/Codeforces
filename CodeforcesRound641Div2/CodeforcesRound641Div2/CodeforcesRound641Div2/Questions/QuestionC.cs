using CodeforcesRound641Div2.Questions;
using CodeforcesRound641Div2.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeforcesRound641Div2.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        List<int> _primes;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _primes = GetPrimes(200000);

            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var primes = a.Select(PrimeFactorization).ToArray();

            var gcdFromLeft = new Dictionary<int, int>[primes.Length];
            var gcdFromRight = new Dictionary<int, int>[primes.Length];

            gcdFromLeft[0] = new Dictionary<int, int>(primes[0]);
            for (int i = 1; i < primes.Length; i++)
            {
                gcdFromLeft[i] = GetGcd(gcdFromLeft[i - 1], primes[i]);
            }

            gcdFromRight[gcdFromRight.Length - 1] = new Dictionary<int, int>(primes[primes.Length - 1]);
            for (int i = primes.Length - 2; i >= 0; i--)
            {
                gcdFromRight[i] = GetGcd(gcdFromRight[i + 1], primes[i]);
            }

            var excludedGcd = new Dictionary<int, int>[primes.Length];
            excludedGcd[0] = new Dictionary<int, int>(gcdFromRight[1]);
            for (int i = 1; i < primes.Length - 1; i++)
            {
                excludedGcd[i] = GetGcd(gcdFromLeft[i - 1], gcdFromRight[i + 1]);
            }
            excludedGcd[excludedGcd.Length - 1] = new Dictionary<int, int>(gcdFromLeft[gcdFromLeft.Length - 2]);

            var lcm = new Dictionary<int, int>[excludedGcd.Length];
            for (int i = 0; i < lcm.Length; i++)
            {
                lcm[i] = GetLcm(primes[i], excludedGcd[i]);
            }

            var overallGcd = lcm[0];
            for (int i = 1; i < lcm.Length; i++)
            {
                overallGcd = GetGcd(overallGcd, lcm[i]);
            }

            long answer = 1;
            foreach (var pair in overallGcd)
            {
                var prime = pair.Key;
                var count = pair.Value;

                for (int i = 0; i < count; i++)
                {
                    answer *= prime;
                }
            }

            yield return answer;
        }

        private static Dictionary<int, int> GetLcm(Dictionary<int, int> primes1, Dictionary<int, int> primes2)
        {
            var lcm = new Dictionary<int, int>(primes1);
            foreach (var pair in primes2)
            {
                var prime = pair.Key;
                var count = pair.Value;
                if (lcm.ContainsKey(prime))
                {
                    lcm[prime] = Math.Max(lcm[prime], count);
                }
                else
                {
                    lcm[prime] = count;
                }
            }
            return lcm;
        }

        private static Dictionary<int, int> GetGcd(Dictionary<int, int> primes1, Dictionary<int, int> primes2)
        {
            var gcd = new Dictionary<int, int>();
            foreach (var pair in primes2)
            {
                var prime = pair.Key;
                var count = pair.Value;
                if (primes1.ContainsKey(prime))
                {
                    gcd[prime] = Math.Min(primes1[prime], count);
                }
            }
            return gcd;
        }


        Dictionary<int, int> PrimeFactorization(int n)
        {
            var dictionary = new Dictionary<int, int>();
            foreach (var prime in _primes.TakeWhile(i => i * i <= n))
            {
                while (n % prime == 0)
                {
                    if (dictionary.ContainsKey(prime))
                    {
                        dictionary[prime]++;
                    }
                    else
                    {
                        dictionary[prime] = 1;
                    }

                    n /= prime;
                }
            }

            if (n > 1)
            {
                dictionary[n] = 1;
            }

            return dictionary;
        }

        List<int> GetPrimes(int max)
        {
            var primes = new List<int>();
            var notPrime = new bool[max + 1];

            for (int i = 2; i * i <= max; i++)
            {
                if (!notPrime[i])
                {
                    for (int mul = i * 2; mul <= max; mul += i)
                    {
                        notPrime[mul] = true;
                    }
                }
            }

            for (int i = 2; i < notPrime.Length; i++)
            {
                if (!notPrime[i])
                {
                    primes.Add(i);
                }
            }

            return primes;
        }


    }
}
