using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound090.Extensions;
using EducationalCodeforcesRound090.Questions;

namespace EducationalCodeforcesRound090.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            var lowerDigits = new long[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int t = 0; t < tests; t++)
            {
                var (n, k) = inputStream.ReadValue<int, int>();

                var min = long.MaxValue;
                for (int offset = 0; offset < 10; offset++)
                {
                    var lowerSum = lowerDigits.Skip(offset).Take(k + 1).Sum();
                    var hasIncrement = offset + k + 1 > 10;
                    var needed = n - lowerSum;
                    if (needed >= 0 && needed % (k + 1) == 0)
                    {
                        min = Math.Min(min, GetUpper(needed / (k + 1), hasIncrement) + offset);
                    }
                }

                yield return min != long.MaxValue ? min : -1;
            }
        }

        long GetUpper(long needed, bool hasIncrement)
        {
            long digit = 10;
            long answer = 0;
            while (needed > 0)
            {
                if (digit == 10 && hasIncrement)
                {
                    var value = Math.Max(needed, 8);
                    needed -= value;
                    answer += value * digit;
                }
                else
                {
                    var value = Math.Max(needed, 9);
                    needed -= value;
                    answer += value * digit;
                }

                digit *= 10;
            }
            return answer;
        }
    }
}
