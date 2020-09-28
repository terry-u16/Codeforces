using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound670Div2.Extensions;
using CodeforcesRound670Div2.Questions;

namespace CodeforcesRound670Div2.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var a = inputStream.ReadLongArray();
                Array.Sort(a);

                var plus = 0;
                var zero = 0;
                var minus = 0;

                foreach (var ai in a)
                {
                    if (ai > 0)
                    {
                        plus++;
                    }
                    else if (ai < 0)
                    {
                        minus++;
                    }
                    else
                    {
                        zero++;
                    }
                }

                var result = long.MinValue;

                for (int i = 0; i <= 4; i++)
                {
                    var mul = 1L;
                    foreach (var ai in a.Reverse().Take(5 - i))
                    {
                        mul *= ai;
                    }
                    foreach (var ai in a.Take(i))
                    {
                        mul *= ai;
                    }
                    result = Math.Max(result, mul);
                }

                if (zero > 0)
                {
                    result = Math.Max(result, 0);
                }

                for (int takeMinus = 0; takeMinus <= 5; takeMinus++)
                {
                    var takePlus = 5 - takeMinus;
                    if (minus < takeMinus)
                    {
                        continue;
                    }
                    if (plus < takePlus)
                    {
                        continue;
                    }

                    var mul = 1L;
                    foreach (var ai in a.TakeWhile(ai => ai < 0).Reverse().Take(takeMinus))
                    {
                        mul *= ai;
                    }

                    foreach (var ai in a.SkipWhile(ai => ai < 0).Take(takePlus))
                    {
                        mul *= ai;
                    }

                    result = Math.Max(result, mul);
                }

                yield return result;
            }
        }
    }
}
