using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound671Div2.Questions;
using System.Numerics;

namespace CodeforcesRound671Div2.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var tests = io.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                SolveEach(io);
            }
        }

        private static void SolveEach(IOManager io)
        {
            var n = io.ReadLong();
            var last = 0L;
            var stairs = new Queue<long>();

            for (int i = 0; true; i++)
            {
                var side = 1L << i;

                if (new BigInteger(side) * new BigInteger(side) + last * 2 <= n)
                {
                    last = last * 2 + side * side;
                    stairs.Enqueue(last);
                }
                else
                {
                    break;
                }
            }

            var result = 0;

            while (stairs.Count > 0)
            {
                var next = stairs.Dequeue();
                if (n - next >= 0)
                {
                    result++;
                    n -= next;
                }
            }

            io.WriteLine(result);
        }
    }
}
