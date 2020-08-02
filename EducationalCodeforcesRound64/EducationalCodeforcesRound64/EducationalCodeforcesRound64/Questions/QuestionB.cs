using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound64.Extensions;
using EducationalCodeforcesRound64.Questions;

namespace EducationalCodeforcesRound64.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var s = inputStream.ReadLine();
                var counts = new int[26];
                foreach (var c in s)
                {
                    counts[c - 'a']++;
                }

                var resultSet = new List<char>();
                for (char c = 'a'; c <= 'z'; c++)
                {
                    if (counts[c - 'a'] > 0)
                    {
                        resultSet.Add(c);
                    }
                }

                var result = "";
                for (int i = 1; i < resultSet.Count; i += 2)
                {
                    result += Enumerable.Repeat(resultSet[i], counts[resultSet[i] - 'a']).Join();
                }

                for (int i = 0; i < resultSet.Count; i += 2)
                {
                    result += Enumerable.Repeat(resultSet[i], counts[resultSet[i] - 'a']).Join();
                }

                var ok = true;
                for (int i = 0; i + 1 < result.Length; i++)
                {
                    if (Math.Abs(result[i] - result[i + 1]) == 1)
                    {
                        ok = false;
                        break;
                    }
                }

                if (!ok)
                {
                    result = "";
                    for (int i = 1; i < resultSet.Count; i += 2)
                    {
                        result += Enumerable.Repeat(resultSet[i], counts[resultSet[i] - 'a']).Join();
                    }

                    for (int i = resultSet.Count % 2 == 0 ? resultSet.Count - 2 : resultSet.Count - 1; i >= 0; i -= 2)
                    {
                        result += Enumerable.Repeat(resultSet[i], counts[resultSet[i] - 'a']).Join();
                    }

                    ok = true;
                    for (int i = 0; i + 1 < result.Length; i++)
                    {
                        if (Math.Abs(result[i] - result[i + 1]) == 1)
                        {
                            ok = false;
                            break;
                        }
                    }
                }

                yield return ok ? result : "No answer";
            }
        }
    }
}
