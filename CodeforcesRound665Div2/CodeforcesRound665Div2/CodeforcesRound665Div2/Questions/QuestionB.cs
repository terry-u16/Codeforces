using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound665Div2.Extensions;
using CodeforcesRound665Div2.Questions;

namespace CodeforcesRound665Div2.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var a = inputStream.ReadIntArray();
                var b = inputStream.ReadIntArray();

                var sum = 0L;
                sum += Math.Min(a[2], b[1]) * 2;
                a[2] -= Math.Min(a[2], b[1]);
                b[2] -= a[0];
                b[2] -= a[2];
                if (b[2] > 0)
                {
                    sum -= b[2] * 2;
                }

                yield return sum;
            }
        }
    }
}
