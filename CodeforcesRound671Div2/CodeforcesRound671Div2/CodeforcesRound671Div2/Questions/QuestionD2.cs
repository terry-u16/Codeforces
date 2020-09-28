using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound671Div2.Questions;

namespace CodeforcesRound671Div2.Questions
{
    public class QuestionD2 : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var a = io.ReadIntArray(n);
            Array.Sort(a);
            var queue = new Queue<int>(a);

            var result = new int[n];

            for (int i = 1; i < result.Length; i += 2)
            {
                result[i] = queue.Dequeue();
            }

            for (int i = 0; i < result.Length; i += 2)
            {
                result[i] = queue.Dequeue();
            }

            var count = 0;
            for (int i = 1; i + 1 < result.Length; i++)
            {
                if (result[i - 1] > result[i] && result[i] < result[i + 1])
                {
                    count++;
                }
            }

            io.WriteLine(count);
            io.WriteLine(result, ' ');
        }
    }
}
