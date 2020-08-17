using System;
using Xunit;
using CodeforcesGlobalRound10.Questions;
using System.Collections.Generic;
using System.Linq;

namespace CodeforcesGlobalRound10.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"2
4
2 1 3 1
2
420 420", @"1
2")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
2 1
-199 192
5 19
5 -1 4 2 0
1 2
69", @"391 0
0 6 1 3 5
0")]
        [InlineData(@"1
1 100
1", "0")]
        [InlineData(@"1
1 99
0", "0")]
        [InlineData(@"1
3 100
0 100 -50", "50 150 0")]
        [InlineData(@"1
3 101
0 100 -50", "100 0 150")]
        [InlineData(@"1
3 1
1000000000 -1000000000 0", "0 2000000000 1000000000")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
4
5 3 2 5
5
1 2 3 5 3
3
1 1 1", @"3
2
0")]
        [InlineData(@"1
1 99
1", "0")]

        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
4
RLRL
6
LRRRRL
8
RLLRRRLL
12
LLLLRRLRRRLL
5
RRRRR", @"0
1
1
3
2")]
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
