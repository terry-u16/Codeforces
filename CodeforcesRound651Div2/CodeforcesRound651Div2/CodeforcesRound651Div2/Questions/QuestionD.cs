using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeforcesRound651Div2.Extensions;
using CodeforcesRound651Div2.Questions;

namespace CodeforcesRound651Div2.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadIntArray();

            var evenCost = BoundaryBinarySearch(c => CanWithin(c, a, 0, k), 1000000000, 0);
            var oddCost = BoundaryBinarySearch(c => CanWithin(c, a, 1, k), 1000000000, 0);
            yield return Math.Min(evenCost, oddCost);
        }

        bool CanWithin(int cost, int[] a, int parity, int k)
        {
            var taken = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (taken % 2 == parity)
                {
                    if (a[i] <= cost)
                    {
                        taken++;
                    }
                }
                else
                {
                    taken++;
                }
            }

            return taken >= k;
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
