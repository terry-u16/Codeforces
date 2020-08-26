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
            var a = inputStream.ReadIntArray();
            yield return Count(a, 0, a.Length);
        }

        long Count(int[] a, int left, int right)
        {
            if (left == right)
            {
                return 0;
            }
            else if (left + 1 == right)
            {
                return a[left] == 0 ? 0 : 1;
            }
            else
            {
                var nonZeros = CountNonZeros(a, left, right);
                var minIndex = GetMinIndex(a, left, right);
                var min = a[minIndex];
                long count = min;

                for (int i = left; i < right; i++)
                {
                    a[i] -= min;
                }

                count += Count(a, left, minIndex);
                count += Count(a, minIndex + 1, right);
                return Math.Min(nonZeros, count);
            }
        }

        int CountNonZeros(int[] a, int left, int right)
        {
            var count = 0;
            for (int i = left; i < right; i++)
            {
                if (a[i] > 0)
                {
                    count++;
                }
            }
            return count;
        }

        int GetMinIndex(int[] a, int left, int right)
        {
            var min = int.MaxValue;
            var index = -1;

            for (int i = left; i < right; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                    index = i;
                }
            }

            return index;
        }
    }
}
