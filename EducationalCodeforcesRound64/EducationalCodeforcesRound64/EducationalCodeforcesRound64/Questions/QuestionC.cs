using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound64.Extensions;
using EducationalCodeforcesRound64.Questions;

namespace EducationalCodeforcesRound64.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, z) = inputStream.ReadValue<int, int>();
            var x = inputStream.ReadIntArray();
            Array.Sort(x);
            yield return BoundaryBinarySearch(pairs => Check(pairs, x, z), 0, x.Length);
        }

        bool Check(int pairs, int[] x, int z)
        {
            if (pairs > x.Length / 2)
            {
                return false;
            }

            for (int i = 0; i < pairs; i++)
            {
                if (x[x.Length - pairs + i] - x[i] < z)
                {
                    return false;
                }
            }

            return true;
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
