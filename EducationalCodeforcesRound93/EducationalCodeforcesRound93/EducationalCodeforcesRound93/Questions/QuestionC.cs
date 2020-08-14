using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound93.Extensions;
using EducationalCodeforcesRound93.Questions;

namespace EducationalCodeforcesRound93.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                _ = inputStream.ReadInt();
                var a = inputStream.ReadLine().Select(c => c - '0' - 1).ToArray();
                var prefixSum = new int[a.Length + 1];

                for (int i = 0; i < a.Length; i++)
                {
                    prefixSum[i + 1] = prefixSum[i] + a[i];
                }

                var counts = new long[a.Length * 10 + 1];

                foreach (var p in prefixSum)
                {
                    counts[p + a.Length]++;
                }

                long result = 0;

                foreach (var count in counts)
                {
                    result += count * (count - 1) / 2;
                }

                yield return result;
            }
        }
    }
}
