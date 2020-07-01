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
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (vanilla, chocolate, most, least) = inputStream.ReadValue<long, long, long, long>();
                var total = vanilla + chocolate;
                yield return least <= Math.Min(vanilla, chocolate) && most + least <= total ? "Yes" : "No";
            }
        }
    }
}
