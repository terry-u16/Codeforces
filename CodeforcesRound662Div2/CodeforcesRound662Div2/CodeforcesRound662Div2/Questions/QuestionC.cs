using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound662Div2.Extensions;
using CodeforcesRound662Div2.Questions;
using System.Diagnostics.CodeAnalysis;

namespace CodeforcesRound662Div2.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var a = inputStream.ReadIntArray();
                var counts = new int[a.Max() + 1];
                for (int i = 0; i < a.Length; i++)
                {
                    counts[a[i]]++;
                }

                var list = new List<NumberAndCount>();
                for (int i = 0; i < counts.Length; i++)
                {
                    if (counts[i] > 0)
                    {
                        list.Add(new NumberAndCount(i, counts[i]));
                    }
                }

                yield return BoundaryBinarySearch(d => CanSelect(d, list, a.Length), 0, a.Length);
            }
        }

        bool CanSelect(int distance, List<NumberAndCount> numberAndCounts, int aLength)
        {
            var index = 0;
            var queue = new PriorityQueue<NumberAndCount>(true, numberAndCounts);
            var waiting = new Queue<NumberAndCount>();

            while (queue.Count > 0 && index < aLength)
            {
                var current = queue.Dequeue();

                if (current.Count > 1)
                {
                    waiting.Enqueue(--current);
                }
                else
                {
                    waiting.Enqueue(new NumberAndCount());
                }

                if (waiting.Count > distance)
                {
                    var next = waiting.Dequeue();
                    if (next.Number > 0)
                    {
                        queue.Enqueue(next);
                    }
                }

                index++;
            }

            return index == aLength;
        }

        public static int BoundaryBinarySearch(Predicate<int> predicate, int ok, int ng)
        {
            // めぐる式二分探索
            while (Math.Abs(ok - ng) > 1)
            {
                int mid = (ok + ng) / 2;
                if (predicate(mid))
                {
                    ok = mid;
                }
                else
                {
                    ng = mid;
                }
            }
            return ok;
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

            public static NumberAndCount operator --(NumberAndCount numberAndCount) => new NumberAndCount(numberAndCount.Number, numberAndCount.Count - 1);

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
