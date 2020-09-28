using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound481Div3.Questions;
using System.Diagnostics.CodeAnalysis;

namespace CodeforcesRound481Div3.Questions
{
    public class QuestionG : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var totalDays = io.ReadInt();
            var totalExams = io.ReadInt();
            var result = new int[totalDays];
            var starts = Enumerable.Repeat(0, totalDays).Select(_ => new List<int>()).ToArray();
            var exams = new Exam[totalExams];
            var examPlans = new int[totalDays];

            for (int i = 0; i < exams.Length; i++)
            {
                var s = io.ReadInt() - 1;
                var d = io.ReadInt() - 1;
                var c = io.ReadInt();
                exams[i] = new Exam(d, i);

                for (int j = 0; j < c; j++)
                {
                    starts[s].Add(i);
                }

                result[d] = totalExams + 1;
                examPlans[d] = i;
            }

            Array.Sort(exams);
            Study.SetOrder(exams.Select(ex => ex.ID).ToArray());
            var queue = new PriorityQueue<Study>(false);
            var ended = new HashSet<int>();

            for (int day = 0; day < result.Length; day++)
            {
                foreach (var todo in starts[day])
                {
                    queue.Enqueue(new Study(todo));
                }

                if (result[day] == 0 && queue.Count > 0)
                {
                    var next = queue.Dequeue().Subject;
                    if (ended.Contains(next))
                    {
                        io.WriteLine(-1);
                        return;
                    }
                    else
                    {
                        result[day] = next + 1;
                    }
                }
                else if (result[day] != 0)
                {
                    ended.Add(examPlans[day]);
                }
            }

            if (queue.Count == 0)
            {
                io.WriteLine(result, ' ');
            }
            else
            {
                io.WriteLine(-1);
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Exam : IComparable<Exam>
        {
            public int EndDay { get; }
            public int ID { get; }

            public Exam(int endDay, int id)
            {
                EndDay = endDay;
                ID = id;
            }

            public void Deconstruct(out int endDay, out int id) => (endDay, id) = (EndDay, ID);
            public override string ToString() => $"{nameof(EndDay)}: {EndDay}, {nameof(ID)}: {ID}";

            public int CompareTo([AllowNull] Exam other) => EndDay - other.EndDay;
        }

        readonly struct Study : IComparable<Study>
        {
            public int Subject { get; }
            static int[] _order;

            public static void SetOrder(int[] subjects)
            {
                _order = new int[subjects.Length];

                for (int i = 0; i < subjects.Length; i++)
                {
                    _order[subjects[i]] = i;
                }
            }

            public Study(int subject)
            {
                Subject = subject;
            }

            public int CompareTo([AllowNull] Study other) => _order[Subject] - _order[other.Subject];
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
