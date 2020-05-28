using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EducationalCodeforcesRound088Div2.Extensions;
using EducationalCodeforcesRound088Div2.Questions;

namespace EducationalCodeforcesRound088Div2.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (n, m, k) = inputStream.ReadValue<int, int, int>();
                var maxJoker = Math.Min(m, n / k);
                var remainingJoker = m - maxJoker;
                var otherJoker = (remainingJoker + (k - 2)) / (k - 1);
                yield return maxJoker - otherJoker;
            }
        }
    }
}
