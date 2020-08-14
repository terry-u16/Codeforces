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
        int nodeCount, edgeCount, maxOut;
        ulong finalState;
        ulong[][] hashes;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            (nodeCount, edgeCount, maxOut) = inputStream.ReadValue<int, int, int>();

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

            var random = new XorShift();
            var states = new ulong[nodeCount];
            finalState = 0;
            for (int i = 0; i < states.Length; i++)
            {
                states[i] = random.Next();
                finalState ^= states[i];
            }

            hashes = Enumerable.Range(1, maxOut).Select(i => new ulong[i]).ToArray();
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i].Sort();
                for (int j = 0; j < graph[i].Count; j++)
                {
                    hashes[graph[i].Count - 1][j] ^= states[graph[i][j].To];
                }
            }

            yield return Dfs(0, 0);
        }

        int Dfs(int depth, ulong hash)
        {
            if (depth == maxOut)
            {
                return hash == finalState ? 1 : 0;
            }
            else
            {
                int result = 0;
                for (int i = 0; i <= depth; i++)
                {
                    result += Dfs(depth + 1, hash ^ hashes[depth][i]);
                }
                return result;
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

        public class XorShift
        {
            ulong _x;

            public XorShift() : this((ulong)DateTime.Now.Ticks) { }

            public XorShift(ulong seed)
            {
                _x = seed;
            }

            /// <summary>
            /// [0, (2^64)-1)の乱数を生成します。
            /// </summary>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ulong Next()
            {
                _x = _x ^ (_x << 13);
                _x = _x ^ (_x >> 7);
                _x = _x ^ (_x << 17);
                return _x;
            }

            /// <summary>
            /// [0, <c>exclusiveMax</c>)の乱数を生成します。
            /// </summary>
            /// <param name="exclusiveMax"></param>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int Next(int exclusiveMax) => (int)(Next() % (uint)exclusiveMax);

            /// <summary>
            /// [0.0, 1.0)の乱数を生成します。
            /// </summary>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public double NextDouble()
            {
                const ulong max = 1UL << 50;
                const ulong mask = max - 1;
                return (double)(Next() & mask) / max;
            }
        }
    }
}
