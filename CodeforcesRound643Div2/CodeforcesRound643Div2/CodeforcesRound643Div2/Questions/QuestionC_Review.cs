using CodeforcesRound643Div2.Questions;
using CodeforcesRound643Div2.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeforcesRound643Div2.Questions
{
    public class QuestionC_Review : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b, c, d) = inputStream.ReadValue<int, int, int, int>();
            var xyCount = new long[1000002];
            for (int x = a; x <= b; x++)
            {
                xyCount[x + b] += 1;
                xyCount[x + c + 1] -= 1;
            }

            for (int prefixSum = 0; prefixSum < 2; prefixSum++)
            {
                for (int i = 1; i < xyCount.Length; i++)
                {
                    xyCount[i] += xyCount[i - 1];
                }
            }

            long count = 0;
            for (int z = c; z <= d; z++)
            {
                count += xyCount[xyCount.Length - 1] - xyCount[z];
            }

            yield return count;
        }
    }
}

