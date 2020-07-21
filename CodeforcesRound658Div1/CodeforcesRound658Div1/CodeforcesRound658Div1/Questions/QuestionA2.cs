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
    public class QuestionA2 : AtCoderQuestionBase
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
                bool inverted = false;
                var count = 0;

                while (count < a.Length)
                {
                    var target = a.Length - count - 1;
                    var current = inverted ? a.Length - count / 2 - 1 : count / 2;

                    if ((a[current] ^ inverted) == b[target])
                    {
                        operations.Enqueue(0);
                    }

                    operations.Enqueue(target);

                    count++;
                    inverted ^= true;
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
