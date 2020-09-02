using System;
using Xunit;
using CodeforcesRound639Div2.Questions;
using System.Collections.Generic;
using System.Linq;

namespace CodeforcesRound639Div2.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3
1 3
100000 100000
2 2", @"YES
NO
YES")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
3
14
15
24
1", @"1
2
1
3
0")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
1
14
2
1 -1
4
5 5 5 1
3
3 2 1
2
0 1
5
-239 -2 -100 -3 -11", @"YES
YES
YES
NO
NO
YES")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3 3
.#.
###
##.", @"1")]
        [InlineData(@"4 2
##
.#
.#
##", @"-1")]
        [InlineData(@"4 5
....#
####.
.###.
.#...", @"2")]
        [InlineData(@"2 1
.
#", @"-1")]
        [InlineData(@"3 5
.....
.....
.....", @"0")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"2 1
1 2", @"1
AE")]
        [InlineData(@"4 3
1 2
2 3
3 1", @"-1")]
        [InlineData(@"3 2
1 3
2 3", @"2
AAE")]
        [InlineData(@"2 1
2 1", @"0
EE")]
        [InlineData(@"3 2
3 1
3 2", @"0
EEE")]
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
