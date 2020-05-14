using System;
using Xunit;
using CodeforcesRound642Div3.Questions;
using System.Collections.Generic;
using System.Linq;

namespace CodeforcesRound642Div3.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"5
1 100
2 2
5 5
2 1000000000
1000000000 1000000000", @"0
2
10
1000000000
2000000000")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
2 1
1 2
3 4
5 5
5 5 6 6 5
1 2 5 4 3
5 3
1 2 3 4 5
10 9 10 10 9
4 0
2 2 4 3
2 4 2 3
4 4
1 2 2 1
4 4 5 4", @"6
27
39
11
17")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
1
5
499993", @"0
40
41664916690999888")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
1
2
3
4
5
6", @"1
1 2
2 1 3
3 1 2 4
2 4 1 3 5
3 4 1 5 2 6")]
        [InlineData(@"1
6", @"3 4 1 5 2 6")]
        [InlineData(@"1
10", @"7 3 4 8 1 5 9 2 6 10")]
        [InlineData(@"1
11", @"4 8 2 5 9 1 6 10 3 7 11")]
        [InlineData(@"1
12", @"5 8 3 6 9 1 7 10 2 11 4 12")]
        [InlineData(@"1
16", @"9 5 10 3 11 6 12 1 13 7 14 2 15 4 8 16")]
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
