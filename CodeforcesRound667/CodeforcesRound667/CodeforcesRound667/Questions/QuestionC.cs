using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound667.Extensions;
using CodeforcesRound667.Questions;

namespace CodeforcesRound667.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (n, x, y) = inputStream.ReadValue<int, int, int>();
                var diff = y - x;

                for (int div = 1; div <= diff; div++)
                {
                    if (diff % div != 0 || diff / div + 1 > n)
                    {
                        continue;
                    }

                    var result = new List<int>();
                    for (int i = y; i > 0 && result.Count < n; i -= div)
                    {
                        result.Add(i);
                    }

                    for (int i = y + div; result.Count < n; i += div)
                    {
                        result.Add(i);
                    }

                    yield return result.Join(" ");
                    break;
                }
            }
        }
    }
}
