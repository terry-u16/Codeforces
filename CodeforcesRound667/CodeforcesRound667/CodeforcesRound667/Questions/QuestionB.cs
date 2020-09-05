using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound667.Extensions;
using CodeforcesRound667.Questions;

namespace CodeforcesRound667.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (a, b, x, y, n) = inputStream.ReadValue<long, long, long, long, int>();

                var a1 = Math.Max(a - n, x);
                var remain = n - (a - a1);
                var b1 = Math.Max(b - remain, y);

                var b2 = Math.Max(b - n, y);
                remain = n - (b - b2);
                var a2 = Math.Max(a - remain, x);

                yield return Math.Min(a1 * b1, a2 * b2);
            }
        }
    }
}
