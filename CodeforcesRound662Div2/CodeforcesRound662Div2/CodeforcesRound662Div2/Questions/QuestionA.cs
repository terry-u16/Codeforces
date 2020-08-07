using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound662Div2.Extensions;
using CodeforcesRound662Div2.Questions;

namespace CodeforcesRound662Div2.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadLong();
                yield return (n + 2) / 2;
            }
        }
    }
}
