using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound62.Extensions;
using EducationalCodeforcesRound62.Questions;

namespace EducationalCodeforcesRound62.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray().Select(i => i - 1).ToArray();

            var day = 0;
            var currentPage = 0;

            while (currentPage < a.Length)
            {
                var toRead = a[currentPage++];

                while (toRead >= currentPage)
                {
                    toRead = Math.Max(toRead, a[currentPage++]);
                }

                day++;
            }

            yield return day;
        }
    }
}
