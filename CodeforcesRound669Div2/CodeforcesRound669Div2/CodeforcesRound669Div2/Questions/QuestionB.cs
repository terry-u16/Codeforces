using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound669Div2.Extensions;
using CodeforcesRound669Div2.Questions;

namespace CodeforcesRound669Div2.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var a = inputStream.ReadIntArray().ToList();

                var result = new List<long>(a.Count);
                var current = 0L;

                for (int i = 0; i < n; i++)
                {
                    var maxIndex = -1;
                    var max = long.MinValue;

                    for (int j = 0; j < a.Count; j++)
                    {
                        var gcd = Gcd(current, a[j]);
                        if (gcd > max)
                        {
                            max = gcd;
                            maxIndex = j;
                        }
                    }

                    current = max;
                    result.Add(a[maxIndex]);
                    a.RemoveAt(maxIndex);
                }

                yield return result.Join(" ");
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
    }
}
