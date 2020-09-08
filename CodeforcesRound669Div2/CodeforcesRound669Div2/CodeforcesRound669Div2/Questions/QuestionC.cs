using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound669Div2.Extensions;
using CodeforcesRound669Div2.Questions;

namespace CodeforcesRound669Div2.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var results = new int[n];
            var largestIndex = 0;

            for (int i = 1; i < n; i++)
            {
                yield return $"? {largestIndex + 1} {i + 1}";
                var left = inputStream.ReadInt();
                if (left == -1)
                {
                    yield break;
                }
                yield return $"? {i + 1} {largestIndex + 1}";
                var right = inputStream.ReadInt();
                if (right == -1)
                {
                    yield break;
                }

                if (left > right)
                {
                    results[largestIndex] = left;
                    largestIndex = i;
                }
                else
                {
                    results[i] = right;
                }
            }

            results[largestIndex] = n;
            yield return $"! {results.Join(" ")}";
        }
    }
}
