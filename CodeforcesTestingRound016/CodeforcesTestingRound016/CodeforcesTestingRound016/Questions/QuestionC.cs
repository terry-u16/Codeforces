using CodeforcesTestingRound016.Algorithms;
using CodeforcesTestingRound016.Collections;
using CodeforcesTestingRound016.Questions;
using CodeforcesTestingRound016.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeforcesTestingRound016.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                var movements = inputStream.ReadLine();
                var current = new Position(0, 0);

                var visited = new HashSet<Path>();
                var time = 0;

                foreach (var direction in movements)
                {
                    Path path;
                    switch (direction)
                    {
                        case 'S':
                            current.Y--;
                            path = new Path(current, false);
                            break;
                        case 'N':
                            path = new Path(current, false);
                            current.Y++;
                            break;
                        case 'W':
                            current.X--;
                            path = new Path(current, true);
                            break;
                        case 'E':
                            path = new Path(current, true);
                            current.X++;
                            break;
                        default:
                            path = new Path();
                            break;
                    }

                    var hasVisited = !visited.Add(path);
                    if (hasVisited)
                    {
                        time += 1;
                    }
                    else
                    {
                        time += 5;
                    }
                }

                yield return time;
            }
        }

        struct Position : IEquatable<Position>
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override bool Equals(object obj)
            {
                return obj is Position position && Equals(position);
            }

            public bool Equals(Position other)
            {
                return X == other.X &&
                       Y == other.Y;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = 1861411795;
                    hashCode = hashCode * -1521134295 + X.GetHashCode();
                    hashCode = hashCode * -1521134295 + Y.GetHashCode();
                    return hashCode;
                }
            }

            public static bool operator ==(Position left, Position right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Position left, Position right)
            {
                return !(left == right);
            }
        }

        struct Path : IEquatable<Path>
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool AlongX { get; set; }

            public Path(Position position, bool alongX)
            {
                X = position.X;
                Y = position.Y;
                AlongX = alongX;
            }

            public override bool Equals(object obj)
            {
                return obj is Path position && Equals(position);
            }

            public bool Equals(Path other)
            {
                return X == other.X &&
                       Y == other.Y &&
                       AlongX == other.AlongX;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = 1643694913;
                    hashCode = hashCode * -1521134295 + X.GetHashCode();
                    hashCode = hashCode * -1521134295 + Y.GetHashCode();
                    hashCode = hashCode * -1521134295 + AlongX.GetHashCode();
                    return hashCode;
                }
            }

            public static bool operator ==(Path left, Path right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Path left, Path right)
            {
                return !(left == right);
            }
        }

    }
}
