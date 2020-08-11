using System;
using Xunit;
using EducationalCodeforcesRound91.Questions;
using System.Collections.Generic;
using System.Linq;

namespace EducationalCodeforcesRound91.Test
{
    public class AtCoderTester
    {
//        [Theory]
//        [InlineData(@"3
//4
//2 1 4 3
//6
//4 6 1 2 5 3
//5
//5 3 1 2 4", @"YES
//2 3 4
//YES
//3 5 6
//NO")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        //[Theory]
        //[InlineData(@"", @"")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
5 10
7 11 2 9 5
4 8
2 4 2 3
4 11
1 3 3 7", @"2
1
0")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5 2
5 2 3
3 1 4 5 2
3 5", @"8")]
        [InlineData(@"4 4
5 1 4
4 3 1 2
2 4 3 1", @"-1")]
        [InlineData(@"4 4
2 1 11
1 3 2 4
1 3 2 4", @"0")]
        [InlineData(@"5 2
10 4 2
1 3 4 5 2
1 2", @"-1")]
        [InlineData(@"5 2
10 2 2
1 3 4 5 2
1 2", @"12")]
        [InlineData(@"5 2
10 2 2
5 3 4 1 2
1 2", @"12")]
        [InlineData(@"5 2
10 2 2
5 3 4 1 2
5 2", @"6")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7 4
1 2 3 3 1 4 3
3 1
2 3
2 4", @"5
4
2
0")]
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
