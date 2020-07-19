using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound657Div2.Extensions;
using CodeforcesRound657Div2.Questions;
using System.Diagnostics.CodeAnalysis;

namespace CodeforcesRound657Div2.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (n, m) = inputStream.ReadValue<long, long>();
                var flowers = new Flower[m];

                for (int i = 0; i < m; i++)
                {
                    var (a, b) = inputStream.ReadValue<long, long>();
                    flowers[i] = new Flower(a, b);
                }

                if (t < tests - 1)
                {
                    inputStream.ReadLine();
                }

                Array.Sort(flowers);

                var prefixA = new long[m + 1];
                for (int i = 0; i < flowers.Length; i++)
                {
                    prefixA[i + 1] = prefixA[i] + flowers[i].A;
                }

                long maxHappiness = 0;

                if (n <= m)
                {
                    maxHappiness = prefixA[n];
                }

                if (m == 1)
                {
                    maxHappiness = flowers[0].Buy(n);
                }
                else
                {
                    foreach (var flower in flowers)
                    {
                        var others = BoundaryBinarySearch(i => flowers[i].A > flower.B, -1, flowers.Length) + 1;
                        var countThis = n - others;

                        if (flower.A > flower.B)
                        {
                            countThis++;
                        }

                        if (countThis <= 0)
                        {
                            continue;
                        }

                        var happiness = flower.Buy(countThis) + prefixA[others];
                        if (flower.A > flower.B)
                        {
                            happiness -= flower.A;
                        }

                        maxHappiness = Math.Max(maxHappiness, happiness);
                    }

                }
                yield return maxHappiness;
            }
        }

        public static int BoundaryBinarySearch(Predicate<int> predicate, int ok, int ng)
        {
            // めぐる式二分探索
            while (Math.Abs(ok - ng) > 1)
            {
                int mid = (ok + ng) / 2;
                if (predicate(mid))
                {
                    ok = mid;
                }
                else
                {
                    ng = mid;
                }
            }
            return ok;
        }


        [StructLayout(LayoutKind.Auto)]
        struct Flower : IComparable<Flower>
        {
            public long A { get; }
            public long B { get; }

            public Flower(long arg1, long arg2)
            {
                A = arg1;
                B = arg2;
            }

            public long Buy(long n) => A + (n - 1) * B;

            public void Deconstruct(out long arg1, out long arg2) => (arg1, arg2) = (A, B);
            public override string ToString() => $"{nameof(A)}: {A}, {nameof(B)}: {B}";

            public int CompareTo(Flower other) => Math.Sign(other.A - A);
        }
    }
}
