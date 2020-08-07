using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound662Div2.Extensions;
using CodeforcesRound662Div2.Questions;

namespace CodeforcesRound662Div2.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width) = inputStream.ReadValue<int, int>();
            var map = new char[height + 2][];
            map[0] = Enumerable.Repeat('_', width + 2).ToArray();
            map[height + 1] = Enumerable.Repeat('_', width + 2).ToArray();
            for (int i = 0; i < height; i++)
            {
                map[i + 1] = ("_" + inputStream.ReadLine() + "_").ToCharArray();
            }

            yield return Count(map);
        }

        long Count(char[][] colors)
        {
            const int Inf = 1 << 28;
            var height = colors.Length;
            var width = colors[0].Length;
            var distances = Enumerable.Repeat(0, height).Select(_ => new int[width]).ToArray();
            var todo = new Queue<(int row, int column, char color)>();

            var diffs = new (int dr, int dc)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    if (colors[row][column] != '_')
                    {
                        distances[row][column] = Inf;
                    }
                    else
                    {
                        distances[row][column] = 0;
                    }
                }
            }

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    foreach (var diff in diffs)
                    {
                        var nextRow = row + diff.dr;
                        var nextColumn = column + diff.dc;

                        if (unchecked((uint)nextRow < height && (uint)nextColumn < width) && distances[nextRow][nextColumn] == Inf && colors[row][column] != colors[nextRow][nextColumn])
                        {
                            distances[nextRow][nextColumn] = 1;
                            todo.Enqueue((nextRow, nextColumn, colors[nextRow][nextColumn]));
                        }
                    }
                }
            }


            while (todo.Count > 0)
            {
                var current = todo.Dequeue();

                foreach (var diff in diffs)
                {
                    var nextRow = current.row + diff.dr;
                    var nextColumn = current.column + diff.dc;

                    if (unchecked((uint)nextRow < height && (uint)nextColumn < width) && distances[nextRow][nextColumn] == Inf && colors[nextRow][nextColumn] == current.color)
                    {
                        distances[nextRow][nextColumn] = distances[current.row][current.column] + 1;
                        todo.Enqueue((nextRow, nextColumn, current.color));
                    }
                }
            }

            long result = 0;
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    result += distances[row][column];
                }
            }

            return result;
        }
    }
}
