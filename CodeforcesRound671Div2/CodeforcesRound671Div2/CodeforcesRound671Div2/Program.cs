using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound671Div2.Questions;

namespace CodeforcesRound671Div2
{
    class Program
    {
        static void Main(string[] args)
        {
            IAtCoderQuestion question = new QuestionD2();
            using (var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput()))
            {
                var thread = new System.Threading.Thread(() => question.Solve(io), 1 << 26);
                thread.Start();
                thread.Join();
            }
        }
    }
}

#region Base Class

namespace CodeforcesRound671Div2.Questions
{

    public interface IAtCoderQuestion
    {
        string Solve(string input);
        void Solve(IOManager io);
    }

    public abstract class AtCoderQuestionBase : IAtCoderQuestion
    {
        public string Solve(string input)
        {
            var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            var outputStream = new MemoryStream();
            using (var manager = new IOManager(inputStream, outputStream))
            {
                Solve(manager);
                manager.Flush();

                outputStream.Seek(0, SeekOrigin.Begin);
                var reader = new StreamReader(outputStream);
                return reader.ReadToEnd();
            }
        }

        public abstract void Solve(IOManager io);
    }

    public class IOManager : IDisposable
    {
        private readonly StreamReader _reader;
        private readonly StreamWriter _writer;
        private bool _disposedValue;
        private Queue<ReadOnlyMemory<char>> _stringQueue;

        const char ValidFirstChar = '!';
        const char ValidLastChar = '~';

        public IOManager(Stream input, Stream output)
        {
            _reader = new StreamReader(input);
            _writer = new StreamWriter(output) { AutoFlush = false };
            _stringQueue = new Queue<ReadOnlyMemory<char>>();
        }

        public ReadOnlySpan<char> ReadCharSpan()
        {
            while (_stringQueue.Count == 0)
            {
                var line = _reader.ReadLine().AsMemory().Trim();
                var s = line.Span;

                if (s.Length > 0)
                {
                    var begin = 0;
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (begin < 0 && IsValidChar(s[i]))
                        {
                            begin = i;
                        }
                        else if (!IsValidChar(s[i]))
                        {
                            _stringQueue.Enqueue(line[begin..i]);
                            begin = -1;
                        }
                    }
                    _stringQueue.Enqueue(line[begin..line.Length]);
                }
            }

            return _stringQueue.Dequeue().Span;
        }

        public string ReadString() => ReadCharSpan().ToString();

        public int ReadInt() => (int)ReadLong();

        public long ReadLong()
        {
            long result = 0;
            bool isPositive = true;

            int i = 0;
            var s = ReadCharSpan();
            if (s[i] == '-')
            {
                isPositive = false;
                i++;
            }

            while (i < s.Length)
            {
                result = result * 10 + (s[i++] - '0');
            }

            return isPositive ? result : -result;
        }

        public double ReadDouble() => double.Parse(ReadCharSpan());
        public decimal ReadDecimal() => decimal.Parse(ReadCharSpan());

        public int[] ReadIntArray(int n)
        {
            var a = new int[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ReadInt();
            }
            return a;
        }

        public long[] ReadLongArray(int n)
        {
            var a = new long[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ReadLong();
            }
            return a;
        }

        public double[] ReadDoubleArray(int n)
        {
            var a = new double[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ReadDouble();
            }
            return a;
        }

        public decimal[] ReadDecimalArray(int n)
        {
            var a = new decimal[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ReadDecimal();
            }
            return a;
        }

        public void WriteLine<T>(T value) => _writer.WriteLine(value.ToString());

        public void WriteLine<T>(IEnumerable<T> values, char separator)
        {
            var e = values.GetEnumerator();
            if (e.MoveNext())
            {
                _writer.Write(e.Current.ToString());

                while (e.MoveNext())
                {
                    _writer.Write(separator);
                    _writer.Write(e.Current.ToString());
                }
            }

            _writer.WriteLine();
        }

        public void Flush() => _writer.Flush();

        private static bool IsValidChar(char c) => ValidFirstChar <= c && c <= ValidLastChar;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _reader.Dispose();
                    _writer.Flush();
                    _writer.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

#endregion
