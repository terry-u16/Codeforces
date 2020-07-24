using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound659Div1.Extensions;
using CodeforcesRound659Div1.Questions;

namespace CodeforcesRound659Div1.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                yield return SolveEach(inputStream.ReadInt(), inputStream.ReadLine(), inputStream.ReadLine());
            }
        }

        int SolveEach(int n, string a, string b)
        {
            const int Max = 20;
            var map = new int[Max, Max];

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > b[i])
                {
                    return -1;
                }
                else
                {
                    map[a[i] - 'a', b[i] - 'a']++;
                }
            }

            var count = 0;

            for (int target = 0; target < Max; target++)
            {
                for (int from = 0; from < target; from++)
                {
                    if (map[from, target] > 0)
                    {
                        count++;

                        for (int destination = 0; destination < Max; destination++)
                        {
                            map[target, destination] += map[from, destination];
                            map[from, destination] = 0;
                        }
                    }
                }
            }

            return count;
        }
    }
}
