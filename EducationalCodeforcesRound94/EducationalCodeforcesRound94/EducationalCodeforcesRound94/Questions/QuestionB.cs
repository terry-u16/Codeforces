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
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (myCapacity, followerCapacity) = inputStream.ReadValue<int, int>();
                var (swordCount, axCount) = inputStream.ReadValue<int, int>();
                var (swordWeight, axWeight) = inputStream.ReadValue<long, long>();

                long max = 0;

                for (int mySword = 0; mySword <= swordCount; mySword++)
                {
                    var mySwordWeight = mySword * swordWeight;
                    if (mySwordWeight > myCapacity)
                    {
                        break;
                    }

                    var myAx = Math.Min((myCapacity - mySwordWeight) / axWeight, axCount);
                    var remainSword = swordCount - mySword;
                    var remainAx = axCount - myAx;

                    if (swordWeight < axWeight)
                    {
                        var followerSword = Math.Min(followerCapacity / swordWeight, remainSword);
                        var followerAx = Math.Min((followerCapacity - followerSword * swordWeight) / axWeight, remainAx);
                        max = Math.Max(max, mySword + myAx + followerSword + followerAx);
                    }
                    else
                    {
                        var followerAx = Math.Min(followerCapacity / axWeight, remainAx);
                        var followerSword = Math.Min((followerCapacity - followerAx * axWeight) / swordWeight, remainSword);
                        max = Math.Max(max, mySword + myAx + followerSword + followerAx);
                    }
                }

                yield return max;
            }
        }
    }
}
