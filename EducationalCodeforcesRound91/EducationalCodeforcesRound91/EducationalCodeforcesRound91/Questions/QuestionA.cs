using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound91.Extensions;
using EducationalCodeforcesRound91.Questions;

namespace EducationalCodeforcesRound91.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                foreach (var output in SolveEach(inputStream))
                {
                    yield return output;
                }
            }
        }

        private IEnumerable<object> SolveEach(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var p = inputStream.ReadIntArray();

            var first = 0;
            var second = -1;

            for (int i = 1; i < p.Length; i++)
            {
                if (second == -1)
                {
                    if (p[first] < p[i])
                    {
                        second = i;
                    }
                    else
                    {
                        first = i;
                    }
                }
                else
                {
                    if (p[second] > p[i])
                    {
                        yield return "YES";
                        yield return $"{first + 1} {second + 1} {i + 1}";
                        yield break;
                    }
                    else
                    {
                        second = i;
                    }
                }
            }

            yield return "NO";
        }
    }
}
