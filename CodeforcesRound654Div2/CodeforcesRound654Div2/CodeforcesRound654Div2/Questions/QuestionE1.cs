using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound654Div2.Extensions;
using CodeforcesRound654Div2.Questions;

namespace CodeforcesRound654Div2.Questions
{
    public class QuestionE1 : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, p) = inputStream.ReadValue<int, int>();
            var candies = inputStream.ReadIntArray();
            Array.Sort(candies);
            var enemiesUnder = new int[4001];

            var cursor = 0;
            for (int i = 1; i < enemiesUnder.Length; i++)
            {
                enemiesUnder[i] += enemiesUnder[i - 1];
                while (cursor < candies.Length && candies[cursor] == i)
                {
                    enemiesUnder[i]++;
                    cursor++;
                }
            }

            var answers = new Queue<int>();
            for (int x = 1; x <= 2000; x++)
            {
                var ok = true;
                for (int wins = 0; wins < candies.Length; wins++)
                {
                    var choices = enemiesUnder[x + wins] - wins;
                    if (choices == 0 || choices % p == 0)
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                {
                    answers.Enqueue(x);
                }
            }

            yield return answers.Count;
            yield return string.Join(" ", answers);
        }
    }
}
