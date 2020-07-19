using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound657Div2.Extensions;
using CodeforcesRound657Div2.Questions;
using System.Threading;
using System.Runtime.InteropServices.ComTypes;

namespace CodeforcesRound657Div2.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            const string Abacaba = "abacaba";

            for (int t = 0; t < tests; t++)
            {
                int n = inputStream.ReadInt();
                var s = inputStream.ReadLine();
                var composed = false;

                for (int start = 0; start < s.Length - 6; start++)
                {
                    var result = s.Substring(0, start).Replace('?', 'z') + Abacaba + s.Substring(start + Abacaba.Length).Replace('?', 'z');
                    var ok = true;

                    for (int offset = 0; offset < s.Length - 6; offset++)
                    {
                        if (offset == start)
                        {
                            for (int i = 0; i < Abacaba.Length; i++)
                            {
                                var c = s[start + i];
                                if (c != Abacaba[i] && c != '?')
                                {
                                    ok = false;
                                }
                            }
                        }
                        else
                        {
                            if (result.Substring(offset, Abacaba.Length) == Abacaba)
                            {
                                ok = false;
                            }
                        }
                    }

                    if (ok)
                    {
                        yield return "Yes";
                        yield return result;
                        composed = true;
                        break;
                    }
                }

                if (!composed)
                {
                    yield return "No";
                }

            }
        }
    }
}
