using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound79.Extensions;
using EducationalCodeforcesRound79.Questions;

namespace EducationalCodeforcesRound79.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (stackSize, deliveryCount) = inputStream.ReadValue<int, int>();
                var stack = inputStream.ReadIntArray().Select(i => i - 1).ToArray();
                var toDeliver = inputStream.ReadIntArray().Select(i => i - 1).ToArray();
                var popped = new bool[stackSize];
                var poppedCount = 0;

                long seconds = 0;
                var nextDeliver = 0;
                for (int i = 0; i < stack.Length; i++)
                {
                    popped[stack[i]] = true;
                    if (nextDeliver < toDeliver.Length && toDeliver[nextDeliver] == stack[i])
                    {
                        seconds += 2 * poppedCount + 1;
                        nextDeliver++;

                        while (nextDeliver < toDeliver.Length && popped[toDeliver[nextDeliver]])
                        {
                            seconds++;
                            nextDeliver++;
                            poppedCount--;
                        }
                    }
                    else
                    {
                        poppedCount++;
                    }
                }
                yield return seconds;
            }
        }
    }
}
