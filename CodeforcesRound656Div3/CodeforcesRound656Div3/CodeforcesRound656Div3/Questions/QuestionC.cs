using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound656Div3.Extensions;
using CodeforcesRound656Div3.Questions;

namespace CodeforcesRound656Div3.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var a = inputStream.ReadIntArray();
                var ascending = true;

                int answer;
                var last = int.MinValue;
                for (answer = a.Length - 1; answer >= 0; answer--)
                {
                    if (ascending)
                    {
                        if (a[answer] < last)
                        {
                            ascending = false;
                        }
                    }
                    else
                    {
                        if (a[answer] > last)
                        {
                            break;
                        }
                    }

                    last = a[answer];
                }

                yield return answer + 1;
            }
        }
    }
}
