using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound658Div1.Extensions;
using CodeforcesRound658Div1.Questions;

namespace CodeforcesRound658Div1.Questions
{
    public class QuestionA1 : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var a = inputStream.ReadLine().Select(ai => ai == '1').ToArray();
                var b = inputStream.ReadLine().Select(bi => bi == '1').ToArray();
                var operations = new Queue<int>();

                for (int i = a.Length - 1; i >= 0; i--)
                {
                    if (a[0] == b[i])
                    {
                        operations.Enqueue(0);
                        Invert(a, 1);
                    }

                    operations.Enqueue(i);
                    Invert(a, i + 1);
                }

                yield return $"{operations.Count} {operations.Select(i => i + 1).Join(" ")}";
            }
        }

        void Invert(bool[] array, int exclusiveLast)
        {
            for (int i = 0; i < exclusiveLast; i++)
            {
                array[i] ^= true;
            }

            var temp = new bool[exclusiveLast];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = array[exclusiveLast - i - 1];
            }

            for (int i = 0; i < temp.Length; i++)
            {
                array[i] = temp[i];
            }
        }
    }
}
