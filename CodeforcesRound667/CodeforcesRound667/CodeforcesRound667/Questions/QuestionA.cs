﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound667.Extensions;
using CodeforcesRound667.Questions;

namespace CodeforcesRound667.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                var diff = Math.Abs(a - b);
                var count = (diff + 9) / 10;
                yield return count;
            }
        }
    }
}
