using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound664Div1.Extensions;
using CodeforcesRound664Div1.Questions;
using System.Diagnostics.CodeAnalysis;

namespace CodeforcesRound664Div1.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (nodeCount, edgeCount, maxOut) = inputStream.ReadValue<int, int, int>();
            var ngs = new HashSet<Pair>[maxOut][];
            for (int i = 0; i < ngs.Length; i++)
            {
                ngs[i] = new HashSet<Pair>[i + 1];
                for (int j = 0; j < ngs[i].Length; j++)
                {
                    ngs[i][j] = new HashSet<Pair>();
                }
            }

            var graph = new List<Edge>[nodeCount];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < edgeCount; i++)
            {
                var (u, v, w) = inputStream.ReadValue<int, int, int>();
                u--;
                v--;
                graph[u].Add(new Edge(v, w));
            }

            var sets = Enumerable.Repeat(0, nodeCount).Select(_ => new HashSet<Pair>()).ToArray();

            for (int i = 0; i < nodeCount; i++)
            {
                graph[i].Sort();
                for (int j = 0; j < graph[i].Count; j++)
                {
                    sets[graph[i][j].To].Add(new Pair(graph[i].Count - 1, j));
                }
            }

            for (int i = 0; i < nodeCount; i++)
            {
                var list = sets[i].OrderBy(p => p).ToArray();
                for (int j = 0; j < list.Length; j++)
                {
                    for (int k = j + 1; k < list.Length; k++)
                    {
                        ngs[list[j].K][list[j].C].Add(new Pair(list[k].K, list[k].C));
                    }
                }
            }

            var currentNgs = Enumerable.Repeat(0, maxOut).Select(_ => new int[maxOut]).ToArray();
            yield return Dfs(0, maxOut, ngs, currentNgs);
        }

        int Dfs(int current, int max, HashSet<Pair>[][] ngs, int[][] currentNg)
        {
            if (current == max)
            {
                return 1;
            }

            var total = 0;
            for (int c = 0; c <= current; c++)
            {
                if (currentNg[current][c] > 0)
                {
                    continue;
                }

                foreach (var ng in ngs[current][c])
                {
                    currentNg[ng.K][ng.C]++;
                }

                total += Dfs(current + 1, max, ngs, currentNg);
                foreach (var ng in ngs[current][c])
                {
                    currentNg[ng.K][ng.C]--;
                }

            }

            return total;
        }

        [StructLayout(LayoutKind.Auto)]
        struct Pair : IEquatable<Pair>, IComparable<Pair>
        {
            public int K { get; }
            public int C { get; }

            public Pair(int k, int c)
            {
                K = k;
                C = c;
            }

            public void Deconstruct(out int k, out int c) => (k, c) = (K, C);
            public override string ToString() => $"{nameof(K)}: {K}, {nameof(C)}: {C}";

            public override bool Equals(object obj)
            {
                return obj is Pair pair && Equals(pair);
            }

            public bool Equals(Pair other)
            {
                return K == other.K &&
                       C == other.C;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = -503916532;
                    hashCode = hashCode * -1521134295 + K.GetHashCode();
                    hashCode = hashCode * -1521134295 + C.GetHashCode();
                    return hashCode;
                }
            }

            public int CompareTo(Pair other)
            {
                var comp = K - other.K;
                if (comp != 0)
                {
                    return comp;
                }
                else
                {
                    return C - other.C;
                }
            }

            public static bool operator ==(Pair left, Pair right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Pair left, Pair right)
            {
                return !(left == right);
            }
        }

        [StructLayout(LayoutKind.Auto)]
        struct Edge : IComparable<Edge>
        {
            public int To { get; }
            public int Weight { get; }

            public Edge(int to, int weight)
            {
                To = to;
                Weight = weight;
            }

            public void Deconstruct(out int to, out int weight) => (to, weight) = (To, Weight);
            public override string ToString() => $"{nameof(To)}: {To}, {nameof(Weight)}: {Weight}";

            public int CompareTo(Edge other) => Weight - other.Weight;
        }

        int Shift(int k, int c)
        {
            c--;
            switch (k)
            {
                case 1:
                    return 0;
                case 2:
                    return 1 + c;
                case 3:
                    return 3 + c;
                case 4:
                    return 6 + c;
                case 5:
                    return 10 + c;
                case 6:
                    return 15 + c;
                case 7:
                    return 21 + c;
                case 8:
                    return 28 + c;
                case 9:
                    return 36 + c;
                default:
                    return -1;
            }
        }
    }
}
