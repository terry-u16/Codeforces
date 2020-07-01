using System;
using Xunit;
using CodeforcesRound654Div2.Questions;
using System.Collections.Generic;
using System.Linq;

namespace CodeforcesRound654Div2.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"4
1
2
3
4", @"1
1
2
2")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
3 4
3 2
3 1
13 7
1010000 9999999", @"4
3
1
28
510049495001")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
2 2 1 2
0 100 0 1
12 13 25 1
27 83 14 25
0 0 1 0
1000000000000000000 1000000000000000000 1000000000000000000 1000000000000000000", @"Yes
No
No
Yes
No
Yes")]
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

        [Theory]
        [InlineData(@"3 2
3 4 5", @"1
3")]
        [InlineData(@"4 3
2 3 5 6", @"2
3 4")]
        [InlineData(@"4 3
9 1 1 1", @"0
")]
        public void QuestionE1Test(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE1();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 2
3 4 5", @"1
3")]
        [InlineData(@"4 3
2 3 5 6", @"2
3 4")]
        [InlineData(@"4 3
9 1 1 1", @"0
")]
        [InlineData(@"3 2
1000000000 1 999999999", @"1
999999998")]
        public void QuestionE2Test(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE2();

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
