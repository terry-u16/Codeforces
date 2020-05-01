using System;
using Xunit;
using CodeforcesRound638Div2.Questions;
using System.Collections.Generic;
using System.Linq;
using CodeforcesRound638Div2.Collections;

namespace CodeforcesRound638Div2.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"3
2
4
6", @"2
6
14")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
4 2
1 2 2 1
4 3
1 2 2 1
3 2
1 2 3
4 4
4 3 4 2", @"8
1 2 1 2 1 2 1 2
12
1 2 1 1 2 1 1 2 1 1 2 1
-1
16
4 3 2 1 4 3 2 1 4 3 2 1 4 3 2 1")]
        [InlineData(@"1
1 1
1", @"1
1")]
        [InlineData(@"1
2 1
1 2", @"-1")]
        [InlineData(@"1
5 2
5 5 5 5 5", @"10
5 1 5 1 5 1 5 1 5 1")]
        [InlineData(@"1
5 1
5 5 5 5 5", @"5
5 5 5 5 5")]
        [InlineData(@"1
5 2
1 2 3 1 2", @"-1")]
        [InlineData(@"1
5 3
1 1 1 1 1", @"15
1 1 1 1 1 1 1 1 1 1 1 1 1 1 1")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"6
4 2
baba
5 2
baacb
5 3
baacb
5 3
aaaaa
6 4
aaxxzz
7 1
phoenix", @"ab
abbc
b
aa
x
ehinopx")]
        [InlineData(@"1
4 2
bababbb", @"abbb")]
        [InlineData(@"1
4 2
babaabbb", @"aabbbbb")]
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
