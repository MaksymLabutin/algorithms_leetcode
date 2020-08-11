using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var s = "A";
            var actual = TitleToNumber(s);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var s = "AB";
            var actual = TitleToNumber(s);
            var expected = 28;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var s = "ZY";
            var actual = TitleToNumber(s);
            var expected = 701;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4()
        {
            var s = "ZZZZZZ";
            var actual = TitleToNumber(s);
            var expected = 321272406;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test5()
        {
            var s = "BA";
            var actual = TitleToNumber(s);
            var expected = 53;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test7()
        {
            var s = "BBA";
            var actual = TitleToNumber(s);
            var expected = 1405;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test6()
        {
            var s = "AZ";
            var actual = TitleToNumber(s);
            var expected = 52;
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test8()
        {
            var s = "AAA";
            var actual = TitleToNumber(s);
            var expected = 703;
            Assert.AreEqual(expected, actual);
        }

        public int TitleToNumber(string s)
        {
            if (s.Length == 1) return s[0] - 'A' + 1;
            var res = 1;

            for (int i = 0; i < s.Length - 1; i++)
            {
                res *= (s[i] - 'A' + 1) * 26;
            }

            return res + 1 + s[s.Length - 1] - 'A';
        }
    }
}