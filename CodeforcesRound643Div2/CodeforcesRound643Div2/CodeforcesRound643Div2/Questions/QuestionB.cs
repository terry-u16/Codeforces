using CodeforcesRound643Div2.Questions;
using CodeforcesRound643Div2.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeforcesRound643Div2.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                _ = inputStream.ReadInt();
                var inexperiences = inputStream.ReadIntArray();

                Array.Sort(inexperiences);

                var group = new Stack<int>();
                var groupCount = 0;

                foreach (var inexperience in inexperiences)
                {
                    group.Push(inexperience);
                    if (group.Count == group.Peek())
                    {
                        groupCount++;
                        group.Clear();
                    }
                }

                yield return groupCount;
            }
        }
    }
}
