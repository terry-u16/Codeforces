using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound639Div2.Extensions;
using CodeforcesRound639Div2.Questions;

namespace CodeforcesRound639Div2.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        List<int>[] invertedGraph;
        bool[] forwardNg, reverseNg;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (variables, formulas) = inputStream.ReadValue<int, int>();
            var inDegrees = new int[variables];
            var graph = Enumerable.Repeat(0, variables).Select(_ => new List<int>()).ToArray();
            invertedGraph = Enumerable.Repeat(0, variables).Select(_ => new List<int>()).ToArray();

            for (int f = 0; f < formulas; f++)
            {
                var (l, r) = inputStream.ReadValue<int, int>();
                l--;
                r--;
                inDegrees[r]++;
                graph[l].Add(r);
                invertedGraph[r].Add(l);
            }

            if (CheckNoLoop(graph, inDegrees.ToArray()))
            {
                var result = new StringBuilder(variables);
                forwardNg = new bool[variables];
                reverseNg = new bool[variables];
                for (int i = 0; i < variables; i++)
                {
                    if (!forwardNg[i] && !reverseNg[i])
                    {
                        result.Append('A');
                    }
                    else
                    {
                        result.Append('E');
                    }

                    if (!forwardNg[i])
                    {
                        ForwardDfs(i);
                    }

                    if (!reverseNg[i])
                    {
                        ReverseDfs(i);
                    }
                }

                var output = result.ToString();
                yield return output.Count(c => c == 'A');
                yield return output;
            }
            else
            {
                yield return -1;
            }
        }

        void ForwardDfs(int current)
        {
            foreach (var next in invertedGraph[current])
            {
                if (!forwardNg[next])
                {
                    forwardNg[next] = true;
                    ReverseDfs(next);
                }
            }
        }

        void ReverseDfs(int current)
        {
            foreach (var next in invertedGraph[current])
            {
                if (!reverseNg[next])
                {
                    reverseNg[next] = true;
                    ReverseDfs(next);
                }
            }
        }

        bool CheckNoLoop(List<int>[] graph, int[] inDegrees)
        {
            var queue = new Queue<int>();
            var appeared = 0;
            for (int i = 0; i < inDegrees.Length; i++)
            {
                if (inDegrees[i] == 0)
                {
                    queue.Enqueue(i);
                    appeared++;
                }
            }

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (var next in graph[current])
                {
                    inDegrees[next]--;
                    if (inDegrees[next] == 0)
                    {
                        queue.Enqueue(next);
                        appeared++;
                    }
                }
            }

            return appeared == inDegrees.Length;
        }
    }
}
