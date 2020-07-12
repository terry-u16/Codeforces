using System;
using Xunit;
using EducationalCodeforcesRound87.Questions;
using System.Collections.Generic;
using System.Linq;

namespace EducationalCodeforcesRound87.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"7
10 3 6 4
11 3 6 4
5 9 4 10
6 5 2 3
1 1 1 1
3947465 47342 338129 123123
234123843 13 361451236 361451000", @"27
27
9
-1
1
6471793
358578060125049")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7
123
12222133333332
112233
332211
12121212
333333
31121", @"3
3
4
4
0
0
4")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
2
4
200", @"1.000000000
2.414213562
127.321336469")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC1();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"3
3
5
199", @"1.931851653
3.196226611
126.687663595")]
        public void QuestionC2Test(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC2();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }


        [Theory]
        [InlineData(@"5 5
1 2 3 4 5
-1 -1 -1 -1 -1", @"0")]
        [InlineData(@"5 4
1 2 3 4 5
-5 -1 -3 -1", @"3")]
        [InlineData(@"6 2
1 1 1 2 3 4
5 6", @"6")]
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
