using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeforcesRound644Div3.Extensions;
using CodeforcesRound644Div3.Questions;

namespace CodeforcesRound644Div3.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var strength = inputStream.ReadIntArray();
                Array.Sort(strength);
                var minDiff = int.MaxValue;
                for (int i = 0; i + 1 < strength.Length; i++)
                {
                    minDiff = Math.Min(minDiff, strength[i + 1] - strength[i]);
                }
                yield return minDiff;
            }
        }
    }
}
