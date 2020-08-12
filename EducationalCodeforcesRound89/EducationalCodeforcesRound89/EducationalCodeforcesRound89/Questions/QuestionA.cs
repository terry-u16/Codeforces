using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound89.Extensions;
using EducationalCodeforcesRound89.Questions;

namespace EducationalCodeforcesRound89.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (sticks, diamonds) = inputStream.ReadValue<int, int>();

                if (2 * sticks < diamonds)
                {
                    yield return sticks;
                }
                else if (2 * diamonds < sticks)
                {
                    yield return diamonds;
                }
                else
                {
                    yield return (sticks + diamonds) / 3;
                }
            }
        }
    }
}
