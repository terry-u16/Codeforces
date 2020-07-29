using System;
using Xunit;
using EducationalCodeforcesRound92.Questions;
using System.Collections.Generic;
using System.Linq;

namespace EducationalCodeforcesRound92.Test
{
    public class AtCoderTester
    {
//        [Theory]
//        [InlineData(@"4
//1 1337
//13 69
//2 4
//88 89", @"6 7
//14 21
//2 4
//-1 -1")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"4
5 4 0
1 5 4 3 2
5 4 1
1 5 4 3 2
5 4 4
10 20 30 40 50
10 7 3
4 6 8 2 9 9 7 4 10 9", @"15
19
150
56")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
95831
100120013
252525252525", @"3
5
0")]
        [InlineData(@"1
11111111111111111111", @"0")]
        [InlineData(@"1
11121111111211111112", @"3")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
3 5
1 2
3 4
2 1000000000
1 1
999999999 999999999
10 3
5 10
7 8", @"7
2000000000
0")]
        [InlineData(@"1
3 2
2 5
4 8", @"0")]
        [InlineData(@"1
3 7
2 5
4 8", @"4")]
        [InlineData(@"1
3 20
2 5
4 8", @"19")]
        [InlineData(@"1
3 2
4 5
2 8", @"0")]
        [InlineData(@"1
3 7
4 5
2 8", @"4")]
        [InlineData(@"1
3 20
4 5
2 8", @"19")]
        [InlineData(@"1
3 2
4 8
2 5", @"0")]
        [InlineData(@"1
3 7
4 8
2 5", @"4")]
        [InlineData(@"1
3 20
4 8
2 5", @"19")]
        [InlineData(@"1
10 20
1 2
2 4", @"20")]
        [InlineData(@"1
10 35
1 2
2 4", @"40")]
        [InlineData(@"1
3 1
1 2
3 5", @"2")]
        [InlineData(@"1
3 5
1 2
3 5", @"7")]
        [InlineData(@"1
3 6
1 2
3 5", @"8")]
        [InlineData(@"1
1 1
1 1
5 5", @"5")]
        [InlineData(@"1
1000000000 1
1 1000000000
1 1000000000", @"0")]
        [InlineData(@"1
1 1000000001
1 1000000001
1 1000000001", @"2")]
        [InlineData(@"1
3 10
1 2
3 4", @"14")]
        [InlineData(@"1
3 5
1 1
10000 10000", @"10004")]
        [InlineData(@"1
3 10000
1 1
10000 10000", @"20000")]
        [InlineData(@"1
1 1
1 1
1 1", @"2")]
        [InlineData(@"1
1 2
2 2
1 1", @"4")]
        [InlineData(@"1
5 8
2 4
3 6", @"3")]
        [InlineData(@"1
5 18
2 4
3 6", @"13")]
        [InlineData(@"1
5 25
2 4
3 6", @"25")]
        [InlineData(@"1
10000 1
1 2
10001 20000", @"10000")]
        [InlineData(@"1
100000 10000
1 1
10001 10001", @"20000")]

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
