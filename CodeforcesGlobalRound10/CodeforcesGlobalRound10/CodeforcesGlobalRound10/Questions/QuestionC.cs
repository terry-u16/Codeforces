using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesGlobalRound10.Extensions;
using CodeforcesGlobalRound10.Questions;

namespace CodeforcesGlobalRound10.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                _ = inputStream.ReadIntArray();
                var heights = inputStream.ReadIntArray();
                long operations = 0;
                var currentHeight = heights[0];

                for (int i = 1; i < heights.Length; i++)
                {
                    if (currentHeight > heights[i])
                    {
                        operations += currentHeight - heights[i];
                    }

                    currentHeight = heights[i];
                }

                yield return operations;
            }
        }
    }
}
