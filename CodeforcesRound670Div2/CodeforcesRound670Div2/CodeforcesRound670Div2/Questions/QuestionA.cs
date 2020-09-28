using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound670Div2.Extensions;
using CodeforcesRound670Div2.Questions;

namespace CodeforcesRound670Div2.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var bucket = new int[105];
                var n = inputStream.ReadInt();
                var a = inputStream.ReadIntArray();

                foreach (var ai in a)
                {
                    bucket[ai]++;
                }

                var ma = int.MinValue;
                var mb = int.MinValue;

                for (int i = 0; i < bucket.Length; i++)
                {
                    if (mb == int.MinValue)
                    {
                        if (bucket[i] == 0)
                        {
                            ma = i;
                            mb = i;
                            break;
                        }
                        else if (bucket[i] == 1)
                        {
                            mb = i;
                        }
                    }
                    else
                    {
                        if (bucket[i] == 0)
                        {
                            ma = i;
                            break;
                        }
                    }
                }

                if (ma < 0)
                {
                    ma = 0;
                }
                if (mb < 0)
                {
                    mb = 0;
                }

                yield return ma + mb;
            }
        }
    }
}
