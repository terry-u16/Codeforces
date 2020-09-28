using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound673Div1.Questions;

namespace CodeforcesRound673Div1.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var tests = io.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var n = io.ReadInt();
                var a = io.ReadIntArray(n);

                var lastSeen = new int[n + 1];
                lastSeen.AsSpan().Fill(-1);
                var lengths = new int[n + 1];
                lengths.AsSpan().Fill(-1);

                for (int i = 0; i < a.Length; i++)
                {
                    lengths[a[i]] = Math.Max(i - lastSeen[a[i]] - 1, lengths[a[i]]);
                    lastSeen[a[i]] = i;
                }

                for (int ai = 0; ai < lengths.Length; ai++)
                {
                    lengths[ai] = Math.Max(a.Length - lastSeen[ai] - 1, lengths[ai]);
                }

                var results = new int[n];
                results.AsSpan().Fill(int.MaxValue);

                for (int ai = 0; ai < lengths.Length; ai++)
                {
                    if (lengths[ai] < results.Length)
                    {
                        results[lengths[ai]] = Math.Min(results[lengths[ai]], ai);
                    }
                }

                for (int i = 1; i < results.Length; i++)
                {
                    results[i] = Math.Min(results[i], results[i - 1]);
                }

                for (int i = 0; i < results.Length; i++)
                {
                    if (results[i] == int.MaxValue)
                    {
                        results[i] = -1;
                    }
                }

                io.WriteLine(results, ' ');
            }
        }
    }
}
