using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EducationalCodeforcesRound088Div2.Extensions;
using EducationalCodeforcesRound088Div2.Questions;

namespace EducationalCodeforcesRound088Div2.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (hotTemp, coldTemp, targetTemp) = inputStream.ReadValue<long, long, long>();

                if (targetTemp >= hotTemp)
                {
                    yield return 1;
                }
                else if (targetTemp * 2 <= (hotTemp + coldTemp))
                {
                    yield return 2;
                }
                else
                {
                    long times = (hotTemp - targetTemp) / (2 * targetTemp - hotTemp - coldTemp);
                    var lastTemp = new Fraction(hotTemp * (times + 1) + coldTemp * times, 2 * times + 1);
                    times += 1;
                    var temp = new Fraction(hotTemp * (times + 1) + coldTemp * times, 2 * times + 1);
                    var lastTempTuubun = lastTemp.Numerator * temp.Denominator;
                    var tempTuubun = temp.Numerator * lastTemp.Denominator;
                    var targetTempTuubun = targetTemp * lastTemp.Denominator * temp.Denominator;
                    if (Math.Abs(lastTempTuubun - targetTempTuubun) <= Math.Abs(tempTuubun - targetTempTuubun))
                    {
                        yield return 2 * times - 1;
                    }
                    else
                    {
                        yield return 2 * times + 1;
                    }
                }
            }
        }

        public struct Fraction : IEquatable<Fraction>, IComparable<Fraction>
        {
            /// <summary>分子</summary>
            public long Numerator { get; }
            /// <summary>分母</summary>
            public long Denominator { get; }

            public static Fraction Nan => new Fraction(0, 0);
            public static Fraction PositiveInfinity => new Fraction(1, 0);
            public static Fraction NegativeInfinity => new Fraction(-1, 0);
            public bool IsNan => Numerator == 0 && Denominator == 0;
            public bool IsInfinity => Numerator != 0 && Denominator == 0;
            public bool IsPositiveInfinity => Numerator > 0 && Denominator == 0;
            public bool IsNegativeInfinity => Numerator < 0 && Denominator == 0;

            /// <summary>
            /// <c>Fraction</c>クラスの新しいインスタンスを生成します。
            /// </summary>
            /// <param name="numerator">分子</param>
            /// <param name="denominator">分母</param>
            public Fraction(long numerator, long denominator)
            {
                if (denominator == 0)
                {
                    Numerator = Math.Sign(numerator);
                    Denominator = 0;
                }
                else if (numerator == 0)
                {
                    Numerator = 0;
                    Denominator = 1;
                }
                else
                {
                    var sign = Math.Sign(numerator) * Math.Sign(denominator);
                    numerator = Math.Abs(numerator);
                    denominator = Math.Abs(denominator);
                    var gcd = Gcd(numerator, denominator);
                    Numerator = sign * numerator / gcd;
                    Denominator = denominator / gcd;
                }
            }

            public static Fraction operator +(Fraction left, Fraction right)
            {
                if (left.IsNan || right.IsNan)
                {
                    return Nan;
                }
                else if (left.IsInfinity || right.IsInfinity)
                {
                    if (!right.IsInfinity)
                    {
                        return left;
                    }
                    else if (!left.IsInfinity)
                    {
                        return right;
                    }
                    else
                    {
                        return new Fraction(left.Numerator + right.Numerator, 0);
                    }
                }
                else
                {
                    var lcm = Lcm(left.Denominator, right.Denominator);
                    return new Fraction(left.Numerator * (lcm / left.Denominator) + right.Numerator * (lcm / right.Denominator), lcm);
                }
            }
            public static Fraction operator -(Fraction left, Fraction right) => left + -right;
            public static Fraction operator *(Fraction left, Fraction right) => new Fraction(left.Numerator * right.Numerator, left.Denominator * right.Denominator);
            public static Fraction operator /(Fraction left, Fraction right) => new Fraction(left.Numerator * right.Denominator, left.Denominator * right.Numerator);
            public static Fraction operator +(Fraction right) => right;
            public static Fraction operator -(Fraction right) => new Fraction(-right.Numerator, right.Denominator);
            public static bool operator ==(Fraction left, Fraction right) => left.Equals(right);
            public static bool operator !=(Fraction left, Fraction right) => !(left == right);
            public static implicit operator double(Fraction right)
            {
                if (right.IsNan)
                {
                    return double.NaN;
                }
                else if (right.IsPositiveInfinity)
                {
                    return double.PositiveInfinity;
                }
                else if (right.IsNegativeInfinity)
                {
                    return double.NegativeInfinity;
                }
                else
                {
                    return (double)right.Numerator / right.Denominator;
                }
            }

            public override string ToString()
            {
                if (IsNan)
                {
                    return "NaN";
                }
                else if (IsPositiveInfinity)
                {
                    return "Inf";
                }
                else if (IsNegativeInfinity)
                {
                    return "-Inf";
                }
                else
                {
                    return $"{Numerator}/{Denominator} = {(double)Numerator/Denominator:0.00}";
                }
            }

            public override bool Equals(object obj) => obj is Fraction fraction && Equals(fraction);
            public bool Equals(Fraction other) => Numerator == other.Numerator && Denominator == other.Denominator;
            public int CompareTo(Fraction other) => ((double)this).CompareTo(other);

            static long Gcd(long a, long b)
            {
                if (a <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(a), $"{nameof(b)}は正の整数である必要があります。");
                }
                if (b <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(b), $"{nameof(b)}は正の整数である必要があります。");
                }
                if (a < b)
                {
                    (a, b) = (b, a);
                }

                while (b != 0)
                {
                    (a, b) = (b, a % b);
                }
                return a;
            }

            static long Lcm(long a, long b)
            {
                if (a <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(a), $"{nameof(b)}は正の整数である必要があります。");
                }
                if (b <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(b), $"{nameof(b)}は正の整数である必要があります。");
                }

                return a / Gcd(a, b) * b;
            }

        }

    }
}
