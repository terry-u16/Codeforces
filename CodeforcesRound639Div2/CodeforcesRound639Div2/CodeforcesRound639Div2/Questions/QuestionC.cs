using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound639Div2.Extensions;
using CodeforcesRound639Div2.Questions;

namespace CodeforcesRound639Div2.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var a = inputStream.ReadIntArray();
                var moved = new int[n];

                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] < 0)
                    {
                        a[i] += (-a[i] + n - 1) / n * n;
                    }

                    a[i] %= n;
                    moved[(i + a[i]) % n]++;
                }

                var vacant = false;
                foreach (var m in moved)
                {
                    if (m == 0)
                    {
                        vacant = true;
                        break;
                    }
                }

                if (vacant)
                {
                    yield return "NO";
                }
                else
                {
                    yield return "YES";
                }
            }
        }
    }
}
