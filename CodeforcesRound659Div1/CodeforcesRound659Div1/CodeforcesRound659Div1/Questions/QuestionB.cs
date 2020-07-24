using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound659Div1.Extensions;
using CodeforcesRound659Div1.Questions;

namespace CodeforcesRound659Div1.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                yield return SolveEach(inputStream.ReadInt(), inputStream.ReadIntArray());
            }
        }

        string SolveEach(int n, int[] a)
        {
            const int MaxBit = 30;
            var counts = new int[MaxBit];
            foreach (var ai in a)
            {
                for (int shift = 0; shift < MaxBit; shift++)
                {
                    counts[shift] += (ai >> shift) & 1;
                }
            }

            var last = a.Length;
            for (int shift = MaxBit - 1; shift >= 0; shift--)
            {
                last -= counts[shift];

                if (counts[shift] % 4 == 1)
                {
                    return "WIN";
                }
                else if (counts[shift] % 4 == 3)
                {
                    return last % 2 == 0 ? "LOSE" : "WIN";
                }
            }

            return "DRAW";
        }
    }
}
