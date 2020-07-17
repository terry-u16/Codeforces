using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound656Div3.Extensions;
using CodeforcesRound656Div3.Questions;

namespace CodeforcesRound656Div3.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var a = new Queue<int>(inputStream.ReadIntArray());
                var selected = new bool[n];
                var result = new Queue<int>();
                while (a.Count > 0)
                {
                    var next = a.Dequeue();
                    if (!selected[next - 1])
                    {
                        result.Enqueue(next);
                        selected[next - 1] = true;
                    }
                }

                yield return result.Join(" ");
            }
        }
    }
}
