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
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (n, k) = inputStream.ReadValue<int, int>();

                if (k > n)
                {
                    yield return k - n;
                }
                else if (n % 2 == k % 2)
                {
                    yield return 0;
                }
                else
                {
                    yield return 1;
                }
            }
        }
    }
}
