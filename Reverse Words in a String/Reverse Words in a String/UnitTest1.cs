using System.Text;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var res = ReverseWords("the sky is blue");

            Assert.AreEqual(res, "blue is sky the");
        }

        [Test]
        public void Test2()
        {
            var res = ReverseWords("  hello world!  ");

            Assert.AreEqual(res, "world! hello");
        }
        [Test]
        public void Test3()
        {
            var res = ReverseWords("a good   example");

            Assert.AreEqual(res, "example good a");
        }

        [Test]
        public void Test4()
        {
            var res = ReverseWords("       ");

            Assert.AreEqual(res, "");
        }

        [Test]
        public void Test5()
        {
            var res = ReverseWords("  a     ");

            Assert.AreEqual(res, "a");
        }

        [Test]
        public void Test6()
        {
            var res = ReverseWords("");

            Assert.AreEqual(res, "");
        }

        public string ReverseWords(string s)
        {
            StringBuilder str = new StringBuilder();

            int length = 0, pointer = s.Length;

            while (pointer > 0)
            {
                pointer--;

                if (!char.IsWhiteSpace(s[pointer]))
                {
                    length++;
                    continue;
                };

                if (length > 0)
                {
                    str.Append(s.Substring(pointer + 1, length) + " ");
                }

                length = 0;
            }

            if (str.Length == 0 && length == 0) return str.ToString();

            return length > 0 ? str.Append(s.Substring(0, length)).ToString() : str.Remove(str.Length - 1, 1).ToString();
        }
    }
}