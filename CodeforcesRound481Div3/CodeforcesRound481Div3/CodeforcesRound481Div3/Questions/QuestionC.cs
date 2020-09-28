using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound481Div3.Questions;

namespace CodeforcesRound481Div3.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var domitoryCount = io.ReadInt();
            var letterCount = io.ReadInt();
            var rooms = io.ReadLongArray(domitoryCount);

            var prefixSum = new long[rooms.Length + 1];

            for (int i = 0; i < rooms.Length; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + rooms[i];
            }

            for (int i = 0; i < letterCount; i++)
            {
                var r = io.ReadLong() - 1;
                var d = GetLessEqualIndex(prefixSum, r);

                io.WriteLine($"{d + 1} {r - prefixSum[d] + 1}");
            }
        }

        class LowerBoundComparer<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y) => 0 <= x.CompareTo(y) ? 1 : -1;
        }

        class UpperBoundComparer<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y) => 0 < x.CompareTo(y) ? 1 : -1;
        }

        // https://trsing.hatenablog.com/entry/2019/08/27/211038
        public static int GetGreaterEqualIndex<T>(ReadOnlySpan<T> span, T inclusiveMin) where T : IComparable<T> => ~span.BinarySearch(inclusiveMin, new UpperBoundComparer<T>());
        public static int GetGreaterThanIndex<T>(ReadOnlySpan<T> span, T exclusiveMin) where T : IComparable<T> => ~span.BinarySearch(exclusiveMin, new LowerBoundComparer<T>());
        public static int GetLessEqualIndex<T>(ReadOnlySpan<T> span, T inclusiveMax) where T : IComparable<T> => ~span.BinarySearch(inclusiveMax, new LowerBoundComparer<T>()) - 1;
        public static int GetLessThanIndex<T>(ReadOnlySpan<T> span, T exclusiveMax) where T : IComparable<T> => ~span.BinarySearch(exclusiveMax, new UpperBoundComparer<T>()) - 1;
    }
}
