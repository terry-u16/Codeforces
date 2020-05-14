using CodeforcesRound642Div3.Questions;
using CodeforcesRound642Div3.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeforcesRound642Div3.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                long n = inputStream.ReadLong();
                long sum = 0;
                for (long distance = 1; distance * 2 < n; distance++)
                {
                    var edge0 = 2 * distance - 1;
                    var edge1 = 2 * distance + 1;
                    sum += distance * (edge1 * edge1 - edge0 * edge0);
                }
                yield return sum;
            }
        }
    }
}
