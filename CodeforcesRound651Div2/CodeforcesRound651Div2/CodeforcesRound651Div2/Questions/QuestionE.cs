using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeforcesRound651Div2.Extensions;
using CodeforcesRound651Div2.Questions;

namespace CodeforcesRound651Div2.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var s = inputStream.ReadLine();
            var t = inputStream.ReadLine();

            if (s.Count(c => c == '1') != t.Count(c => c == '1'))
            {
                yield return -1;
            }
            else
            {
                var streakS = 0;
                var maxS = 0;
                var streakT = 0;
                var maxT = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != t[i])
                    {
                        if (s[i] == '1')
                        {
                            streakS++;
                        }
                        else
                        {
                            streakS = 0;
                        }
                        if (t[i] == '1')
                        {
                            streakT++;
                        }
                        else
                        {
                            streakT = 0;
                        }
                    }

                    maxS = Math.Max(maxS, streakS);
                    maxT = Math.Max(maxT, streakT);
                }

                yield return Math.Min(maxS, maxT);
            }
        }
    }
}
