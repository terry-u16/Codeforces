using CodeforcesRound642Div3.Questions;
using CodeforcesRound642Div3.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeforcesRound642Div3.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var times = inputStream.ReadInt();

            for (int t = 0; t < times; t++)
            {
                var (length, sum) = inputStream.ReadValue<long, long>();
                var count = Math.Min(length - 1, 2);
                yield return sum * count;
            }
        }
    }
}
