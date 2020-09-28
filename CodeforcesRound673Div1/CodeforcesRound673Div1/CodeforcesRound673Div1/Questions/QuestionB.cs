using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound673Div1.Questions;
using System.Diagnostics.CodeAnalysis;

namespace CodeforcesRound673Div1.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var tests = io.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                SolveEach(io);

            }
        }

        private static void SolveEach(IOManager io)
        {
            var n = io.ReadInt();
            var a = io.ReadIntArray(n);
            var sum = a.Sum();

            if (sum % n != 0)
            {
                io.WriteLine(-1);
                return;
            }

            var average = sum / n;
            var results = new Queue<Operation>();

            for (int i = a.Length - 1; i >= 0; i--)
            {
                if (a[i] > i + 1)
                {
                    var iPlus = i + 1;
                    var div = a[i] / iPlus;
                    results.Enqueue(new Operation(i, 0, div));
                    a[i] -= div * iPlus;
                    a[0] += div * iPlus;
                    break;
                }
            }

            var queue = new PriorityQueue<NotEnough>(false);

            for (int i = 1; i < a.Length; i++)
            {
                var iPlus = i + 1;
                queue.Enqueue(new NotEnough((int)((iPlus * 10000000000L - a[i]) % iPlus), i));
            }

            while (queue.Count > 0)
            {
                var (notEnough, index) = queue.Dequeue();
                var iPlus = index + 1;
                if (a[0] < notEnough)
                {
                    io.WriteLine(-1);
                    return;
                }
                a[0] -= notEnough;
                a[index] += notEnough;
                results.Enqueue(new Operation(0, index, notEnough));

                var div = a[index] / iPlus;
                a[0] += div * iPlus;
                a[index] = 0;
                results.Enqueue(new Operation(index, 0, div));
            }

            for (int i = 1; i < a.Length; i++)
            {
                results.Enqueue(new Operation(0, i, average));
            }

            io.WriteLine(results.Count);

            while (results.Count > 0)
            {
                io.WriteLine(results.Dequeue());
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct NotEnough : IComparable<NotEnough>
        {
            public int Value { get; }
            public int Index { get; }

            public NotEnough(int value, int index)
            {
                Value = value;
                Index = index;
            }

            public void Deconstruct(out int value, out int index) => (value, index) = (Value, Index);
            public override string ToString() => $"{nameof(Value)}: {Value}, {nameof(Index)}: {Index}";

            public int CompareTo([AllowNull] NotEnough other) => Value - other.Value;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Operation
        {
            public int I { get; }
            public int J { get; }
            public int X { get; }

            public Operation(int i, int j, int x)
            {
                I = i + 1;
                J = j + 1;
                X = x;
            }

            public override string ToString() => $"{I} {J} {X}";
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

            private void SwapAt(int n, int m) => (_heap[n], _heap[m]) = (_heap[m], _heap[n]);

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
