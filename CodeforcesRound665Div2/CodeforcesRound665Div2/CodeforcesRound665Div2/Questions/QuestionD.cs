using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound665Div2.Extensions;
using CodeforcesRound665Div2.Questions;

namespace CodeforcesRound665Div2.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        List<long> childCount;
        List<int>[] tree;
        int[] parents;
        long[] childCountArray;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var nodeCount = inputStream.ReadInt();
                tree = Enumerable.Repeat(0, nodeCount).Select(_ => new List<int>()).ToArray();
                childCount = new List<long>();
                parents = Enumerable.Repeat(-1, nodeCount).ToArray();
                childCountArray = Enumerable.Repeat(1L, nodeCount).ToArray();

                for (int i = 0; i < nodeCount - 1; i++)
                {
                    var (u, v) = inputStream.ReadValue<int, int>();
                    u--;
                    v--;
                    tree[u].Add(v);
                    tree[v].Add(u);
                }

                var primesCount = inputStream.ReadInt();
                var primes = inputStream.ReadIntArray();
                Array.Sort(primes, (a, b) => b - a);

                Dfs(0);
                childCount = new List<long>(childCountArray.Skip(1));

                for (int i = 0; i < childCount.Count; i++)
                {
                    childCount[i] *= nodeCount - childCount[i];
                }

                childCount.Sort((a, b) => Math.Sign(b - a));

                var result = Modular.Zero;
                var over = primesCount - (nodeCount - 1);
                var primeIndex = 0;

                if (over > 0)
                {
                    var mul = Modular.One;
                    for (int i = 0; i <= over; i++)
                    {
                        mul *= primes[primeIndex++];
                    }
                    result += mul * childCount[0];
                }
                else
                {
                    result += new Modular(primes[primeIndex++]) * childCount[0];
                }

                for (int i = 1; i < childCount.Count; i++)
                {
                    if (primeIndex < primes.Length)
                    {
                        result += new Modular(primes[primeIndex++]) * childCount[i];
                    }
                    else
                    {
                        result += childCount[i];
                    }
                }

                yield return result;
            }
        }

        void Dfs(int start)
        {
            var going = new Stack<int>();
            var backing = new Stack<int>();
            going.Push(start);
            backing.Push(start);

            while (going.Count > 0)
            {
                var current = going.Pop();

                foreach (var next in tree[current])
                {
                    if (next == parents[current])
                    {
                        continue;
                    }

                    going.Push(next);
                    backing.Push(next);
                    parents[next] = current;
                }
            }

            while (backing.Count > 0)
            {
                var current = backing.Pop();
                if (parents[current] >= 0)
                {
                    childCountArray[parents[current]] += childCountArray[current];
                }
            }
        }

        public struct Modular : IEquatable<Modular>, IComparable<Modular>
        {
            private const int DefaultMod = 1000000007;
            public int Value { get; }
            public static int Mod { get; set; } = DefaultMod;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Modular(long value)
            {
                if (unchecked((ulong)value) < unchecked((ulong)Mod))
                {
                    Value = (int)value;
                }
                else
                {
                    Value = (int)(value % Mod);
                    if (Value < 0)
                    {
                        Value += Mod;
                    }
                }
            }

            private Modular(int value) => Value = value;
            public static Modular Zero => new Modular(0);
            public static Modular One => new Modular(1);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Modular operator +(Modular a, Modular b)
            {
                var result = a.Value + b.Value;
                if (result >= Mod)
                {
                    result -= Mod;    // 剰余演算を避ける
                }
                return new Modular(result);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Modular operator -(Modular a, Modular b)
            {
                var result = a.Value - b.Value;
                if (result < 0)
                {
                    result += Mod;    // 剰余演算を避ける
                }
                return new Modular(result);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Modular operator *(Modular a, Modular b) => new Modular((long)a.Value * b.Value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Modular operator /(Modular a, Modular b) => a * Pow(b.Value, Mod - 2);

            // 需要は不明だけど一応
            public static bool operator ==(Modular left, Modular right) => left.Equals(right);
            public static bool operator !=(Modular left, Modular right) => !(left == right);
            public static bool operator <(Modular left, Modular right) => left.CompareTo(right) < 0;
            public static bool operator <=(Modular left, Modular right) => left.CompareTo(right) <= 0;
            public static bool operator >(Modular left, Modular right) => left.CompareTo(right) > 0;
            public static bool operator >=(Modular left, Modular right) => left.CompareTo(right) >= 0;

            public static implicit operator Modular(long a) => new Modular(a);
            public static explicit operator int(Modular a) => a.Value;
            public static explicit operator long(Modular a) => a.Value;

            public static Modular Pow(int a, int n)
            {
                if (n == 0)
                {
                    return Modular.One;
                }
                else if (n == 1)
                {
                    return a;
                }
                else if (n > 0)
                {
                    var p = Pow(a, n >> 1);             // m / 2
                    return p * p * Pow(a, n & 0x01);    // m % 2
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(n), $"べき指数{nameof(n)}は0以上の整数でなければなりません。");
                }
            }

            public override string ToString() => Value.ToString();
            public override bool Equals(object obj) => obj is Modular ? Equals((Modular)obj) : false;
            public bool Equals(Modular other) => Value == other.Value;
            public int CompareTo(Modular other) => Value.CompareTo(other.Value);
            public override int GetHashCode() => Value.GetHashCode();
        }

    }
}
