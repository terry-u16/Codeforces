using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound655Div2.Extensions;
using CodeforcesRound655Div2.Questions;

namespace CodeforcesRound655Div2.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var divs = GetDivisiors(n).Where(i => i != n);

                var minA = int.MaxValue;
                var minLcm = long.MaxValue;

                foreach (var div in divs)
                {
                    var a = div;
                    var b = n - a;
                    var lcm = Lcm(a, b);
                    if (lcm < minLcm)
                    {
                        minA = a;
                        minLcm = lcm;
                    }
                }

                var minB = n - minA;

                yield return $"{minA} {minB}";
            }
        }

        IEnumerable<int> GetDivisiors(int n)
        {
            for (int i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    yield return i;
                    if (i * i != n)
                    {
                        yield return n / i;
                    }
                }
            }
        }

        public static long Gcd(long a, long b)
        {
            if (a < b)
            {
                (a, b) = (b, a);
            }

            if (b == 0)
            {
                return a;
            }
            else
            {
                return Gcd(b, a % b);
            }
        }

        public static long Lcm(long a, long b)
        {
            if (a < 0 || b < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(a)}, {nameof(b)}は0以上の整数である必要があります。");
            }

            return a / Gcd(a, b) * b;
        }

    }
}
