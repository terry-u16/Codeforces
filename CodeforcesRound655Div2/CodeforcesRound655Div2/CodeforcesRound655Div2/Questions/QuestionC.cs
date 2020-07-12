using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound655Div2.Extensions;
using CodeforcesRound655Div2.Questions;

namespace CodeforcesRound655Div2.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var n = inputStream.ReadInt();
                var a = inputStream.ReadIntArray();

                var isOrdered = true;
                var sandwitched = false;
                var moreThanTwo = false;
                for (int i = 0; i < a.Length; i++)
                {
                    var index = i + 1;
                    var differs = a[i] != index;

                    if (isOrdered)
                    {
                        if (differs)
                        {
                            isOrdered = false;
                        }
                    }
                    else
                    {
                        if (!sandwitched)
                        {
                            if (!differs)
                            {
                                sandwitched = true;
                            }
                        }
                        else if (!moreThanTwo)
                        {
                            if (differs)
                            {
                                moreThanTwo = true;
                            }
                        }
                    }
                }

                if (isOrdered)
                {
                    yield return 0;
                }
                else if (!moreThanTwo)
                {
                    yield return 1;
                }
                else
                {
                    yield return 2;
                }
            }
        }
    }
}
