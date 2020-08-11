using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            var N = 153;

            var actual = IsArmstrong(N);

            var expected = 153;

            Assert.AreEqual(expected, actual);
        }

        public bool IsArmstrong(int N)
        {
            var n = N.ToString();

            double res = 0;

            foreach (var number in n)
            {
                res += Math.Pow(int.Parse(number.ToString()), n.Length);
            }

            return N == (int) res;
        }
    }
}