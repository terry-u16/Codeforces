using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound95.Extensions;
using EducationalCodeforcesRound95.Questions;

namespace EducationalCodeforcesRound95.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (x, y, k) = inputStream.ReadValue<long, long, long>();
                var coalSticks = y * k;
                var neededStick = coalSticks + k - 1;
                var delta = x - 1;
                var stickTrade = (neededStick + delta - 1) / delta;
                yield return stickTrade + k;
            }
        }
    }
}
