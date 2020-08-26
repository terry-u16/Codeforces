using System;
using Xunit;
using EducationalCodeforcesRound94.Questions;
using System.Collections.Generic;
using System.Linq;

namespace EducationalCodeforcesRound94.Test
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

        [Theory]
        [InlineData(@"3
33 27
6 10
5 6
100 200
10 10
5 5
1 19
1 3
19 5", @"11
20
3")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
101110
2
01
1
110
1", @"111011
10
-1")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2
5
2 2 2 2 2
6
1 3 3 1 2 3", @"5
2")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
1 4 1 1", @"2")]
        [InlineData(@"5
1 0 1 0 1", @"3")]
        [InlineData(@"3
1 1 1", @"1")]
        [InlineData(@"3
999 0 0", @"1")]
        [InlineData(@"3
0 0 0", @"0")]
        [InlineData(@"4
2 1 3 2", @"4")]
        [InlineData(@"4
1 1 2 4", @"3")]
        [InlineData(@"5
1 100 1 100 1", @"3")]
        [InlineData(@"6
1 2 100 3 4 4", @"5")]
        [InlineData(@"5
1 1000 2 10000 1", @"4")]
        [InlineData(@"6
1 1000 2 2 10000 1", @"4")]
        [InlineData(@"5
4 4 3 2 1", @"4")]
        [InlineData(@"5
3 2 1 2 3", @"5")]
        [InlineData(@"5
1 1000 1 1000 1000", @"4")]
        [InlineData(@"5
1 2 1 0 2", @"3")]
        [InlineData(@"5
1 2 2 0 2", @"3")]
        [InlineData(@"5
2 2 1 0 2", @"3")]
        [InlineData(@"11
4 4 3 2 1 0 1 1 3 1 1", @"6")]
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
