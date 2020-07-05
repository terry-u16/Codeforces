using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesGlobalRound9.Extensions;
using CodeforcesGlobalRound9.Questions;

namespace CodeforcesGlobalRound9.Questions
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
                var b = new int[a.Length];
                for (int i = 0; i < a.Length; i++)
                {
                    var sign = i % 2 == 0 ? -1 : 1;
                    b[i] = sign * Math.Abs(a[i]);
                }
                yield return string.Join(" ", b);
            }
        }
    }
}
