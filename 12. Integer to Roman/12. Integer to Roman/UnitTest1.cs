using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var num = 49;

            var actual = IntToRoman(num);

            var expected = "XLIX";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var num = 3;

            var actual = IntToRoman(num);

            var expected = "III";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var num = 4;

            var actual = IntToRoman(num);

            var expected = "IV";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test5()
        {
            var num = 9;

            var actual = IntToRoman(num);

            var expected = "IX";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test6()
        {
            var num = 58;

            var actual = IntToRoman(num);

            var expected = "LVIII";
            Assert.AreEqual(expected, actual);
        }

        public string IntToRoman(int num)
        {
            var romans = new Dictionary<int, string>()
            {
                {1000, "M"},
                {900, "CM"},
                {500, "D"},
                {400, "CD"},
                {100, "C"},
                {90, "XC"},
                {50, "L"},
                {40, "XL"},
                {10, "X"},
                {9, "IX"},
                {5, "V"},
                {4, "IV"},
                {1, "I"},
            };

            var res = new StringBuilder();
            while (num != 0)
            {
                if (romans.ContainsKey(num))
                {
                    res.Append(romans[num]);
                    break;
                }

                foreach (var roman in romans)
                {
                    if (num - roman.Key <= 0) continue;
                    num -= roman.Key;
                    res.Append(roman.Value);
                    break;
                }
            }

            return res.ToString();
        }
    }
}