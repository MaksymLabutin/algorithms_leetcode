using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

            var expected = 225792840;
            Assert.AreEqual(expected, actual);
        }

        //private Dictionary<(int, int), int> memo;
        public int UniquePaths(int m, int n)
        {
            if (m == 1 || n == 1) return 1;
            return UniquePaths(m, n, 0, new Dictionary<(int, int), int>());
        }


        private int UniquePaths(int m, int n, int paths, Dictionary<(int, int), int> memo)
        {
            if (m < 0 || n < 0) return 0;
            if (m == 0 && n == 0) return paths;

            if (memo.ContainsKey((m, n))) return memo[(m, n)];

            var uniquePaths = UniquePaths(m - 1, n, paths, memo) + UniquePaths(m - 1, n, paths + 1, memo) +
                              UniquePaths(m, n - 1, paths, memo) + UniquePaths(m, n - 1, paths + 1, memo);

            memo.Add((m, n), uniquePaths);

            return uniquePaths;
        }
    }
}