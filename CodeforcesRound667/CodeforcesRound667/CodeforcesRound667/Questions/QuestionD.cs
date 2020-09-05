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
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (n, s) = inputStream.ReadValue<long, int>();

                var result = 0L;
                while (Count(n) > s)
                {
                    var toAdd = FindToAdd(n);
                    result += toAdd;
                    n += toAdd;
                }
                yield return result;
            }
        }

        int Count(long n)
        {
            var result = 0;
            while (n > 0)
            {
                result += (int)(n % 10);
                n /= 10;
            }
            return result;
        }

        long FindToAdd(long n)
        {
            if (n == 0)
            {
                return 0;
            }
            else
            {
                var div = 10L;

                while (true)
                {
                    if (n % div != 0)
                    {
                        return div - (n % div);
                    }
                    else
                    {
                        div *= 10;
                    }
                }
            }
        }
    }
}
