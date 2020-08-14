using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound62.Extensions;
using EducationalCodeforcesRound62.Questions;
using System.Diagnostics.CodeAnalysis;

namespace EducationalCodeforcesRound62.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, toSelect) = inputStream.ReadValue<int, int>();

            var songs = new Song[n];
            for (int i = 0; i < songs.Length; i++)
            {
                var (t, b) = inputStream.ReadValue<int, int>();
                songs[i] = new Song(t, b);
            }

            Array.Sort(songs);

            var timeQueue = new PriorityQueue<long>(false);
            long totalTime = 0;
            long maxPleasure = 0;

            foreach (var song in songs)
            {
                var beauty = song.Beauty;
                totalTime += song.Time;
                timeQueue.Enqueue(song.Time);

                if (timeQueue.Count > toSelect)
                {
                    totalTime -= timeQueue.Dequeue();
                }

                maxPleasure = Math.Max(maxPleasure, totalTime * beauty);
            }

            yield return maxPleasure;
        }

        [StructLayout(LayoutKind.Auto)]
        struct Song : IComparable<Song>
        {
            public long Time { get; }
            public long Beauty { get; }

            public Song(long time, long beauty)
            {
                Time = time;
                Beauty = beauty;
            }

            public void Deconstruct(out long time, out long beauty) => (time, beauty) = (Time, Beauty);
            public override string ToString() => $"{nameof(Time)}: {Time}, {nameof(Beauty)}: {Beauty}";

            public int CompareTo(Song other) => Math.Sign(other.Beauty - Beauty);
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
