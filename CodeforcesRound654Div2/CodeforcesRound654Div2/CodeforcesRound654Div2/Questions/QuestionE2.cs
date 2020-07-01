using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound654Div2.Extensions;
using CodeforcesRound654Div2.Questions;

namespace CodeforcesRound654Div2.Questions
{
    public class QuestionE2 : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, p) = inputStream.ReadValue<int, int>();
            var candies = inputStream.ReadIntArray();
            Array.Sort(candies);

            var minX = 0;
            var maxX = int.MaxValue;
            for (int i = 0; i < candies.Length; i++)
            {
                minX = Math.Max(minX, candies[i] - i);
                if (i + p - 1 < candies.Length)
                {
                    maxX = Math.Min(maxX, candies[i + p - 1] - i - 1);
                }
            }

            var answers = maxX >= minX ? Enumerable.Range(minX, maxX - minX + 1).ToArray() : new int[0];

            yield return answers.Length;
            yield return string.Join(" ", answers);
        }
    }
}
