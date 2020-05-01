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
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var t = inputStream.ReadInt();

            for (int i = 0; i < t; i++)
            {
                var n = inputStream.ReadInt();
                yield return Pow2(n) + Enumerable.Range(1, n / 2 - 1).Sum(m => Pow2(m)) - Enumerable.Range(n / 2, n / 2).Sum(m => Pow2(m));
            }
        }

        long Pow2(int n)
        {
            var result = 1;
            for (int i = 0; i < n; i++)
            {
                result *= 2;
            }
            return result;
        }
    }
}
