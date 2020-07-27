using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
    public class Tests
    {


        [Test]
        public void Test1()
        {
            var chars = new char[] { 'a', 'a', 'b', 'b', 'c', 'c', 'c' };

            var actual = Compress(chars);

            var expected = 6;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test2()
        {
            var chars = new char[] { 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b' };

            var actual = Compress(chars);

            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var chars = new char[] { 'a', 'b', 'c' };

            var actual = Compress(chars);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        public int Compress(char[] chars)
        {
            if (chars.Length == 1) return chars.Length;

            var tmp = 1;

            var tmpArr = new List<char>() { };

            for (var i = 1; i < chars.Length; i++)
            {
                if (chars[i - 1] == chars[i]) tmp++;
                else
                {
                    tmpArr.Add(chars[i - 1]);
                    if (tmp == 1) continue;

                    tmpArr.AddRange(tmp.ToString().ToCharArray());
                    tmp = 1;
                }
            }

            if (tmp > 1)
            {
                tmpArr.Add(chars[chars.Length - 1]);
                tmpArr.AddRange(tmp.ToString().ToCharArray());
            }

            if (chars[chars.Length - 1] != chars[chars.Length - 2]) tmpArr.Add(chars[chars.Length - 1]);

            for (int i = 0; i < tmpArr.Count; i++)
            {
                chars[i] = tmpArr[i];
            }

            return tmpArr.Count;
        }
    }
}