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
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (n, k) = inputStream.ReadValue<int, long>();
                var a = inputStream.ReadIntArray();

                var max = a.Max();
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = max - a[i];
                }
                k--;

                if (k % 2 == 0)
                {
                    yield return a.Join(" ");
                }
                else
                {
                    max = a.Max();
                    yield return a.Select(ai => max - ai).Join(" ");
                }
            }
        }
    }
}
