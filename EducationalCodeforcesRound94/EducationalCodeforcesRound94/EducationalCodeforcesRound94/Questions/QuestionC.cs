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
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var s = inputStream.ReadLine();
                var x = inputStream.ReadInt();
                var result = new int[s.Length];

                for (int i = 0; i < result.Length; i++)
                {
                    var one = true;
                    if (i - x >= 0)
                    {
                        one &= s[i - x] == '1';
                    }
                    if (i + x < s.Length)
                    {
                        one &= s[i + x] == '1';
                    }
                    result[i] = one ? 1 : 0;
                }

                if (Check(s, result, x))
                {
                    yield return result.Join();
                }
                else
                {
                    yield return -1;
                }
            }
        }

        bool Check(string s, int[] w, int x)
        {
            for (int i = 0; i < s.Length; i++)
            {
                var one = false;
                if (i - x >= 0)
                {
                    one |= w[i - x] == 1;
                }
                if (i + x < s.Length)
                {
                    one |= w[i + x] == 1;
                }

                if ((s[i] == '1') ^ one)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
