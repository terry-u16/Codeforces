using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound668Div1.Extensions;
using CodeforcesRound668Div1.Questions;

namespace CodeforcesRound668Div1.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (n, k) = inputStream.ReadValue<int, int>();
                var s = inputStream.ReadLine();

                if (Check(s.ToCharArray(), n, k))
                {
                    yield return "YES";
                }
                else
                {
                    yield return "NO";
                }
            }
        }

        bool Check(char[] s, int n, int k)
        {
            var zeros = 0;
            var ones = 0;
            var wildcards = 0;

            for (int i = 0; i < s.Length - k; i++)
            {
                if (s[i] != '?' && s[i + k] == '?')
                {
                    s[i + k] = s[i];
                }
                else if (s[i] == '?' && s[i + k] != '?')
                {
                    s[i] = s[i + k];
                }
                else if (s[i] != s[i + k])
                {
                    return false;
                }
            }

            for (int i = 0; i < k; i++)
            {
                if (s[i] == '0')
                {
                    zeros++;
                }
                else if (s[i] == '1')
                {
                    ones++;
                }
                else
                {
                    wildcards++;
                }
            }

            if (!Check(zeros, ones, wildcards))
            {
                return false;
            }

            for (int i = k; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    zeros++;
                }
                else if (s[i] == '1')
                {
                    ones++;
                }
                else
                {
                    wildcards++;
                }

                if (s[i - k] == '0')
                {
                    zeros--;
                }
                else if (s[i - k] == '1')
                {
                    ones--;
                }
                else
                {
                    wildcards--;
                }

                if (!Check(zeros, ones, wildcards))
                {
                    return false;
                }
            }

            return true;
        }

        bool Check(int zeros, int ones, int wildcards)
        {
            var few = Math.Min(zeros, ones);
            var many = Math.Max(zeros, ones);
            if (few + wildcards < many)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
