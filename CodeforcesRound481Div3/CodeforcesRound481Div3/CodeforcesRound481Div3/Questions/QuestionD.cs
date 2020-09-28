using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound481Div3.Questions;

namespace CodeforcesRound481Div3.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        const int Inf = 1 << 28;

        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var b = io.ReadLongArray(n).AsSpan();

            if (n <= 2)
            {
                io.WriteLine(0);
                return;
            }

            var result = Inf;

            for (int op1 = -1; op1 <= 1; op1++)
            {
                for (int op2 = -1; op2 <= 1; op2++)
                {
                    var work = new long[b.Length];
                    b.CopyTo(work);
                    work[0] += op1;
                    work[1] += op2;

                    result = Math.Min(result, Check(work, work[0], work[1]) + Math.Abs(op1) + Math.Abs(op2));
                }
            }

            if (result < Inf)
            {
                io.WriteLine(result);
            }
            else
            {
                io.WriteLine(-1);
            }
        }

        int Check(Span<long> span, long first, long second)
        {
            var diff = second - first;
            var count = 0;

            for (int i = 0; i + 1 < span.Length; i++)
            {
                var ok = false;
                for (int op = -1; op <= 1; op++)
                {
                    var next = span[i + 1] + op;

                    if (next - span[i] == diff)
                    {
                        ok = true;
                        span[i + 1] = next;
                        count += Math.Abs(op);
                        break;
                    }
                }

                if (!ok)
                {
                    return Inf;
                }
            }

            return count;
        }
    }
}
