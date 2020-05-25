using EducationalCodeforcesRound87.Questions;
using EducationalCodeforcesRound87.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EducationalCodeforcesRound87.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var (needed, firstAlarm, snooze, toFallAsleep) = inputStream.ReadValue<long, long, long, long>();
                var totalSleep = firstAlarm;
                var totalElapsed = firstAlarm;

                if (needed <= firstAlarm)
                {
                    yield return totalSleep;
                }
                else if (snooze <= toFallAsleep)
                {
                    yield return -1;
                }
                else
                {
                    var snoozeTimes = (long)Math.Ceiling((decimal)(needed - totalSleep) / (snooze - toFallAsleep));
                    totalElapsed += snoozeTimes * snooze;
                    yield return totalElapsed;
                }
            }
        }
    }
}
