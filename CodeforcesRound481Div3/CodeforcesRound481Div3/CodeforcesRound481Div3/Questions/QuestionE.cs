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
    public class QuestionE : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var stops = io.ReadInt();
            var capacity = io.ReadInt();
            var max = 0;
            var min = 0;
            var current = 0;

            for (int i = 0; i < stops; i++)
            {
                current += io.ReadInt();

                max = Math.Max(max, current);
                min = Math.Min(min, current);
            }

            max -= min;
            min -= min;

            if (max > capacity)
            {
                io.WriteLine(0);
            }
            else
            {
                io.WriteLine(capacity - max + 1);
            }
        }
    }
}
