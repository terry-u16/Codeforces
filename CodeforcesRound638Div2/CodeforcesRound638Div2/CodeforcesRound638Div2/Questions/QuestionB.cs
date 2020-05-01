using CodeforcesRound638Div2.Algorithms;
using CodeforcesRound638Div2.Collections;
using CodeforcesRound638Div2.Questions;
using CodeforcesRound638Div2.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeforcesRound638Div2.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var testCases = inputStream.ReadInt();

            for (int testCase = 0; testCase < testCases; testCase++)
            {
                var (arrayLength, loopLength) = inputStream.ReadValue<int, int>();
                var a = inputStream.ReadIntArray().ToArray();

                var counter = new Counter<int>();
                foreach (var ai in a)
                {
                    counter[ai]++;
                }

                if (counter.Count(m => m.Value > 0) > loopLength)
                {
                    yield return -1;
                }
                else
                {
                    var loop = new int[loopLength];
                    var loopCount = (int)counter.Sum(pair => pair.Value);
                    var index = 0;
                    foreach (var pair in counter)
                    {
                        loop[index++] = pair.Key;
                    }
                    for (int i = index; i < loop.Length; i++)
                    {
                        loop[i] = 1;
                    }

                    IEnumerable<int> allLoop = loop;
                    for (int i = 1; i < loopCount; i++)
                    {
                        allLoop = allLoop.Concat(loop);
                    }

                    yield return loopCount * loopLength;
                    yield return string.Join(" ", allLoop);
                }
            }
        }
    }
}
