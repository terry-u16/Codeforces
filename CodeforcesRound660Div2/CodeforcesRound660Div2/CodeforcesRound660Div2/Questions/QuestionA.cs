using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound660Div2.Extensions;
using CodeforcesRound660Div2.Questions;

namespace CodeforcesRound660Div2.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            var nearlyPrimes = new int[] { 6, 10, 14 };
            var nearlyPrimeSum = nearlyPrimes.Sum();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();

                if (n == 36)
                {
                    yield return "YES";
                    yield return "5 6 10 15";
                }
                else if (n == 40)
                {
                    yield return "YES";
                    yield return "6 9 10 15";
                }
                else if (n == 44)
                {
                    yield return "YES";
                    yield return "6 7 10 21";
                }
                else
                {
                    var other = n - nearlyPrimeSum;

                    if (other > 0)
                    {
                        yield return "YES";
                        yield return $"{nearlyPrimes.Join(" ")} {other}";
                    }
                    else
                    {
                        yield return "NO";
                    }
                }
            }
        }
    }
}
