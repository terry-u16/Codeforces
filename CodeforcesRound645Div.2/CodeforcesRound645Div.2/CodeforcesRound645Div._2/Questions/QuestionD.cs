using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeforcesRound645Div._2.Extensions;
using CodeforcesRound645Div._2.Questions;
using Microsoft.Win32.SafeHandles;

namespace CodeforcesRound645Div._2.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (months, vacation) = inputStream.ReadValue<int, long>();
            var daysPerMonths = inputStream.ReadIntArray();
            daysPerMonths = Enumerable.Repeat(0, 1).Concat(daysPerMonths).Concat(daysPerMonths).ToArray();

            var daysPrefixSum = new long[daysPerMonths.Length];
            var hugsPrefixSum = new long[daysPerMonths.Length];

            for (int i = 1; i < daysPerMonths.Length; i++)
            {
                daysPrefixSum[i] = daysPrefixSum[i - 1] + daysPerMonths[i];
                hugsPrefixSum[i] = hugsPrefixSum[i - 1] + GetHugCount(daysPerMonths[i]);
            }

            long maxHugs = 0;
            for (int month = 1; month < daysPrefixSum.Length; month++)
            {
                if (daysPrefixSum[month] < vacation)
                {
                    continue;
                }

                var includedMonth = BoundaryBinarySearch(daysPrefixSum, d => d >= daysPrefixSum[month] - vacation, 0, daysPrefixSum.Length);
                var backDate = vacation - (daysPrefixSum[month] - daysPrefixSum[includedMonth]);
                var hugs = hugsPrefixSum[month] - hugsPrefixSum[includedMonth] + GetHugCount(daysPerMonths[includedMonth] - backDate + 1, daysPerMonths[includedMonth]);
                maxHugs = Math.Max(maxHugs, hugs);
            }

            yield return maxHugs;
        }

        private static int BoundaryBinarySearch<T>(T[] array, Predicate<T> predicate, int ng, int ok)
        {
            // めぐる式二分探索
            // Span.BinarySearchだとできそうでできない（lower_boundがダメ）
            while (Math.Abs(ok - ng) > 1)
            {
                int mid = (ok + ng) / 2;

                if (predicate(array[mid]))
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

        long GetHugCount(long endDay) => ((endDay + 1) * endDay) / 2;

        long GetHugCount(long beginDay, long endDay) => GetHugCount(endDay) - GetHugCount(beginDay - 1);
    }
}
