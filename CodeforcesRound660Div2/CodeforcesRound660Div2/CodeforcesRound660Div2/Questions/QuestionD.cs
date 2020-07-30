using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound660Div2.Extensions;
using CodeforcesRound660Div2.Questions;

namespace CodeforcesRound660Div2.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        List<int>[] graph;
        Queue<int> operations;
        long sum;
        int n;
        long[] a;
        int[] b;
        bool[] selected;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            n = inputStream.ReadInt();
            a = inputStream.ReadLongArray();
            b = inputStream.ReadIntArray().Select(bi => bi == -1 ? -1 : bi - 1).ToArray();
            graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
            operations = new Queue<int>(n);
            selected = new bool[n];
            sum = 0;

            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] != -1)
                {
                    graph[b[i]].Add(i);
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == -1)
                {
                    PlusDfs(i);
                }
            }

            for (int i = 0; i < selected.Length; i++)
            {
                if (b[i] == -1)
                {
                    MinusDfs(i);
                }
            }

            yield return sum;
            yield return operations.Select(op => op + 1).Join(" ");
        }

        void PlusDfs(int start)
        {
            var todo = new Stack<int>();
            var reverse = new Stack<int>();
            todo.Push(start);

            while (todo.Count > 0)
            {
                var current = todo.Pop();
                reverse.Push(current);
                foreach (var child in graph[current])
                {
                    todo.Push(child);
                }
            }

            while (reverse.Count > 0)
            {
                var current = reverse.Pop();

                if (a[current] >= 0)
                {
                    sum += a[current];
                    selected[current] = true;
                    operations.Enqueue(current);
                    if (b[current] != -1)
                    {
                        a[b[current]] += a[current];
                    }
                }
            }
        }

        void MinusDfs(int start)
        {
            var todo = new Stack<int>();
            todo.Push(start);

            while (todo.Count > 0)
            {
                var current = todo.Pop();
                if (!selected[current])
                {
                    sum += a[current];
                    operations.Enqueue(current);
                }
                foreach (var child in graph[current])
                {
                    todo.Push(child);
                }
            }

        }
    }
}
