using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound658Div1.Extensions;
using CodeforcesRound658Div1.Questions;

namespace CodeforcesRound658Div1.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var p = inputStream.ReadIntArray();
                var groups = Initialize(p);

                var constructables = new bool[groups.Count + 1, n + 1];
                constructables[0, 0] = true;

                for (int group = 0; group < groups.Count; group++)
                {
                    for (int sum = 0; sum <= n; sum++)
                    {
                        constructables[group + 1, sum] |= constructables[group, sum];

                        var next = sum + groups[group];
                        if (next <= n)
                        {
                            constructables[group + 1, next] |= constructables[group, sum];
                        }
                    }
                }

                yield return constructables[groups.Count, n] ? "YES" : "NO";
            }
        }

        List<int> Initialize(int[] p)
        {
            var list = new List<int>();
            var ascending = false;
            var stack = new Stack<int>();
            stack.Push(p[0]);
            var max = p[0];

            for (int i = 1; i < p.Length; i++)
            {
                if (!ascending)
                {
                    if (p[i] > stack.Peek())
                    {
                        list.Add(stack.Count);
                        stack.Clear();
                        stack.Push(p[i]);
                    }
                    else
                    {
                        ascending = true;
                        max = stack.Peek();
                        stack.Push(p[i]);
                    }
                }
                else
                {
                    if (p[i] < max)
                    {
                        stack.Push(p[i]);
                    }
                    else
                    {
                        ascending = false;
                        list.Add(stack.Count);
                        stack.Clear();
                        stack.Push(p[i]);
                    }
                }
            }

            list.Add(stack.Count);
            return list;
        }
    }
}
