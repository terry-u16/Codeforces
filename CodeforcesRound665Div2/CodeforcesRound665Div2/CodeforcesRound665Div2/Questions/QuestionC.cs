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
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                _ = inputStream.ReadInt();
                var a = inputStream.ReadIntArray();
                var min = a.Min();
                var muls = new List<int>();
                foreach (var ai in a)
                {
                    if (ai % min == 0)
                    {
                        muls.Add(ai);
                    }
                }

                muls.Sort();
                var queue = new Queue<int>(muls);

                var result = new int[a.Length];
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] % min == 0)
                    {
                        result[i] = queue.Dequeue();
                    }
                    else
                    {
                        result[i] = a[i];
                    }
                }

                var ok = true;
                for (int i = 0; i + 1 < result.Length; i++)
                {
                    ok &= result[i] <= result[i + 1];
                }

                yield return ok ? "YES" : "NO";
            }
        }
    }
}
