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
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var tests = io.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                SolveEach(io);
            }
        }

        void SolveEach(IOManager io)
        {
            var n = io.ReadInt();
            var s = io.ReadCharSpan();

            if (s.Length % 2 == 0)
            {
                for (int i = 1; i < s.Length; i += 2)
                {
                    if ((s[i] - '0') % 2 == 0)
                    {
                        io.WriteLine(2);
                        return;
                    }
                }

                io.WriteLine(1);
            }
            else
            {
                for (int i = 0; i < s.Length; i += 2)
                {
                    if ((s[i] - '0') % 2 == 1)
                    {
                        io.WriteLine(1);
                        return;
                    }
                }

                io.WriteLine(2);
            }
        }
    }
}
