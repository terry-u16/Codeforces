using CodeforcesRound643Div2.Questions;
using CodeforcesRound643Div2.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeforcesRound643Div2.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b, c, d) = inputStream.ReadValue<int, int, int, int>();

            long count = 0;
            for (long x = a; x <= b; x++)
            {
                var minY = Math.Max(BoundaryBinarySearch(y => x + y > c, 0, c), b);
                var maxY = c;
                long width = maxY - minY + 1;
                if (width <= 0)
                {
                    continue;
                }

                long begin = x + minY - 1;
                long overall = (begin + begin + width - 1) * width / 2;

                long overBegin = Math.Max(x + minY - d - 1, 1);
                long overEnd = x + maxY - d - 1;

                long over = overEnd > 0 ? (overBegin + overEnd) * (overEnd - overBegin + 1) / 2 : 0;
                long withRestriction = Math.Max(overall - (c - 1) * width - over, 0);


                count += withRestriction;
            }

            yield return count;
        }
        private static int BoundaryBinarySearch(Predicate<int> predicate, int ng, int ok)
        {
            // めぐる式二分探索
            // Span.BinarySearchだとできそうでできない（lower_boundがダメ）
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
    }
}
