using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound639Div2.Extensions;
using CodeforcesRound639Div2.Questions;

namespace CodeforcesRound639Div2.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadLong();
                var pyramids = 0;
                while (true)
                {
                    var next = Construct(n);
                    if (next == 0)
                    {
                        break;
                    }
                    else
                    {
                        pyramids++;
                        n -= next;
                    }
                }

                yield return pyramids;
            }
        }

        long Construct(long n)
        {
            long used = 0;
            long height = 0;

            while (true)
            {
                height++;
                var next = 3 * height - 1;
                if (used + next <= n)
                {
                    used += next;
                }
                else
                {
                    return used;
                }
            }
        }
    }
}
