using EducationalCodeforcesRound87.Questions;
using EducationalCodeforcesRound87.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EducationalCodeforcesRound87.Questions
{
    public class QuestionC2 : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var polygon = 2 * inputStream.ReadInt();
                var toAdd = polygon / 2 - 2;
                var angle = Math.PI * (polygon - 2) / polygon;
                a = 0.5 / Math.Sin(Math.PI / polygon);
                bx = 0.5 / Math.Tan(Math.PI / polygon);
                by = 0.5;

                var theta = calc(0, Math.PI / 4, 1e-8);
                yield return a * Math.Cos(theta) * 2;
            }
        }

        double a;
        double bx;
        double by;

        double F(double theta) => a * Math.Cos(theta) - (bx * Math.Sin(theta) + by * Math.Cos(theta));

        double calc(double a, double b, double eps)
        {
            int i = 0;
            double s = 0;

            while (!(Math.Abs(a - b) < eps))
            {
                i++;
                s = (a + b) / 2.0;
                if (F(s) * F(a) < 0) b = s;
                else a = s;
                if (i == 1000) break; // 1000回繰り返したら強制終了

            }
            return s;
        }
    }
}
