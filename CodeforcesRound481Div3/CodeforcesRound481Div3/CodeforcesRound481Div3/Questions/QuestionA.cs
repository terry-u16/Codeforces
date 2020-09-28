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
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var a = io.ReadIntArray(n);
            var set = new HashSet<int>();

            var results = new Stack<int>();

            foreach (var ai in a.Reverse())
            {
                if (set.Add(ai))
                {
                    results.Push(ai);
                }
            }

            io.WriteLine(results.Count);
            io.WriteLine(results, ' ');
        }
    }
}
