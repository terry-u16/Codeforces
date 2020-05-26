using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CodeforcesRound645Div._2.Extensions;
using CodeforcesRound645Div._2.Questions;
using Microsoft.Win32.SafeHandles;

namespace CodeforcesRound645Div._2.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (months, vacation) = inputStream.ReadValue<int, long>();
            var daysPerMonths = inputStream.ReadIntArray();
            daysPerMonths = daysPerMonths.Concat(daysPerMonths).ToArray();

            long days = 0;
            var lastMonth = -1;
            for (int month = 0; month < daysPerMonths.Length; month++)
            {
                if (days + daysPerMonths[month] < vacation)
                {
                    days += daysPerMonths[month];
                }
                else
                {
                    break;
                }

                lastMonth = month;
            }

            // 0月頭～
            long maxHugs = 0;
            long lastHugs = 0;

            for (int month = 0; month <= lastMonth; month++)
            {
                lastHugs += GetHugCount(daysPerMonths[month]);
            }
            lastHugs += GetHugCount(vacation - days);
            days = vacation - days;
            maxHugs = lastHugs;
            if (days == daysPerMonths[lastMonth + 1])
            {
                days = 0;
                lastMonth++;
            }

            // ～n月終わり
            var beginMonth = 0;
            var beginDay = 0;
            
            for (int month = lastMonth + 1; month < daysPerMonths.Length; month++)
            {
                long hugs = lastHugs;
                var proceed = daysPerMonths[month] - days;
                hugs += GetHugCount(days + 1, daysPerMonths[month]);

                while (proceed > 0)
                {
                    var proceedLocal = Math.Min(proceed, daysPerMonths[beginMonth] - beginDay);
                    hugs -= GetHugCount(beginDay, beginDay + proceedLocal);
                    if (beginDay + proceedLocal == daysPerMonths[beginMonth])
                    {
                        beginMonth++;
                        beginDay = 0;
                    }
                    else
                    {
                        beginDay += (int)proceedLocal;
                    }
                    proceed -= proceedLocal;
                }

                days = 0;
                maxHugs = Math.Max(maxHugs, hugs);
            }

            yield return maxHugs;
        }

        long GetHugCount(long endDay) => ((endDay + 1) * endDay) / 2;

        long GetHugCount(long beginDay, long endDay) => GetHugCount(endDay) - GetHugCount(beginDay - 1);
    }
}
