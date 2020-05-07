using CodeforcesTestingRound016.Algorithms;
using CodeforcesTestingRound016.Collections;
using CodeforcesTestingRound016.Questions;
using CodeforcesTestingRound016.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeforcesTestingRound016.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var t = inputStream.ReadInt();
            for (int i = 0; i < t; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                yield return a + b;
            }
        }
    }
}
