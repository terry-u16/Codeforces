using System;
using Xunit;
using CodeforcesRound481Div3.Questions;
using System.Collections.Generic;
using System.Linq;

namespace CodeforcesRound481Div3.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"6
1 5 5 1 6 1", @"3
5 6 1")]
        [InlineData(@"5
2 4 2 4 4", @"2
2 4")]
        [InlineData(@"5
6 6 6 6 6", @"1
6")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
xxxiii", @"1")]
        [InlineData(@"5
xxoxx", @"0")]
        [InlineData(@"10
xxxxxxxxxx", @"8")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 6
10 15 12
1 9 12 23 26 37", @"1 1
1 9
2 2
2 13
3 1
3 12")]
        [InlineData(@"2 3
5 10000000000
5 6 9999999999", @"1 5
2 1
2 9999999994")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
24 21 14 10", @"3")]
        [InlineData(@"2
500 500", @"0")]
        [InlineData(@"3
14 5 1", @"-1")]
        [InlineData(@"5
1 3 6 9 12", @"1")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 5
2 1 -3", @"3")]
        [InlineData(@"2 4
-1 1", @"4")]
        [InlineData(@"4 10
2 4 1 2", @"2")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 2
10 4 10 15
1 2
4 3", @"0 0 1 2")]
        [InlineData(@"10 4
5 4 1 5 4 3 7 1 2 5
4 6
2 1
10 8
3 5", @"5 4 0 5 3 3 9 0 2 5")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = SplitByNewLine(question.Solve(input).Trim());

            Assert.Equal(outputs, answers);
        }

        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
