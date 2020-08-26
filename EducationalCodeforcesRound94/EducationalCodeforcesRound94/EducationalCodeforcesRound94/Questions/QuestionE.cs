using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound94.Extensions;
using EducationalCodeforcesRound94.Questions;

namespace EducationalCodeforcesRound94.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = new int[] { 0 }.Concat(inputStream.ReadIntArray()).Concat(new int[] { 0 }).ToArray();

            var wildCards = new bool[a.Length];
            var minOperations = Math.Min(EraseVertical(a, wildCards), EraseHorizontal(a, wildCards));
            var currentOperations = 0;

            while (true)
            {
                currentOperations++;
                var index = FindBottleNeckIndex(a, wildCards);

                if (index >= 0)
                {
                    wildCards[index] = true;
                    minOperations = Math.Min(minOperations, EraseHorizontal(a, wildCards) + currentOperations);
                }
                else
                {
                    break;
                }
            }

            yield return minOperations;
        }

        int FindBottleNeckIndex(int[] a, bool[] wildCards)
        {
            var max = 0;
            int index = -1;
            var neck = new int[a.Length];

            var current = 0;
            for (int i = 1; i + 1 < a.Length; i++)
            {
                if (!wildCards[i])
                {
                    var exists = Math.Max(a[i] - current, 0) + (wildCards[i + 1] ? 0 : Math.Max(a[i + 1] - a[i], 0));
                    var notExists = wildCards[i + 1] ? 0 : Math.Max(a[i + 1] - current, 0);
                    neck[i] = exists - notExists;
                    current = a[i];
                }
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (neck[i] > max)
                {
                    max = neck[i];
                    index = i;
                }
            }

            return index;
        }

        long EraseVertical(int[] a, bool[] wildCards)
        {
            var count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > 0 && !wildCards[i])
                {
                    count++;
                }
            }
            return count;
        }

        long EraseHorizontal(int[] a, bool[] wildCards)
        {
            var current = 0;
            long counts = 0L;

            for (int i = 0; i < a.Length; i++)
            {
                if (!wildCards[i])
                {
                    if (a[i] > current)
                    {
                        counts += a[i] - current;
                    }
                    current = a[i];
                }
            }

            return counts;
        }
    }
}
