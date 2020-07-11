using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var m = 3;
            var n = 2;

            var actual = UniquePaths(m, n);

            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var m = 13;
            var n = 14;

            var actual = UniquePaths(m, n);

            var expected = 5200300;
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test3()
        {
            var m = 2;
            var n = 2;

            var actual = UniquePaths(m, n);

            var expected = 2;
            Assert.AreEqual(expected, actual);
        }



        [Test]
        public void Test4()
        {
            var m = 3;
            var n = 3;

            var actual = UniquePaths(m, n);

            var expected = 6;
            Assert.AreEqual(expected, actual);
        }


        private Dictionary<(int, int), int> _memo;

        public int UniquePaths(int m, int n)
        {
            if (m == 1 || n == 1) return 1;
            _memo = new Dictionary<(int, int), int>();
            return Visit(m - 1, n - 1);
        }


        private int Visit(int m, int n)
        {
            if (m < 0 || n < 0) return 0;

            if (m == 0 && n == 0) return 1;

            if (_memo.ContainsKey((m, n))) return _memo[(m, n)];

            var uniquePaths = Visit(m - 1, n) + Visit(m, n - 1);

            _memo.Add((m, n), uniquePaths);

            return uniquePaths;
        }
    }
}