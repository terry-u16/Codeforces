using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeforcesRound644Div3.Extensions;
using CodeforcesRound644Div3.Questions;

namespace CodeforcesRound644Div3.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (n, m) = inputStream.ReadValue<int, int>();
                var a = new string[n];
                for (int i = 0; i < n; i++)
                {
                    a[i] = inputStream.ReadLine();
                }

                var charSets = Enumerable.Repeat(0, m).Select(_ => new HashSet<char>()).ToArray();

                var differCount = 0;
                bool ok = true;
                for (int cursor = 0; cursor < a[0].Length; cursor++)
                {
                    var counts = new int[26];
                    for (int i = 0; i < a.Length; i++)
                    {
                        charSets[cursor].Add(a[i][cursor]);
                    }

                    differCount += charSets[cursor].Count - 1;
                    if (differCount > m + n)
                    {
                        ok = false;
                    }
                }

                if (ok)
                {
                    yield return TryGetOutput(charSets, a);
                }
                else
                {
                    yield return -1;
                }
            }
        }

        string TryGetOutput(HashSet<char>[] charSets, string[] a)
        {
            foreach (var s in GenerateCandidates(charSets))
            {
                if (Check(a, s))
                {
                    return s;
                }
            }
            return "-1";
        }

        IEnumerable<string> GenerateCandidates(HashSet<char>[] charSets, string current = "")
        {
            var index = current.Length;
            if (index == charSets.Length)
            {
                yield return current;
            }
            else
            {
                foreach (var c in charSets[index])
                {
                    foreach (var s in GenerateCandidates(charSets, current + c))
                    {
                        yield return s;
                    }
                }
            }
        }

        bool Check(string[] a, string candidate)
        {
            foreach (var ai in a)
            {
                var count = 0;
                for (int i = 0; i < candidate.Length; i++)
                {
                    if (ai[i] != candidate[i])
                    {
                        count++;
                    }
                }
                if (count > 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
