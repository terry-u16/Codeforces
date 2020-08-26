using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound94.Extensions;
using EducationalCodeforcesRound94.Questions;

namespace EducationalCodeforcesRound94.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var a = inputStream.ReadIntArray().Select(ai => ai - 1).ToArray();
                var prefixSums = Enumerable.Repeat(0, n).Select(_ => new int[a.Length + 1]).ToArray();

                for (int i = 0; i < a.Length; i++)
                {
                    prefixSums[a[i]][i + 1] = 1;
                }

                for (int i = 0; i < prefixSums.Length; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        prefixSums[i][j + 1] += prefixSums[i][j];
                    }
                }

                long result = 0L;

                for (int j = 1; j + 2 < a.Length; j++)
                {
                    for (int k = j + 1; k + 1 < a.Length; k++)
                    {
                        result += prefixSums[a[k]][j] * (prefixSums[a[j]][n] - prefixSums[a[j]][k + 1]);
                    }
                }

                yield return result;
            }
        }
    }
}
