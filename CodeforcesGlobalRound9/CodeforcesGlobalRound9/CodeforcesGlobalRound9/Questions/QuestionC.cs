using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesGlobalRound9.Extensions;
using CodeforcesGlobalRound9.Questions;

namespace CodeforcesGlobalRound9.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var a = inputStream.ReadIntArray();

                var stack = new Stack<int>();

                stack.Push(a[0]);

                foreach (var ai in a)
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(ai);
                    }
                    else if (stack.Count == 1)
                    {
                        if (stack.Peek() > ai)
                        {
                            stack.Push(ai);
                        }
                    }
                    else
                    {
                        while (stack.Count > 1 && stack.Peek() < ai)
                        {
                            stack.Pop();
                        }

                        if (stack.Count == 1 && stack.Peek() > ai)
                        {
                            stack.Push(ai);
                        }
                    }
                }

                yield return stack.Count == 1 ? "YES" : "NO"; 
            }
        }
    }
}
