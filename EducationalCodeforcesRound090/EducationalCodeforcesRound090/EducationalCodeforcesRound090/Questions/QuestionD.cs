using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound090.Extensions;
using EducationalCodeforcesRound090.Questions;

namespace EducationalCodeforcesRound090.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                _ = inputStream.ReadInt();
                var a = inputStream.ReadLongArray();
                long sum = 0;
                for (int i = 0; i < a.Length; i += 2)
                {
                    sum += a[i];
                }

                var diffA = new long[a.Length / 2];
                var diffB = new long[(a.Length - 1) / 2];
                for (int i = 0; i < diffA.Length; i++)
                {
                    diffA[i] = a[2 * i + 1] - a[2 * i];
                }
                for (int i = 0; i < diffB.Length; i++)
                {
                    diffB[i] = a[2 * i + 1] - a[2 * (i + 1)];
                }

                yield return sum + Math.Max(GetMaxSub(diffA), GetMaxSub(diffB));
            }
        }

        long GetMaxSub(long[] diff)
        {
            long max = 0;
            long s = 0;
            for (int i = 0; i < diff.Length; i++)
            {
                s = Math.Max(s + diff[i], diff[i]);
                max = Math.Max(max, s);
            }
            return max;
        }
    }
}
