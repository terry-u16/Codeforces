using System;
using Xunit;
using CodeforcesGlobalRound9.Questions;
using System.Collections.Generic;
using System.Linq;

namespace CodeforcesGlobalRound9.Test
{
    public class AtCoderTester
    {
        //[Theory]
        //[InlineData(@"", @"")]
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
        [InlineData(@"4
3
1 2 3
4
3 1 2 4
3
2 3 1
6
2 4 6 1 3 5", @"YES
YES
NO
YES")]
        [InlineData(@"1
5
1 2 3 4 5", @"YES")]
        [InlineData(@"1
5
3 4 5 1 2", @"NO")]
        [InlineData(@"1
5
3 4 1 2 5", @"YES")]
        [InlineData(@"1
6
1 3 2 5 4 6", @"YES")]
        [InlineData(@"1
2
2 1", @"NO")]
        [InlineData(@"1
2
1 2", @"YES")]
        [InlineData(@"1
6
1 2 3 4 5 6", @"YES")]
        [InlineData(@"1
5
5 4 3 2 1", @"NO")]
        [InlineData(@"1
5
1 4 3 2 5", @"YES")]
        [InlineData(@"1
5
1 4 3 5 2", @"YES")]
        [InlineData(@"1
5
1 2 3 5 4", @"YES")]
        [InlineData(@"1
5
3 2 1 4 5", @"YES")]
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
