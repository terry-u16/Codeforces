using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound669Div2.Extensions;
using CodeforcesRound669Div2.Questions;

namespace CodeforcesRound669Div2.Questions
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
                var ones = a.Count(c => c == 1);
                var zeros = a.Count(c => c == 0);
                if (zeros >= ones)
                {
                    var result = Enumerable.Repeat(0, zeros).ToArray();
                    yield return result.Length;
                    yield return result.Join(" ");
                }
                else
                {
                    var result = Enumerable.Repeat(1, ones / 2 * 2).ToArray();
                    yield return result.Length;
                    yield return result.Join(" ");
                }
            }
        }
    }
}
