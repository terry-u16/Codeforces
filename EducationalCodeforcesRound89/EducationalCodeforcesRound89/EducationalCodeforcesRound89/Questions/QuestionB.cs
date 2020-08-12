using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound89.Extensions;
using EducationalCodeforcesRound89.Questions;


namespace EducationalCodeforcesRound89.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (n, x, operations) = inputStream.ReadValue<int, int, int>();

                var range = new Range(x, x);

                for (int i = 0; i < operations; i++)
                {
                    var (l, r) = inputStream.ReadValue<int, int>();

                    if (l <= range.Left && range.Right <= r)
                    {
                        range = new Range(l, r);
                    }
                    else if (l <= range.Left && range.Left <= r)
                    {
                        range = new Range(l, range.Right);
                    }
                    else if (l <= range.Right && range.Right <= r)
                    {
                        range = new Range(range.Left, r);
                    }
                }

                yield return range.Length;
            }
        }

        [StructLayout(LayoutKind.Auto)]
        struct Range
        {
            public int Left { get; }
            public int Right { get; }
            public int Length => Right - Left + 1;

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
