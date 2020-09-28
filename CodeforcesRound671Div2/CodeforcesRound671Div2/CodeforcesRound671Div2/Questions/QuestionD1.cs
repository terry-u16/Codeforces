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
    public class QuestionD1 : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var a = io.ReadIntArray(n);
            Array.Sort(a);

            var result = new List<int>();
            var l = 0;
            var r = a.Length - 1;

            while (l <= r)
            {
                result.Add(a[r--]);

                if (l <= r)
                {
                    result.Add(a[l++]);
                }
            }

            var count = 0;
            for (int i = 1; i + 1 < result.Count; i++)
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
