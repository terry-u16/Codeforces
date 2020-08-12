using System;
using Xunit;
using CodeforcesRound664Div1.Questions;
using System.Collections.Generic;
using System.Linq;

namespace CodeforcesRound664Div1.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5 2 11
8 10 15 23 5", @"48")]
        [InlineData(@"20 2 16
20 5 8 2 18 16 2 16 16 1 5 16 2 13 6 16 4 17 21 7", @"195")]
        [InlineData(@"5 5 0
1 2 3 4 5", @"5")]
        [InlineData(@"5 5 2
1 2 3 4 5", @"8")]
        [InlineData(@"7 5 2
1 2 3 4 5 100 100", @"200")]
        [InlineData(@"3 1 5
100 100 100", @"200")]
        [InlineData(@"3 3 5
1 1 1", @"3")]
        [InlineData(@"3 3 5
100 100 100", @"100")]
        [InlineData(@"1 1 1
100", @"100")]
        [InlineData(@"1 1 1
1", @"1")]
        [InlineData(@"3 3 0
5 5 5", @"5")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 6 3
4 2 1
1 2 2
2 4 3
4 1 4
4 3 5
3 1 6", @"2")]
        [InlineData(@"5 5 1
1 4 1
5 1 2
2 5 3
4 3 4
3 2 5", @"1")]
        [InlineData(@"6 13 4
3 5 1
2 5 2
6 3 3
1 4 4
2 6 5
5 3 6
4 1 7
4 3 8
5 2 9
4 2 10
2 1 11
6 1 12
4 6 13", @"1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
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
