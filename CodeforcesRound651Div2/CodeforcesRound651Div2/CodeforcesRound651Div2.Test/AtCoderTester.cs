using System;
using Xunit;
using CodeforcesRound651Div2.Questions;
using System.Collections.Generic;
using System.Linq;

namespace CodeforcesRound651Div2.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2
3
5", @"1
2")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7
1
2
3
4
5
6
12", @"FastestFinger
Ashishgup
Ashishgup
FastestFinger
Ashishgup
FastestFinger
Ashishgup")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 2
1 2 3 4", @"1")]
        [InlineData(@"4 3
1 2 3 4", @"2")]
        [InlineData(@"5 3
5 3 4 2 6", @"2")]
        [InlineData(@"6 4
5 3 50 2 4 5", @"3")]
        [InlineData(@"4 3
2 2 2 1", @"2")]
        [InlineData(@"4 4
2 1 2 1", @"1")]
        [InlineData(@"4 4
2 1 1 2", @"2")]
        [InlineData(@"5 5
2 1 1 1 2", @"1")]
        [InlineData(@"5 5
2 1 1 2 1", @"2")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
010000
000001", @"1")]
        [InlineData(@"10
1111100000
0000011111", @"5")]
        [InlineData(@"8
10101010
01010101", @"1")]
        [InlineData(@"10
1111100000
1111100001", @"-1")]
        [InlineData(@"10
1111100000
0010011110", @"4")]
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
