using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound639Div2.Extensions;
using CodeforcesRound639Div2.Questions;

namespace CodeforcesRound639Div2.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (n, m) = inputStream.ReadValue<int, int>();

                if (n > m)
                {
                    var temp = n;
                    n = m;
                    m = temp;
                }

                if (n == 1)
                {
                    yield return "YES";
                }
                else if (n == 2 && m == 2)
                {
                    yield return "YES";
                }
                else
                {
                    yield return "NO";
                }
            }
        }
    }
}
