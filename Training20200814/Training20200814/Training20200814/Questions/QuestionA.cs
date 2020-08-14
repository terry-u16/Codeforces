using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200814.Algorithms;
using Training20200814.Collections;
using Training20200814.Extensions;
using Training20200814.Numerics;
using Training20200814.Questions;

namespace Training20200814.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var x = inputStream.ReadInt();
            if (x == 3 || x == 5 || x == 7)
            {
                yield return "YES";
            }
            else
            {
                yield return "NO";
            }
        }
    }
}
