using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EducationalCodeforcesRound088Div2.Extensions;
using EducationalCodeforcesRound088Div2.Questions;

namespace EducationalCodeforcesRound088Div2.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var (height, width, singleCost, doubleCost) = inputStream.ReadValue<int, int, int, int>();
                var squares = new char[height][];
                for (int row = 0; row < height; row++)
                {
                    squares[row] = inputStream.ReadLine().ToCharArray();
                }

                yield return GetCost(squares, singleCost, doubleCost);
            }
        }

        int GetCost(char[][] squares, int singleCost, int doubleCost)
        {
            if (singleCost * 2 <= doubleCost)
            {
                return GetSingleCost(squares, singleCost);
            }
            else
            {
                var height = squares.Length;
                var width = squares[0].Length;

                var cost = 0;
                for (int row = 0; row < height; row++)
                {
                    for (int column = 0; column + 1 < width; column++)
                    {
                        if (squares[row][column] == '.' && squares[row][column + 1] == '.')
                        {
                            cost += doubleCost;
                            squares[row][column] = '*';
                            squares[row][column + 1] = '*';
                        }
                    }
                }
                cost += GetSingleCost(squares, singleCost);
                return cost;
            }
        }

        int GetSingleCost(char[][] squares, int singleCost) => squares.Sum(row => row.Count(c => c == '.')) * singleCost;
    }
}
