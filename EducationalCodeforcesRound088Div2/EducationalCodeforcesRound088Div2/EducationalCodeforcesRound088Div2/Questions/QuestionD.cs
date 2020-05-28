using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EducationalCodeforcesRound088Div2.Extensions;
using EducationalCodeforcesRound088Div2.Questions;

namespace EducationalCodeforcesRound088Div2.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            var count = new int[n + 1, 61];
            for (int i = 0; i < a.Length; i++)
            {
                count[i + 1, a[i] + 30]++;
            }

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < 61; j++)
                {
                    count[i + 1, j] += count[i, j];
                }
            }

            for (int left = 0; left + 1 < a.Length; left++)
            {

            }

            int max = int.MinValue;
            int sum = 0;
            var taken = int.MinValue;
            var lastPlus = -1;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
                taken = Math.Max(taken, a[i]);
                max = Math.Max(max, sum - taken);
                if (a[i] > 0)
                {
                    lastPlus = i;
                }
                if (sum < 0)
                {
                    taken = int.MinValue;
                    sum = 0;
                    i = lastPlus - 1;
                }
            }

            yield return max;
        }
    }
}
