using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound671Div2.Questions;

namespace CodeforcesRound671Div2.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var tests = io.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var n = io.ReadInt();
                var primes = PrimeFactorize(n).ToArray();

                if (primes.Length == 2 && primes.All(p => p.Count == 1))
                {
                    io.WriteLine(1);
                    var result = new int[] { primes[0].Prime, primes[0].Prime * primes[1].Prime, primes[1].Prime };
                    io.WriteLine(result, ' ');
                }
                else if (primes.Length == 1)
                {
                    io.WriteLine(0);
                    var result = Dfs(primes, 0, new List<int>() { 1 }).Where(i => i > 1).Distinct().ToList();
                    io.WriteLine(result.ToArray(), ' ');
                }
                else
                {
                    io.WriteLine(0);
                    var result = Dfs(primes, 0, new List<int>() { 1 }).Where(i => i > 1).Distinct().ToList();

                    var cursor = 0;
                    var last = -1;

                    for (int i = 0; i < result.Count; i++)
                    {
                        if (result[i] % primes[(cursor + primes.Length - 1) % primes.Length].Prime != 0)
                        {
                            last = i;
                        }

                        if (result[i] % primes[(cursor + primes.Length - 1) % primes.Length].Prime == 0)
                        {
                            Swap(result, last, i);
                            cursor++;
                            last = i;
                        }
                    }

                    io.WriteLine(result.ToArray(), ' ');
                }
            }
        }

        void Swap(List<int> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        List<int> Dfs(PrimeAndCount[] primeAndCounts, int depth, List<int> divisiors)
        {
            if (depth == primeAndCounts.Length)
            {
                return divisiors;
            }
            else
            {
                var next = new List<int>();

                foreach (var div in divisiors)
                {
                    var pre = 1;
                    for (int i = 0; i <= primeAndCounts[depth].Count; i++)
                    {
                        var mul = div * pre;
                        next.Add(mul);
                        pre *= primeAndCounts[depth].Prime;
                    }
                }

                return divisiors.Concat(Dfs(primeAndCounts, depth + 1, next)).ToList();
            }


        }

        IEnumerable<PrimeAndCount> PrimeFactorize(int n)
        {
            for (int i = 2; i * i <= n; i++)
            {
                var count = 0;
                while (n % i == 0)
                {
                    count++;
                    n /= i;
                }

                if (count > 0)
                {
                    yield return new PrimeAndCount(i, count);
                }
            }

            if (n > 1)
            {
                yield return new PrimeAndCount(n, 1);
            }
        }

        [StructLayout(LayoutKind.Auto)]
        struct PrimeAndCount
        {
            public int Prime { get; }
            public int Count { get; }

            public PrimeAndCount(int prime, int count)
            {
                Prime = prime;
                Count = count;
            }

            public void Deconstruct(out int prime, out int count) => (prime, count) = (Prime, Count);
            public override string ToString() => $"{nameof(Prime)}: {Prime}, {nameof(Count)}: {Count}";
        }
    }
}
