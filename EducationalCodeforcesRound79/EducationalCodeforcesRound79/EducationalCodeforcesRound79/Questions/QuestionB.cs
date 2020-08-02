using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound79.Extensions;
using EducationalCodeforcesRound79.Questions;

namespace EducationalCodeforcesRound79.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (n, s) = inputStream.ReadValue<int, long>();
                var seconds = inputStream.ReadLongArray();

                var secondsSum = new long[n + 1];
                for (int i = 0; i < seconds.Length; i++)
                {
                    secondsSum[i + 1] = secondsSum[i] + seconds[i];
                }

                if (secondsSum[seconds.Length] <= s)
                {
                    yield return 0;
                }
                else
                {
                    var maxPresents = BoundaryBinarySearch(i => secondsSum[i] <= s, 0, secondsSum.Length);
                    var index = -1;
                    for (int skip = 0; skip < seconds.Length; skip++)
                    {
                        if (secondsSum[skip] > s)
                        {
                            break;
                        }

                        var count = BoundaryBinarySearch(i => secondsSum[i] - seconds[skip] <= s, 0, secondsSum.Length);
                        if (count > maxPresents)
                        {
                            maxPresents = count;
                            index = skip;
                        }
                    }
                    yield return index + 1;
                }
            }
        }

        public static int BoundaryBinarySearch(Predicate<int> predicate, int ok, int ng)
        {
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
