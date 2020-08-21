using System;
using Xunit;
using CodeforcesRound665Div2.Questions;
using System.Collections.Generic;
using System.Linq;

namespace CodeforcesRound665Div2.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"6
4 0
5 8
0 1000000
0 0
1 0
1000000 1000000", @"0
3
1000000
0
1
0")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
2 3 2
3 3 1
4 0 1
2 3 0
0 0 1
0 0 1", @"4
2
0")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
1
8
6
4 3 6 6 2 9
4
4 5 6 7
5
7 5 2 2 4", @"YES
YES
YES
NO")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
4
1 2
2 3
3 4
2
2 2
4
3 4
1 3
3 2
2
3 2
7
6 1
2 3
4 6
7 3
5 1
3 6
4
7 5 13 3", @"17
18
286")]
        [InlineData(@"1
7
6 1
2 3
4 6
7 3
5 1
3 6
8
2 2 2 2 2 2 2 2", @"164")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
2 3 1000000
4 0 4
3 0 1000000
4 0 1
2 0 5
3 1 1000000", @"7")]
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
