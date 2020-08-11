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
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var s = inputStream.ReadLine();

                var rocks = s.Count(c => c == 'R');
                var scissors = s.Count(c => c == 'S');
                var papers = s.Count(c => c == 'P');

                if (rocks > scissors && rocks > papers)
                {
                    yield return Enumerable.Repeat('P', s.Length).Join();
                }
                else if (scissors > rocks && scissors > papers)
                {
                    yield return Enumerable.Repeat('R', s.Length).Join();
                }
                else if (papers > rocks && papers > scissors)
                {
                    yield return Enumerable.Repeat('S', s.Length).Join();
                }
                else if (rocks > scissors || rocks > papers)
                {
                    yield return Enumerable.Repeat('P', s.Length).Join();
                }
                else if (scissors > rocks || scissors > papers)
                {
                    yield return Enumerable.Repeat('R', s.Length).Join();
                }
                else if (papers > rocks || papers > scissors)
                {
                    yield return Enumerable.Repeat('S', s.Length).Join();
                }
                else
                {
                    yield return Enumerable.Repeat('R', s.Length).Join();
                }
            }
        }
    }
}
