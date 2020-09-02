using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound639Div2.Extensions;
using CodeforcesRound639Div2.Questions;

namespace CodeforcesRound639Div2.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        int[,] colors;
        bool[,] canEnter;
        int height;
        int width;
        Diff[] diffs = new Diff[] { new Diff(-1, 0), new Diff(1, 0), new Diff(0, -1), new Diff(0, 1) };

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            (height, width) = inputStream.ReadValue<int, int>();
            colors = new int[height, width];
            canEnter = new bool[height, width];

            var allWhite = true;
            for (int row = 0; row < height; row++)
            {
                var s = inputStream.ReadLine();

                for (int column = 0; column < width; column++)
                {
                    if (s[column] == '#')
                    {
                        canEnter[row, column] = true;
                        allWhite = false;
                    }
                    else
                    {
                        canEnter[row, column] = false;
                    }
                }
            }

            if (allWhite)
            {
                yield return 0;
                yield break;
            }

            int color = 1;

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (CanEnter(row, column) && colors[row, column] == 0)
                    {
                        Paint(row, column, color++);
                    }
                }
            }

            color--;
            if (!CheckNotSandwitched())
            {
                yield return -1;
            }
            else if (!CheckVacant())
            {
                yield return -1;
            }
            else
            {
                yield return color;;
            }
        }

        void Paint(int row, int column, int color)
        {
            colors[row, column] = color;
            foreach (var diff in diffs)
            {
                var dr = diff.Dr;
                var dc = diff.Dc;
                var nextRow = row + dr;
                var nextColumn = column + dc;

                if (CanEnter(nextRow, nextColumn) && colors[nextRow, nextColumn] == 0)
                {
                    Paint(nextRow, nextColumn, color);
                }
            }
        }

        bool CanEnter(int row, int column) => unchecked((uint)row < height && (uint)column < width) && canEnter[row, column];

        bool CheckNotSandwitched()
        {
            for (int row = 0; row < height; row++)
            {
                var last = 0;
                var hasNonZero = false;

                for (int column = 0; column < width; column++)
                {
                    if (colors[row, column] > 0)
                    {
                        if (hasNonZero && last != colors[row, column])
                        {
                            return false;
                        }
                        else
                        {
                            hasNonZero = true;
                        }
                    }
                    last = colors[row, column];
                }
            }

            for (int column = 0; column < width; column++)
            {
                var last = 0;
                var hasNonZero = false;

                for (int row = 0; row < height; row++)
                {
                    if (colors[row, column] > 0)
                    {
                        if (hasNonZero && last != colors[row, column])
                        {
                            return false;
                        }
                        else
                        {
                            hasNonZero = true;
                        }
                    }
                    last = colors[row, column];
                }
            }

            return true;
        }

        bool CheckVacant()
        {
            var hasVacantRow = false;
            for (int row = 0; row < height; row++)
            {
                var vacant = true;
                for (int column = 0; column < width; column++)
                {
                    if (colors[row, column] > 0)
                    {
                        vacant = false;
                        break;
                    }
                }
                if (vacant)
                {
                    hasVacantRow = true;
                    break;
                }
            }

            var hasVacantColumn = false;
            for (int column = 0; column < width; column++)
            {
                var vacant = true;
                for (int row = 0; row < height; row++)
                {
                    if (colors[row, column] > 0)
                    {
                        vacant = false;
                        break;
                    }
                }
                if (vacant)
                {
                    hasVacantColumn = true;
                    break;
                }
            }

            return !(hasVacantRow ^ hasVacantColumn);
        }

        [StructLayout(LayoutKind.Auto)]
        struct Diff
        {
            public int Dr { get; }
            public int Dc { get; }

            public Diff(int dr, int dc)
            {
                Dr = dr;
                Dc = dc;
            }

            public void Deconstruct(out int dr, out int dc) => (dr, dc) = (Dr, Dc);
            public override string ToString() => $"{nameof(Dr)}: {Dr}, {nameof(Dc)}: {Dc}";
        }
    }
}
