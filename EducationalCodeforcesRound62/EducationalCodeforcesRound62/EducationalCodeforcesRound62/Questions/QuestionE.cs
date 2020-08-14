using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound62.Extensions;
using EducationalCodeforcesRound62.Questions;

namespace EducationalCodeforcesRound62.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.Mod = 998244353;
            var (n, k) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadIntArray();
            var evens = new int[(a.Length + 1) / 2];
            var odds = new int[a.Length / 2];

            for (int i = 0; i < a.Length; i++)
            {
                if (i % 2 == 0)
                {
                    evens[i / 2] = a[i];
                }
                else
                {
                    odds[i / 2] = a[i];
                }
            }

            yield return Count(evens, k) * Count(odds, k);
        }

        Modular Count(int[] a, int k)
        {
            var count = Modular.One;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == -1)
                {
                    var left = i - 1 >= 0 ? a[i - 1] : 0;
                    var right = i + 1 < a.Length ? a[i + 1] : 0;

                    if (right > 0)
                    {
                        if (left == right || left <= 0)
                        {
                            count *= k - 1;
                        }
                        else
                        {
                            count *= k - 2;
                        }
                    }
                    else
                    {
                        if (left == 0)
                        {
                            count *= k;
                        }
                        else
                        {
                            count *= k - 1;
                        }
                    }
                }
                else if ((i - 1 >= 0 && a[i - 1] == a[i]) || (i + 1 < a.Length && a[i + 1] == a[i]))
                {
                    count = 0;
                }
            }

            return count;
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
