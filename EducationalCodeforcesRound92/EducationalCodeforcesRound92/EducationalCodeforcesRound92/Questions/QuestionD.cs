using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound92.Extensions;
using EducationalCodeforcesRound92.Questions;

namespace EducationalCodeforcesRound92.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                yield return SolveEach(inputStream);
            }
        }

        long SolveEach(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<long, long>();
            var (leftA, rightA) = inputStream.ReadValue<long, long>();
            var (leftB, rightB) = inputStream.ReadValue<long, long>();

            if (rightA > rightB)
            {
                (leftA, leftB) = (leftB, leftA);
                (rightA, rightB) = (rightB, rightA);
            }

            var lengthA = rightA - leftA;
            var lengthB = rightB - leftB;

            if (rightA <= leftB)
            {
                long sum = 0;
                long operations = 0;
                long min = long.MaxValue;

                for (int i = 0; i < n; i++)
                {
                    // Aを伸ばす
                    if (sum + lengthB <= k)
                    {
                        sum += lengthB;
                        operations += rightB - rightA;
                    }
                    else
                    {
                        operations += leftB - rightA + (k - sum);
                        min = Math.Min(min, operations);
                        break;
                    }

                    min = Math.Min(min, operations + Math.Max((k - sum) * 2, 0));

                    if (sum == k)
                    {
                        break;
                    }

                    // Bを伸ばす
                    var toAdd = leftB - leftA;
                    if (sum + toAdd <= k)
                    {
                        sum += toAdd;
                        operations += toAdd;
                    }
                    else
                    {
                        operations += k - sum;
                        min = Math.Min(min, operations);
                        break;
                    }

                    min = Math.Min(min, operations + Math.Max((k - sum) * 2, 0));

                    if (sum == k)
                    {
                        break;
                    }
                }

                return min;
            }
            else if (leftA <= leftB)
            {
                var covered = rightA - leftB;
                long sum = covered * n;
                long operations = 0;
                if (sum >= k)
                {
                    return operations;
                }

                var notCovered = rightB - rightA + leftB - leftA;
                if (notCovered * n >= k - sum)
                {
                    return k - sum;
                }
                else
                {
                    sum += notCovered * n;
                    operations += notCovered * n;
                    return operations + Math.Max((k - sum) * 2, 0);
                }
            }
            else
            {
                var covered = rightA - leftA;
                long sum = covered * n;
                long operations = 0;
                if (sum >= k)
                {
                    return operations;
                }

                var notCovered = rightB - rightA + leftA - leftB;
                if (notCovered * n >= k - sum)
                {
                    return k - sum;
                }
                else
                {
                    sum += notCovered * n;
                    operations += notCovered * n;
                    return operations + Math.Max((k - sum) * 2, 0);
                }
            }
        }
    }
}
