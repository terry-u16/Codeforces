using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound79.Extensions;
using EducationalCodeforcesRound79.Questions;
using System.Diagnostics;

namespace EducationalCodeforcesRound79.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const int MaxPresent = 1000000;
            Modular.Mod = 998244353;
            var childrenCount = inputStream.ReadInt();
            var wanted = new int[MaxPresent];
            var total = 0;
            var wants = new int[childrenCount][];


            for (int child = 0; child < childrenCount; child++)
            {
                var ka = inputStream.ReadIntArray();
                total += ka[0];
                for (int i = 1; i < ka.Length; i++)
                {
                    wanted[ka[i] - 1]++;
                }
                wants[child] = ka.Skip(1).Select(i => i - 1).ToArray();
            }

            var result = Modular.Zero;
            var childrenInverseMod = 1 / new Modular(childrenCount);
            var probabilities = new Modular[MaxPresent];

            for (int present = 0; present < wanted.Length; present++)
            {
                probabilities[present] = wanted[present] * childrenInverseMod;
            }

            for (int child = 0; child < wants.Length; child++)
            {
                var inv = 1 / new Modular(wants[child].Length);
                foreach (var present in wants[child])
                {
                    result += probabilities[present] * inv;
                }
            }

            yield return result * childrenInverseMod;
        }

        struct Modular : IEquatable<Modular>, IComparable<Modular>
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
                else if (n >= 2)
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
