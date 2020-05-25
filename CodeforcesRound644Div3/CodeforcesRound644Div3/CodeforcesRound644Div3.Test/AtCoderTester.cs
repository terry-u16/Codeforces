using System;
using Xunit;
using CodeforcesRound644Div3.Questions;
using System.Collections.Generic;
using System.Linq;

namespace CodeforcesRound644Div3.Test
{
    public class AtCoderTester
    {
        [Theory]
        [InlineData(@"8
3 2
4 2
1 1
3 1
4 7
1 3
7 4
100 100", @"16
16
4
9
64
9
64
40000")]
        public void QuestionATest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionA();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
5
3 1 2 6 4
6
2 1 3 2 4 3
4
7 9 3 1
2
1 1000
3
100 150 200", @"1
0
2
999
50")]
        public void QuestionBTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionB();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"7
4
11 14 16 12
2
1 8
4
1 1 1 1
4
1 2 5 6
2
12 13
6
1 6 3 10 5 8
6
1 12 3 10 5 8", @"YES
NO
YES
YES
YES
YES
NO")]
        public void QuestionCTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionC();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
8 7
8 1
6 10
999999733 999999732
999999733 999999733", @"2
8
1
999999733
1")]
        public void QuestionDTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionD();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
4
0010
0011
0000
0000
2
10
01
2
00
00
4
0101
1111
0101
0111
4
0100
1110
0101
0111", @"YES
NO
YES
YES
NO")]
        public void QuestionETest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionE();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
2 4
abac
zbab
2 4
aaaa
bbbb
3 3
baa
aaa
aab
2 2
ab
bb
3 1
a
b
c", @"abab
-1
aaa
ab
z")]
        [InlineData(@"1
10 10
accdefghij
bbcdefghij
cbcdefghij
dbcdefghij
ebcdefghij
fbcdefghij
gbcdefghij
hbcdefghij
ibcdefghij
jbcdefghij
", @"abcdefghij")]
        [InlineData(@"1
10 10
accdefghij
becdefghij
cbcdefghij
dbcdefghij
ebcdefghij
fbcdefghij
gbcdefghij
hbcdefghij
ibcdefghij
jbcdefghij
", @"-1")]
        public void QuestionFTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionF();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
3 6 2 1
2 2 2 1
2 2 2 2
4 4 2 2
2 1 1 2", @"YES
010001
100100
001010
NO
YES
11
11
YES
1100
1100
0011
0011
YES
1
1")]
        public void QuestionGTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionG();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }

        [Theory]
        [InlineData(@"5
3 3
010
001
111
4 3
000
111
100
011
1 1
1
1 1
0
3 2
00
01
10", @"100
010
0
1
11")]
        public void QuestionHTest(string input, string output)
        {
            var outputs = SplitByNewLine(output);
            IAtCoderQuestion question = new QuestionH();

            var answers = question.Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(outputs, answers);
        }


        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
    }
}
