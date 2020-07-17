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
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (n, m) = inputStream.ReadValue<int, int>();
                var graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
                var directedEdges = new List<Edge>();
                var indirectedEdges = new List<Edge>();
                var inDegrees = new int[n];

                for (int i = 0; i < m; i++)
                {
                    var (type, from, to) = inputStream.ReadValue<int, int, int>();
                    from--;
                    to--;

                    if (type == 0)
                    {
                        indirectedEdges.Add(new Edge(from, to));
                    }
                    else
                    {
                        directedEdges.Add(new Edge(from, to));
                        inDegrees[to]++;
                        graph[from].Add(to);
                    }
                }

                var sorted = TopologicalSort(graph, inDegrees);

                if (sorted == null)
                {
                    yield return "NO";
                }
                else
                {
                    yield return "YES";

                    foreach (var edge in directedEdges)
                    {
                        var from = edge.From + 1;
                        var to = edge.To + 1;
                        yield return $"{from} {to}";
                    }

                    var indices = new int[n];
                    for (int i = 0; i < indices.Length; i++)
                    {
                        indices[sorted[i]] = i;
                    }

                    foreach (var edge in indirectedEdges)
                    {
                        var fromIndex = indices[edge.From];
                        var toIndex = indices[edge.To];

                        var from = edge.From + 1;
                        var to = edge.To + 1;

                        if (fromIndex < toIndex)
                        {
                            yield return $"{from} {to}";
                        }
                        else
                        {
                            yield return $"{to} {from}";
                        }
                    }
                }
            }
        }

        List<int> TopologicalSort(List<int>[] edges, int[] inDegrees)
        {
            var sorted = new List<int>();
            var queue = new Queue<int>();

            for (int i = 0; i < inDegrees.Length; i++)
            {
                if (inDegrees[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                sorted.Add(current);

                foreach (var to in edges[current])
                {
                    inDegrees[to]--;
                    if (inDegrees[to] == 0)
                    {
                        queue.Enqueue(to);
                    }
                }
            }

            if (sorted.Count == inDegrees.Length)
            {
                return sorted;
            }
            else
            {
                return null;
            }
        }

        [StructLayout(LayoutKind.Auto)]
        struct Edge
        {
            public int From { get; }
            public int To { get; }

            public Edge(int from, int to)
            {
                From = from;
                To = to;
            }

            public override string ToString() => $"{nameof(From)}: {From}, {nameof(To)}: {To}";
        }
    }
}
