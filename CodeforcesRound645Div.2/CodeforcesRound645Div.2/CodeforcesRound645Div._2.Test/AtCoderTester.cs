using System;
using Xunit;
using CodeforcesRound645Div._2.Questions;
using System.Collections.Generic;
using System.Linq;

namespace CodeforcesRound645Div._2.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5
1 1
1 3
2 2
3 3
5 3", @"1
2
2
5
8")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
5
1 1 2 2 1
6
2 3 4 5 6 7
6
1 5 4 5 1 9
5
1 2 3 5 6", @"6
1
6
4")]
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

        [Theory]
        [InlineData(@"3 2
1 3 1", @"5")]
        [InlineData(@"3 6
3 3 3", @"12")]
        [InlineData(@"5 6
4 2 3 1 3", @"15")]
        [InlineData(@"5 5
5 5 5 5 5", @"15")]
        [InlineData(@"1 1
1", @"1")]
        [InlineData(@"4 5
1 1 2 1", @"6")]
        [InlineData(@"3 5
2 2 2", @"8")]
        [InlineData(@"3 3
5 2 2", @"12")]
        [InlineData(@"3 1
5 2 2", @"5")]
        [InlineData(@"1 1
5", @"5")]
        [InlineData(@"5 2
2 2 2 2 2", @"3")]
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
