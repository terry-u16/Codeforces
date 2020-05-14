using CodeforcesRound642Div3.Questions;
using CodeforcesRound642Div3.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace CodeforcesRound642Div3.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var a = new Bfs(n).CreateArray();
                yield return string.Join(" ", a);
            }
        }

        class Bfs
        {
            public int Length { get; }
            int[] _a;
            int count;

            public Bfs(int n)
            {
                Length = n;
            }

            public int[] CreateArray()
            {
                _a = new int[Length];
                count = 1;

                var queue = new PriorityQueue<Range>(true);
                queue.Enqueue(new Range(0, Length - 1));

                while (queue.Count > 0)
                {
                    var range = queue.Dequeue();
                    var center = range.Center;
                    _a[center] = count++;

                    if (range.Left <= range.Center - 1)
                    {
                        queue.Enqueue(new Range(range.Left, range.Center - 1));
                    }
                    if (range.Right >= range.Center + 1)
                    {
                        queue.Enqueue(new Range(range.Center + 1, range.Right));
                    }
                }

                return _a;
            }
        }

        struct Range : IComparable<Range>
        {
            public int Left { get; }
            public int Right { get; }
            public int Center => (Left + Right) / 2;
            public int Width => Right - Left + 1;

            public Range(int left, int right)
            {
                Left = left;
                Right = right;
            }

            public override string ToString() => $"[{Left}:{Center}:{Right}]";

            public int CompareTo(Range other)
            {
                var compare = Width.CompareTo(other.Width);
                if (compare != 0)
                {
                    return compare;
                }
                compare = Left.CompareTo(other.Left);
                return -compare;
            }
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
