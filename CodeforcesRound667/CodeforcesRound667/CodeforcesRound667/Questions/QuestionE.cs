using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound667.Extensions;
using CodeforcesRound667.Questions;

namespace CodeforcesRound667.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (_, width) = inputStream.ReadValue<int, int>();
                var x = inputStream.ReadIntArray();
                var __ = inputStream.ReadLine();

                Array.Sort(x);

                var endIndice = new int[x.Length];
                var counts = new int[x.Length];

                for (int l = 0; l < x.Length; l++)
                {
                    var endIndex = BoundaryBinarySearch(r => x[r] - x[l] <= width, 0, x.Length);
                    endIndice[l] = endIndex;
                    counts[l] = endIndex - l + 1;
                }

                var prefixMax = new int[x.Length + 1];
                for (int i = counts.Length - 1; i >= 0; i--)
                {
                    prefixMax[i] = Math.Max(prefixMax[i + 1], counts[i]);
                }

                var result = 0;
                for (int l = 0; l < x.Length; l++)
                {
                    result = Math.Max(result, counts[l] + prefixMax[endIndice[l] + 1]);
                }

                yield return result;
            }
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
    }
}
