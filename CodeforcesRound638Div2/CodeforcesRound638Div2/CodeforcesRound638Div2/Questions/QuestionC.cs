using CodeforcesRound638Div2.Algorithms;
using CodeforcesRound638Div2.Collections;
using CodeforcesRound638Div2.Questions;
using CodeforcesRound638Div2.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeforcesRound638Div2.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var testCases = inputStream.ReadInt();

            for (int testCase = 0; testCase < testCases; testCase++)
            {
                var (_, k) = inputStream.ReadValue<int, int>();
                var s = string.Concat(inputStream.ReadLine().OrderBy(c => c).ToArray());

                if (k == 1)
                {
                    yield return s;
                    yield break;
                }
                else if (k == s.Length)
                {
                    yield return s[s.Length - 1];
                    yield break;
                }

                if (s[0] != s[k - 1])
                {
                    yield return s[k - 1];
                }
                else if (s[0] == s[s.Length - 1])
                {
                    yield return string.Concat(Enumerable.Repeat(s[0], (int)Math.Ceiling((double)s.Length / k)));
                }
                else if (s[k] != s[s.Length - 1])
                {
                    yield return s.Substring(k - 1);
                }
                else
                {
                    yield return s[0] + string.Concat(Enumerable.Repeat(s[k], (int)Math.Ceiling((double)(s.Length - k) / k)));
                }
            }
        }
    }
}
