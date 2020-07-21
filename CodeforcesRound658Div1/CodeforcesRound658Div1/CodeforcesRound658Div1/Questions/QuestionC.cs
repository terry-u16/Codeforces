using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound658Div1.Extensions;
using CodeforcesRound658Div1.Questions;
using System.Diagnostics.CodeAnalysis;

namespace CodeforcesRound658Div1.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (n, sameIndices, sameSets) = inputStream.ReadValue<int, int, int>();
                var guesses = inputStream.ReadIntArray().Select(gi => gi - 1).ToArray();
                var indices = Enumerable.Repeat(0, n + 1).Select(_ => new Stack<int>()).ToArray();

                var results = new int[n];

                for (int i = 0; i < guesses.Length; i++)
                {
                    indices[guesses[i]].Push(i);
                }

                var queue = new PriorityQueue<NumberAndCount>(true);

                for (int i = 0; i < indices.Length; i++)
                {
                    if (indices[i].Count > 0)
                    {
                        queue.Enqueue(new NumberAndCount(i, indices[i].Count));
                    }
                }

                var garbage = Enumerable.Range(0, n + 1).First(i => indices[i].Count == 0);
                var garbageCount = n - sameSets;

                if (garbageCount % 2 == 1 && sameIndices % 2 == 1 && queue.Count >= 2)
                {
                    var one = queue.Dequeue();
                    var two = queue.Dequeue();
                    results[indices[two.Number].Pop()] = garbage;
                    queue.Enqueue(two.Decrement());
                    queue.Enqueue(one);
                    garbageCount--;
                }

                for (int i = 0; i < garbageCount; i++)
                {
                    var max = queue.Dequeue();
                    results[indices[max.Number].Pop()] = garbage;
                    queue.Enqueue(max.Decrement());
                }

                for (int i = 0; i < sameIndices; i++)
                {
                    var max = queue.Dequeue();
                    results[indices[max.Number].Pop()] = max.Number;
                    queue.Enqueue(max.Decrement());
                }

                var open = n - sameIndices;

                if (queue.Peek().Count <= open / 2)
                {
                    yield return "YES";

                    var remains = new HashSet<int>(Enumerable.Range(0, n + 1).Where(i => indices[i].Count > 0));
                    foreach (var pair in queue)
                    {
                        var number = pair.Number;
                        var count = pair.Count;

                        var toRemoves = new Queue<int>();

                        foreach (var remain in remains)
                        {
                            if (remain == number)
                            {
                                continue;
                            }

                            while (count > 0 && indices[remain].Count > 0)
                            {
                                results[indices[remain].Pop()] = number;
                                count--;
                            }

                            if (indices[remain].Count == 0)
                            {
                                toRemoves.Enqueue(remain);
                            }

                            if (count == 0)
                            {
                                break;
                            }
                        }

                        foreach (var toRemove in toRemoves)
                        {
                            remains.Remove(toRemove);
                        }
                    }

                    yield return results.Select(r => r + 1).Join(" ");
                }
                else
                {
                    yield return "NO";
                }
            }
        }

        [StructLayout(LayoutKind.Auto)]
        struct NumberAndCount : IComparable<NumberAndCount>
        {
            public int Number { get; }
            public int Count { get; }

            public NumberAndCount(int number, int count)
            {
                Number = number;
                Count = count;
            }

            public NumberAndCount Decrement() => new NumberAndCount(Number, Count - 1);

            public void Deconstruct(out int number, out int count) => (number, count) = (Number, Count);
            public override string ToString() => $"{nameof(Number)}: {Number}, {nameof(Count)}: {Count}";

            public int CompareTo(NumberAndCount other) => Count - other.Count;
        }

        public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
        {
            private List<T> _heap = new List<T>();
            private readonly int _reverseFactor;
            public int Count => _heap.Count;
            public bool IsDescending => _reverseFactor == 1;

            public PriorityQueue(bool descending) : this(descending, null) { }

            public PriorityQueue(bool descending, IEnumerable<T> collection)
            {
                _reverseFactor = descending ? 1 : -1;
                _heap = new List<T>();

                if (collection != null)
                {
                    foreach (var item in collection)
                    {
                        Enqueue(item);
                    }
                }
            }

            public void Enqueue(T item)
            {
                _heap.Add(item);
                UpHeap();
            }

            public T Dequeue()
            {
                var item = _heap[0];
                DownHeap();
                return item;
            }

            public T Peek() => _heap[0];

            private void UpHeap()
            {
                var child = Count - 1;
                while (child > 0)
                {
                    int parent = (child - 1) / 2;

                    if (Compare(_heap[child], _heap[parent]) > 0)
                    {
                        SwapAt(child, parent);
                        child = parent;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            private void DownHeap()
            {
                _heap[0] = _heap[Count - 1];
                _heap.RemoveAt(Count - 1);

                var parent = 0;
                while (true)
                {
                    var leftChild = 2 * parent + 1;

                    if (leftChild > Count - 1)
                    {
                        break;
                    }

                    var target = (leftChild < Count - 1) && (Compare(_heap[leftChild], _heap[leftChild + 1]) < 0) ? leftChild + 1 : leftChild;

                    if (Compare(_heap[parent], _heap[target]) < 0)
                    {
                        SwapAt(parent, target);
                    }
                    else
                    {
                        break;
                    }

                    parent = target;
                }
            }

            private int Compare(T a, T b) => _reverseFactor * a.CompareTo(b);

            private void SwapAt(int n, int m)
            {
                var temp = _heap[n];
                _heap[n] = _heap[m];
                _heap[m] = temp;
            }

            public IEnumerator<T> GetEnumerator()
            {
                var copy = new List<T>(_heap);
                try
                {
                    while (Count > 0)
                    {
                        yield return Dequeue();
                    }
                }
                finally
                {
                    _heap = copy;
                }
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
