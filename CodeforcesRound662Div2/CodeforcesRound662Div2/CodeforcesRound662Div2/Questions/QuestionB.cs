using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound662Div2.Extensions;
using CodeforcesRound662Div2.Questions;

namespace CodeforcesRound662Div2.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            var (notEnough, doubles, quads) = Initialize(a);

            var queries = inputStream.ReadInt();
            for (int q = 0; q < queries; q++)
            {
                var (sign, length) = inputStream.ReadValue<char, int>();

                Update(notEnough, doubles, quads, length, sign == '+');

                if (quads.Count >= 2)
                {
                    yield return "YES";
                }
                else if (quads.Count == 1)
                {
                    var count = quads.First().Value;
                    if (count >= 8)
                    {
                        yield return "YES";
                    }
                    else if (count >= 6 && doubles.Count >= 1)
                    {
                        yield return "YES";
                    }
                    else if (doubles.Count >= 2)
                    {
                        yield return "YES";
                    }
                    else
                    {
                        yield return "NO";
                    }
                }
                else
                {
                    yield return "NO";
                }
            }
        }

        private static void Update(Dictionary<int, int> notEnough, Dictionary<int, int> doubles, Dictionary<int, int> quads, int length, bool added)
        {
            int count;
            if (quads.ContainsKey(length))
            {
                count = quads[length];
                quads.Remove(length);
            }
            else if (doubles.ContainsKey(length))
            {
                count = doubles[length];
                doubles.Remove(length);
            }
            else if (notEnough.ContainsKey(length))
            {
                count = notEnough[length];
                notEnough.Remove(length);
            }
            else
            {
                count = 0;
            }

            count += added ? 1 : -1;

            if (count >= 4)
            {
                quads.Add(length, count);
            }
            else if (count >= 2)
            {
                doubles.Add(length, count);
            }
            else
            {
                notEnough.Add(length, count);
            }
        }

        (Dictionary<int, int> notEnough, Dictionary<int, int> doubles, Dictionary<int, int> quads) Initialize(int[] lengths)
        {
            var count = new int[lengths.Max() + 1];
            foreach (var length in lengths)
            {
                count[length]++;
            }

            var quads = new Dictionary<int, int>();
            var doubles = new Dictionary<int, int>();
            var notEnough = new Dictionary<int, int>();

            for (int l = 0; l < count.Length; l++)
            {
                if (count[l] >= 4)
                {
                    quads.Add(l, count[l]);
                }
                else if (count[l] >= 2)
                {
                    doubles.Add(l, count[l]);
                }
                else if (count[l] > 0)
                {
                    notEnough.Add(l, count[l]);
                }
            }

            return (notEnough, doubles, quads);
        }
    }
}
