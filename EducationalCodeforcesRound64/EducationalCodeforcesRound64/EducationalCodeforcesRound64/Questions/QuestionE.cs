using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using EducationalCodeforcesRound64.Extensions;
using EducationalCodeforcesRound64.Questions;

namespace EducationalCodeforcesRound64.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var p = inputStream.ReadIntArray();
            var indices = new int[p.Length + 1];
            for (int i = 0; i < p.Length; i++)
            {
                indices[p[i]] = i;
            }

            var lefts = new int[p.Length];
            var rights = new int[p.Length];
            var stack = new Stack<(int p, int index)>();
            stack.Push((n, -1));
            for (int i = 0; i < p.Length; i++)
            {
                while (stack.Peek().p < p[i])
                {
                    stack.Pop();
                }
                lefts[i] = stack.Peek().index;
                stack.Push((p[i], i));
            }

            stack.Clear();
            stack.Push((n, n));
            for (int i = p.Length - 1; i >= 0; i--)
            {
                while (stack.Peek().p < p[i])
                {
                    stack.Pop();
                }
                rights[i] = stack.Peek().index;
                stack.Push((p[i], i));
            }

            var pairs = 0;

            for (int i = 0; i < p.Length; i++)
            {
                var leftLength = i - lefts[i] - 1;
                var rightLength = rights[i] - i - 1;
                if (leftLength == 0 || rightLength == 0)
                {
                    continue;
                }

                if (leftLength < rightLength)
                {
                    pairs += Count(lefts[i] + 1, i, i + 1, rights[i], p[i], p, indices);
                }
                else
                {
                    pairs += Count(i + 1, rights[i], lefts[i] + 1, i, p[i], p, indices);
                }
            }

            yield return pairs;
        }

        int Count(int shortL, int shortR, int longL, int longR, int sum, int[] p, int[] indices)    // 半開区間
        {
            var result = 0;
            for (int i = shortL; i < shortR; i++)
            {
                var another = sum - p[i];
                if (another >= 0 && longL <= indices[another] && indices[another] < longR)
                {
                    result++;
                }
            }
            return result;
        }
    }
}
