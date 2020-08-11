using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound91.Extensions;
using EducationalCodeforcesRound91.Questions;

namespace EducationalCodeforcesRound91.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            (_, _) = inputStream.ReadValue<int, int>();
            var (fireballMana, fireballRange, berserkMana) = inputStream.ReadValue<long, int, long>();
            var initialPowers = inputStream.ReadIntArray();
            var todoPowers = inputStream.ReadIntArray();

            var ranges = new List<Range>();
            var todoIndex = 0;
            var left = 0;
            for (int i = 0; i < initialPowers.Length; i++)
            {
                if (todoIndex < todoPowers.Length && initialPowers[i] == todoPowers[todoIndex])
                {
                    var right = i;
                    if (right - left > 0)
                    {
                        ranges.Add(new Range(left, right));
                    }
                    left = i + 1;
                    todoIndex++;
                }
            }

            if (initialPowers.Length - left > 0)
            {
                ranges.Add(new Range(left, initialPowers.Length));
            }

            if (todoIndex < todoPowers.Length)
            {
                yield return -1;
                yield break;
            }

            long totalMana = 0;
            foreach (var range in ranges)
            {
                var maxPower = GetRangeMax(range, initialPowers);
                var canBerserkAll = (range.Left > 0 && initialPowers[range.Left - 1] > maxPower) || (range.Right < initialPowers.Length && initialPowers[range.Right] > maxPower);
                var minMana = long.MaxValue;
                for (int fireballCount = 0; fireballCount <= range.Length / fireballRange; fireballCount++)
                {
                    var berserkCount = range.Length - fireballRange * fireballCount;
                    if (berserkCount == range.Length && !canBerserkAll)
                    {
                        continue;
                    }

                    minMana = Math.Min(minMana, fireballCount * fireballMana + berserkCount * berserkMana);
                }

                if (minMana == long.MaxValue)
                {
                    yield return -1;
                    yield break;
                }
                else
                {
                    totalMana += minMana;
                }
            }

            yield return totalMana;
        }

        int GetRangeMax(Range range, int[] powers)
        {
            var max = int.MinValue;
            for (int i = range.Left; i < range.Right; i++)
            {
                max = Math.Max(max, powers[i]);
            }
            return max;
        }

        [StructLayout(LayoutKind.Auto)]
        struct Range
        {
            public int Left { get; }
            public int Right { get; }
            public int Length => Right - Left;

            public Range(int left, int right)
            {
                Left = left;
                Right = right;
            }

            public void Deconstruct(out int left, out int right) => (left, right) = (Left, Right);
            public override string ToString() => $"{nameof(Left)}: {Left}, {nameof(Right)}: {Right}";
        }
    }
}
