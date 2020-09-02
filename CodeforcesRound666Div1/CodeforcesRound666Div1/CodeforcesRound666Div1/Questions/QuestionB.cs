using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound666Div1.Extensions;
using CodeforcesRound666Div1.Questions;

namespace CodeforcesRound666Div1.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var a = inputStream.ReadIntArray();

                var lastT = -1;
                var lastHl = -1;

                while (true)
                {
                    var maxT = 0;
                    var maxTIndex = -1;
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (a[i] > maxT && i != lastHl)
                        {
                            maxT = a[i];
                            maxTIndex = i;
                        }
                    }

                    if (maxTIndex == -1)
                    {
                        yield return "HL";
                        break;
                    }

                    a[maxTIndex]--;
                    lastT = maxTIndex;

                    var maxHl = 0;
                    var maxHlIndex = -1;
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (a[i] > maxHl && i != lastT)
                        {
                            maxHl = a[i];
                            maxHlIndex = i;
                        }
                    }

                    if (maxHlIndex == -1)
                    {
                        yield return "T";
                        break;
                    }

                    a[maxHlIndex]--;
                    lastHl = maxHlIndex;
                }
            }
        }
    }
}
