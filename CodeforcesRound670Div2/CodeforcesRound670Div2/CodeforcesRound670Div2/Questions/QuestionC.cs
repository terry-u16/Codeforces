using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound670Div2.Extensions;
using CodeforcesRound670Div2.Questions;

namespace CodeforcesRound670Div2.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        List<int>[] graph;
        int[] sizes;
        List<int> centroids;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();

                graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();

                for (int i = 0; i < n - 1; i++)
                {
                    var (a, b) = inputStream.ReadValue<int, int>();
                    a--;
                    b--;
                    graph[a].Add(b);
                    graph[b].Add(a);
                }

                sizes = new int[graph.Length];
                centroids = new List<int>();
                Dfs(0, -1);

                if (centroids.Count == 1)
                {
                    yield return $"1 {graph[0][0] + 1}";
                    yield return $"1 {graph[0][0] + 1}";
                }
                else
                {
                    graph[centroids[0]].Remove(centroids[1]);
                    var d = Bfs(centroids[0]);
                    var farest = -1;
                    var maxDistance = int.MinValue;
                    for (int i = 0; i < d.Length; i++)
                    {
                        if (d[i] > maxDistance)
                        {
                            farest = i;
                            maxDistance = d[i];
                        }
                    }

                    yield return $"{graph[farest][0] + 1} {farest + 1}";
                    yield return $"{centroids[1] + 1} {farest + 1}";
                }
            }
        }

        void Dfs(int current, int parent)
        {
            sizes[current] = 1;
            bool isCentroid = true;

            foreach (var next in graph[current])
            {
                if (next == parent)
                {
                    continue;
                }

                Dfs(next, current);
                if (sizes[next] > graph.Length / 2)
                {
                    isCentroid = false;
                }
                sizes[current] += sizes[next];
            }

            if (graph.Length - sizes[current] > graph.Length / 2)
            {
                isCentroid = false;
            }

            if (isCentroid)
            {
                centroids.Add(current);
            }
        }

        int[] Bfs(int start)
        {
            var distances = Enumerable.Repeat(-1, graph.Length).ToArray();
            var toVisit = new Queue<int>();
            toVisit.Enqueue(start);
            distances[start] = 0;

            while (toVisit.Count > 0)
            {
                var current = toVisit.Dequeue();

                foreach (var next in graph[current])
                {
                    if (distances[next] == -1)
                    {
                        distances[next] = distances[current] + 1;
                        toVisit.Enqueue(next);
                    }
                }
            }

            return distances;
        }

    }
}
