using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound666Div1.Extensions;
using CodeforcesRound666Div1.Questions;

namespace CodeforcesRound666Div1.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLong();
            var a = inputStream.ReadLongArray();

            if (n == 1)
            {
                yield return "1 1";
                yield return -a[0];
                yield return "1 1";
                yield return 0;
                yield return "1 1";
                yield return 0;
            }
            else
            {
                // 1st
                var len = n - 1;
                yield return $"1 {len}";
                var op1 = new long[len];
                for (int i = 0; i < op1.Length; i++)
                {
                    var tempA = a[i];

                    if (a[i] < 0)
                    {
                        op1[i] = -((a[i] - len + 1) / len) * len;
                        tempA += op1[i];
                    }

                    var mod = tempA % n;
                    op1[i] += len * mod;
                    a[i] += op1[i];
                }

                yield return op1.Join(" ");

                // 2nd 
                yield return $"{n} {n}";
                yield return -a[n - 1];
                a[n - 1] = 0;

                // 3rd
                yield return $"1 {n}";
                yield return a.Select(ai => -ai).Join(" ");
            }
        }
    }
}
