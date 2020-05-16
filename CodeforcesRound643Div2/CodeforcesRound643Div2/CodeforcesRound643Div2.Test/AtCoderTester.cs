using System;
using Xunit;
using CodeforcesRound643Div2.Questions;
using System.Collections.Generic;
using System.Linq;

namespace CodeforcesRound643Div2.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"8
1 4
487 1
487 2
487 3
487 4
487 5
487 6
487 7", @"42
487
519
528
544
564
588
628")]
        [InlineData(@"1
1 1", @"1")]
        [InlineData(@"1
1 2", @"2")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
3
1 1 1
5
2 3 1 2 2", @"3
2")]
        [InlineData(@"1
3
1 1 2", @"2")]
        [InlineData(@"1
4
3 3 3 3", @"1")]
        [InlineData(@"1
4
3 3 3 2", @"1")]
        [InlineData(@"1
4
1 2 2 100000", @"2")]
        [InlineData(@"1
4
1 3 3 3", @"2")]
        [InlineData(@"1
4
1 2 100 100", @"1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1 2 3 4", @"4")]
        [InlineData(@"1 2 2 5", @"3")]
        [InlineData(@"500000 500000 500000 500000", @"1")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"1 2 3 4", @"4")]
        [InlineData(@"1 2 2 5", @"3")]
        [InlineData(@"500000 500000 500000 500000", @"1")]
        public void QuestionC_ReviewTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC_Review();

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
