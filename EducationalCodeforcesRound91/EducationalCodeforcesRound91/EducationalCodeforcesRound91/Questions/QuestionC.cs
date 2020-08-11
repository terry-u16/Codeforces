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
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (n, restriction) = inputStream.ReadValue<int, int>();
                var skills = inputStream.ReadLongArray();

                Array.Sort(skills);
                Array.Reverse(skills);

                var teams = 0;
                var members = 0;
                foreach (var skill in skills)
                {
                    members++;
                    if (members * skill >= restriction)
                    {
                        teams++;
                        members = 0;
                    }
                }

                yield return teams;
            }
        }
    }
}
