using System;
using Xunit;
using EducationalCodeforcesRound62.Questions;
using System.Collections.Generic;
using System.Linq;

namespace EducationalCodeforcesRound62.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"9
1 3 3 6 7 6 8 8 9", @"4")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
2
<>
3
><<
1
>", @"1
0
0")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4 3
4 7
15 1
3 6
6 8", @"78")]
        [InlineData(@"5 3
12 31
112 4
100 100
13 55
55 50", @"10000")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3", @"6")]
        [InlineData(@"4", @"18")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 3
-1 -1", @"9")]
        [InlineData(@"5 2
1 -1 -1 1 2", @"0")]
        [InlineData(@"5 3
1 -1 -1 1 2", @"2")]
        [InlineData(@"4 200000
-1 -1 12345 -1", @"735945883")]
        [InlineData(@"2 3
1 1", @"1")]
        [InlineData(@"2 3
1 -1 1", @"0")]
        [InlineData(@"5 2
-1 -1 -1 -1 -1", @"4")]
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
