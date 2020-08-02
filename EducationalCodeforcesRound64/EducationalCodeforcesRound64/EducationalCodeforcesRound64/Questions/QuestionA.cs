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
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var isFinite = true;
            var count = 0;
            for (int i = 0; i + 1 < a.Length; i++)
            {
                if (a[i] + a[i + 1] == 5)
                {
                    isFinite = false;
                    break;
                }
                else
                {
                    var polygon = a[i] == 1 ? a[i + 1] : a[i];

                    count += polygon + 1;
                    if (a[i] == 1 && a[i + 1] == 2 && i - 1 >= 0 && a[i - 1] == 3)
                    {
                        count -= 1;
                    }
                }
            }

            if (isFinite)
            {
                yield return "Finite";
                yield return count;
            }
            else
            {
                yield return "Infinite";
            }
        }
    }
}
