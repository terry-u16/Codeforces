using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound660Div2.Extensions;
using CodeforcesRound660Div2.Questions;

namespace CodeforcesRound660Div2.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var result = new char[n];
                var wiped = 0;

                for (int i = 0; i < result.Length; i++)
                {
                    if (n - wiped > 0)
                    {
                        result[i] = '8';
                        wiped += 4;
                    }
                    else
                    {
                        result[i] = '9';
                    }
                }

                yield return result.Reverse().Join();
            }
        }
    }
}
