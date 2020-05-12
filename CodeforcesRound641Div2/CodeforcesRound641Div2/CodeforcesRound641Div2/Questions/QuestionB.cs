using CodeforcesRound641Div2.Questions;
using CodeforcesRound641Div2.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeforcesRound641Div2.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var times = inputStream.ReadInt();
            for (int t = 0; t < times; t++)
            {
                _ = inputStream.ReadInt();
                var models = inputStream.ReadIntArray();

                var counts = new int[models.Length];
                for (int i = models.Length - 1; i >= 0; i--)
                {
                    var index = i + 1;
                    var max = 0;
                    for (int mul = index * 2; mul <= models.Length; mul += index)
                    {
                        if (models[i] < models[mul - 1])
                        {
                            max = Math.Max(max, counts[mul - 1]);
                        }
                    }
                    counts[i] = 1 + max;
                }
                yield return counts.Max();
            }
        }
    }
}
