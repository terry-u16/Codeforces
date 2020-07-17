using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound656Div3.Extensions;
using CodeforcesRound656Div3.Questions;

namespace CodeforcesRound656Div3.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var a = inputStream.ReadIntArray();
                Array.Sort(a);
                if (a[1] == a[2])
                {
                    yield return "YES";
                    yield return $"{a[0]} {a[0]} {a[2]}";
                }
                else
                {
                    yield return "NO";
                }
            }
        }
    }
}
