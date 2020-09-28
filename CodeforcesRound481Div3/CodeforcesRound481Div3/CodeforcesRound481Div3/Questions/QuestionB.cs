using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound481Div3.Questions;

namespace CodeforcesRound481Div3.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var s = io.ReadString();

            var streak = 0;
            var removed = 0;

            foreach (var c in s)
            {
                if (c == 'x')
                {
                    streak++;

                    if (streak >= 3)
                    {
                        removed++;
                    }
                }
                else
                {
                    streak = 0;
                }
            }

            io.WriteLine(removed);
        }
    }
}
