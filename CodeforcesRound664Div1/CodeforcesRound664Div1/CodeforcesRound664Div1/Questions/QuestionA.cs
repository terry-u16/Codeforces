using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound664Div1.Extensions;
using CodeforcesRound664Div1.Questions;

namespace CodeforcesRound664Div1.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (totalDays, muzzleDulation, threshold) = inputStream.ReadValue<int, int, int>();
            var a = inputStream.ReadLongArray();
            Array.Sort(a);
            Array.Reverse(a);

            var muzzledA = a.Where(ai => ai > threshold).ToArray();
            var nonmuzzledA = a.Where(ai => ai <= threshold).ToArray();

            if (muzzledA.Length <= 1)
            {
                yield return a.Sum();
                yield break;
            }

            var muzzledPrefixSum = new long[muzzledA.Length + 1];
            var nonMuzzledPrefixSum = new long[nonmuzzledA.Length + 1];

            for (int i = 0; i < muzzledA.Length; i++)
            {
                muzzledPrefixSum[i + 1] = muzzledPrefixSum[i] + muzzledA[i];
            }

            for (int i = 0; i < nonmuzzledA.Length; i++)
            {
                nonMuzzledPrefixSum[i + 1] = nonMuzzledPrefixSum[i] + nonmuzzledA[i];
            }

            long max = 0;

            for (int muzzledCount = 1; muzzledCount <= Math.Min((totalDays - 1) / (muzzleDulation + 1), muzzledA.Length - 1); muzzledCount++)
            {
                var occupied = 1 + (muzzledCount * (muzzleDulation + 1));
                if (totalDays - occupied < 0 || totalDays - occupied >= nonmuzzledA.Length)
                {
                    continue;
                }

                var result = muzzledPrefixSum[muzzledCount + 1] + nonMuzzledPrefixSum[totalDays - occupied];
                max = Math.Max(max, result);
            }

            for (int muzzledCount = 1; muzzledCount < muzzledA.Length; muzzledCount++)
            {
                var covered = muzzledA.Length - muzzledCount;
                if (covered > muzzledCount * muzzleDulation || covered < (muzzledCount - 1) * muzzleDulation)
                {
                    continue;
                }

                max = Math.Max(max, muzzledPrefixSum[muzzledCount] + nonMuzzledPrefixSum[nonMuzzledPrefixSum.Length - 1]);
            }

            if (muzzledA.Length >= 1)
            {
                max = Math.Max(max, muzzledA[0] + nonMuzzledPrefixSum[nonMuzzledPrefixSum.Length - 1]);
            }

            yield return max;
        }
    }
}
