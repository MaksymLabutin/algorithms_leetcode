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
            var A = new int[] {1, 2, 3, 3};
            var actual = RepeatedNTimes(A);
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        public int RepeatedNTimes(int[] A)
        {
            var memo = new HashSet<int>();

            foreach (var i in A)
            {
                if (memo.Contains(i)) return i;
                memo.Add(i);
            }

            return -1;
        }
    }
}