using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound671Div2.Questions;

namespace CodeforcesRound671Div2.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var tests = io.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var n = io.ReadInt();
                var killjoy = io.ReadInt();
                var ratings = io.ReadIntArray(n);

                if (ratings.All(r => r == killjoy))
                {
                    io.WriteLine(0);
                }
                else if (ratings.Any(r => r == killjoy))
                {
                    io.WriteLine(1);
                }
                else if (ratings.Sum() == killjoy * n)
                {
                    io.WriteLine(1);
                }
                else
                {
                    io.WriteLine(2);
                }
            }
        }
    }
}
