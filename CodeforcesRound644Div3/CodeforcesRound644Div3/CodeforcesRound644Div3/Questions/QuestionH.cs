using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeforcesRound644Div3.Extensions;
using CodeforcesRound644Div3.Questions;

namespace CodeforcesRound644Div3.Questions
{
    public class QuestionH : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (n, m) = inputStream.ReadValue<int, int>();
                long max = 1L << m;
                long remain = (1L << m) - n;

                var removeds = new long[n];
                for (int i = 0; i < n; i++)
                {
                    removeds[i] = Convert.ToInt64(inputStream.ReadLine(), 2);
                }
                Array.Sort(removeds);

                var index = BoundaryBinarySearch(i =>
                {
                    var underCount = i + 1 - removeds.Count(j => j <= i);
                    return underCount >= (remain + 1) / 2;
                }, -1, max - 1);

                var result = Convert.ToString(index, 2);
                yield return string.Concat(Enumerable.Repeat('0', Math.Max(m - result.Length, 0))) + result;
            }
        }

        private static long BoundaryBinarySearch(Predicate<long> predicate, long ng, long ok)
        {
            // めぐる式二分探索
            // Span.BinarySearchだとできそうでできない（lower_boundがダメ）
            while (Math.Abs(ok - ng) > 1)
            {
                long mid = (ok + ng) / 2;

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

    }
}
