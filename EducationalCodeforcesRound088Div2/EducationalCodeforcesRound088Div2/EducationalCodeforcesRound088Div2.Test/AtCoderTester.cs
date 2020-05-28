using System;
using Xunit;
using EducationalCodeforcesRound088Div2.Questions;
using System.Collections.Generic;
using System.Linq;

namespace EducationalCodeforcesRound088Div2.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"4
8 3 2
4 2 4
9 6 3
42 0 7", @"3
0
1
0")]
        [InlineData(@"1
6 3 3", @"1")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
1 1 10 1
.
1 2 10 1
..
2 1 10 1
.
.
3 3 3 7
..*
*..
.*.", @"10
1
20
18")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
30 10 20
41 15 30
18 13 18", @"2
7
1")]
        [InlineData(@"1
30 0 19", @"3")]
        [InlineData(@"1
30 0 29", @"1")]
        [InlineData(@"1
30 0 0", @"2")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
5 -2 10 -1 4", @"6")]
        [InlineData(@"8
5 2 5 3 -30 -30 6 9", @"10")]
        [InlineData(@"3
-10 6 -15", @"0")]
        [InlineData(@"5
5 -2 5 -1 4", @"6")]
        [InlineData(@"5
5 -2 5 -1 -1", @"3")]
        [InlineData(@"5
5 -6 5 -1 -1", @"0")]
        [InlineData(@"5
5 -5 5 -1 -1", @"0")]
        [InlineData(@"5
6 -7 5 5 -1", @"9")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
