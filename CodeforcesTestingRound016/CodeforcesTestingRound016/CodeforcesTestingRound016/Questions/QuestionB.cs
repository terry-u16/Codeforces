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
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var a = inputStream.ReadIntArray();
                var b = inputStream.ReadIntArray();

                var isSquare = false;
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (a[i] == b[j] && a[(i + 1) % 2] + b[(j + 1) % 2] == a[i])
                        {
                            isSquare = true;
                        }
                    }
                }

                yield return isSquare ? "Yes" : "No";
            }
        }
    }
}
