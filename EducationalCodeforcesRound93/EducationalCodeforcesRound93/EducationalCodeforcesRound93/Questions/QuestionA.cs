using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound93.Extensions;
using EducationalCodeforcesRound93.Questions;

namespace EducationalCodeforcesRound93.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                _ = inputStream.ReadInt();
                yield return SolveEach(inputStream.ReadIntArray());
            }
        }

        string SolveEach(int[] a)
        {
            if (a[0] + a[1] <= a[a.Length - 1])
            {
                return $"1 2 {a.Length}";
            }
            else
            {
                return "-1";
            }
        }
    }
}
