using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var n = 3;
            var k = 2;
            var actual = NumWays(n, k);
            var expected = 6;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var n = 4;
            var k = 12;
            var actual = NumWays(n, k);
            var expected = 20460;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var n = 4;
            var k = 2;
            var actual = NumWays(n, k);
            var expected = 10;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4()
        {
            var n = 2;
            var k = 46340;
            var actual = NumWays(n, k);
            var expected = 2147395600;
            Assert.AreEqual(expected, actual);
        }


        private Dictionary<int, int> _memo;

        public int NumWays(int n, int k)
        {
            if (k == 0 || n == 0) return 0;

            _memo = new Dictionary<int, int>(); 

            _memo.Add(0, 0);
            _memo.Add(1, k);
            _memo.Add(2, k * k);

            for (var i = 3; i <= n; i++)
            {   
                var sum = (_memo[i - 1] + _memo[i - 2]) * (k - 1);
                _memo.Add(i, sum);
            }

            return _memo[n];
        }
         



        //private Dictionary<(int, int, int), int> _memo;

        //public int NumWays(int n, int k)
        //{
        //    if (k == 0 || n == 0) return 0;

        //    _memo = new Dictionary<(int, int, int), int>();

        //    return NumWays(n, k, -1, -1);
        //}

        //private int NumWays(int n, int k, int prevPrev, int prev)
        //{
        //    if (n == 0) return 1;

        //    if (_memo.ContainsKey((n, prevPrev, prev))) return _memo[(n, prevPrev, prev)];

        //    var sum = 0;

        //    for (var i = 0; i < k; i++)
        //    {
        //        if (prev == i && prevPrev == i) continue;

        //        var val = NumWays(n - 1, k, prev, i);
        //        sum += val;
        //    }

        //    _memo.Add((n, prevPrev, prev), sum);

        //    return _memo[(n, prevPrev, prev)];
        //}
    }
}