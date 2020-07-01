using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound654Div2.Extensions;
using CodeforcesRound654Div2.Questions;

namespace CodeforcesRound654Div2.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (n, r) = inputStream.ReadValue<long, long>();

                if (r < n)
                {
                    yield return r * (r + 1) / 2;
                }
                else
                {
                    yield return n * (n - 1) / 2 + 1;
                }
            }
        }
    }
}
