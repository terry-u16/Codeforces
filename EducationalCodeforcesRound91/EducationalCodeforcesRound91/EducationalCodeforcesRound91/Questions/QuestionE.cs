using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound91.Extensions;
using EducationalCodeforcesRound91.Questions;

namespace EducationalCodeforcesRound91.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        List<int>[] tree;
        int[] depths;
        int[,] parents;
        int discCount, towerCount;
        const int MaxAncestor = 28;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            (discCount, towerCount) = inputStream.ReadValue<int, int>();
            var towers = inputStream.ReadIntArray();

            tree = Enumerable.Repeat(0, 2 * towerCount - 1).Select(_ => new List<int>()).ToArray();
            var currentNodes = Enumerable.Range(0, towerCount).ToArray();

            for (int i = 0; i < towerCount - 1; i++)
            {
                var (u, v) = inputStream.ReadValue<int, int>();
                u--;
                v--;
                var next = towerCount + i;
                tree[next].Add(currentNodes[u]);
                tree[next].Add(currentNodes[v]);
                currentNodes[u] = next;
            }

            ConstructDoubling();

            var counts = new int[towerCount];
            for (int i = 0; i + 1 < towers.Length; i++)
            {
                counts[Math.Max(0, GetLca(towers[i] - 1, towers[i + 1] - 1) - towerCount + 1)]++;
            }

            var result = discCount - 1;
            for (int i = 0; i < counts.Length; i++)
            {
                result -= counts[i];
                yield return result;
            }
        }

        void ConstructDoubling()
        {
            parents = new int[MaxAncestor, tree.Length];
            depths = new int[tree.Length];

            Dfs(tree.Length - 1);

            for (int d = 0; d + 1 < MaxAncestor; d++)
            {
                for (int node = 0; node < tree.Length; node++)
                {
                    parents[d + 1, node] = parents[d, parents[d, node]];
                }
            }
        }

        void Dfs(int root)
        {
            var todo = new Stack<int>();
            todo.Push(root);
            parents[0, root] = root;
            depths[root] = 0;

            while (todo.Count > 0)
            {
                var current = todo.Pop();

                foreach (var child in tree[current])
                {
                    depths[child] = depths[current] + 1;
                    parents[0, child] = current;
                    todo.Push(child);
                }
            }
        }

        int GetLca(int u, int v)
        {
            if (depths[u] < depths[v])
            {
                Swap(ref u, ref v);
            }

            for (int d = 0; d < MaxAncestor; d++)
            {
                if (((depths[u] - depths[v]) & (1 << d)) > 0)
                {
                    u = parents[d, u];
                }
            }

            if (u == v)
            {
                return u;
            }
            else
            {
                for (int d = MaxAncestor - 1; d >= 0; d--)
                {
                    if (parents[d, u] != parents[d, v])
                    {
                        u = parents[d, u];
                        v = parents[d, v];
                    }
                }

                return parents[0, u];
            }
        }

        void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}
