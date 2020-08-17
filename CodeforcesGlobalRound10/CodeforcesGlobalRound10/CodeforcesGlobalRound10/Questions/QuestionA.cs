using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesGlobalRound10.Extensions;
using CodeforcesGlobalRound10.Questions;

namespace CodeforcesGlobalRound10.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                _ = inputStream.ReadInt();
                var a = inputStream.ReadIntArray();

                var init = a[0];

                if (a.All(ai => ai == init))
                {
                    yield return a.Length;
                }
                else
                {
                    yield return 1;
                }
            }
        }
    }
}
