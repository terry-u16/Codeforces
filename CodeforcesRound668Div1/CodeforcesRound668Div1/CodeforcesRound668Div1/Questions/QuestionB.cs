using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound668Div1.Extensions;
using CodeforcesRound668Div1.Questions;

namespace CodeforcesRound668Div1.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        List<int>[] graph;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (n, a, b, jumpA, jumpB) = inputStream.ReadValue<int, int, int, int, int>();
                a--;
                b--;
                graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();

                for (int i = 0; i < n - 1; i++)
                {
                    var (u, v) = inputStream.ReadValue<int, int>();
                    u--;
                    v--;
                    graph[u].Add(v);
                    graph[v].Add(u);
                }

                if (CheckAliceWins(n, a, b, jumpA, jumpB))
                {
                    yield return "Alice";
                }
                else
                {
                    yield return "Bob";
                }
            }
        }

        private bool CheckAliceWins(int n, int a, int b, int jumpA, int jumpB)
        {
            if (jumpA * 2 >= jumpB)
            {
                return true;
            }
            else
            {
                var aliceDistance = GetDistanceFrom(a);

                if (aliceDistance[b] <= jumpA)
                {
                    return true;
                }

                var farest = -1;
                var farestDistance = int.MinValue;
                for (int i = 0; i < aliceDistance.Length; i++)
                {
                    if (aliceDistance[i] > farestDistance)
                    {
                        farest = i;
                        farestDistance = aliceDistance[i];
                    }
                }

                var diameter = GetDistanceFrom(farest).Max();

                if (diameter > 2 * jumpA)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        int[] GetDistanceFrom(int start)
        {
            var distances = Enumerable.Repeat(-1, graph.Length).ToArray();
            distances[start] = 0;
            var todo = new Queue<int>();
            todo.Enqueue(start);

            while (todo.Count > 0)
            {
                var current = todo.Dequeue();

                foreach (var next in graph[current])
                {
                    if (distances[next] == -1)
                    {
                        distances[next] = distances[current] + 1;
                        todo.Enqueue(next);
                    }
                }
            }

            return distances;
        }
    }
}
