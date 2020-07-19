using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound657Div2.Extensions;
using CodeforcesRound657Div2.Questions;

namespace CodeforcesRound657Div2.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (l, r, m) = inputStream.ReadValue<long, long, long>();
                var min = m - r + l;
                var max = m + r - l;
                var ok = false;

                for (long a = l; a <= r && !ok; a++)
                {
                    var n = max / a;
                    var nTimesA = n * a;
                    if (n > 0 && min <= nTimesA && nTimesA <= max)
                    {
                        var bMinusC = m - nTimesA;
                        for (long b = l; b <= r; b++)
                        {
                            var c = b - bMinusC;
                            if (l <= c && c <= r)
                            {
                                ok = true;
                                yield return $"{a} {b} {c}";
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
