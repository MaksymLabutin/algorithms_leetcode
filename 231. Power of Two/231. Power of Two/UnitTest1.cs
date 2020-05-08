using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var n = 1;

            var actual = IsPowerOfTwo(n);

            Assert.True(actual);
        }

        [Test]
        public void Test2()
        {
            var n = 0;

            var actual = IsPowerOfTwo(n);

            Assert.False(actual);
        } 

        [Test]
        public void Test3()
        {
            var n = 16;

            var actual = IsPowerOfTwo(n);

            Assert.True(actual);
        }

        [Test]
        public void Test4()
        {
            var n = 218;

            var actual = IsPowerOfTwo(n);

            Assert.False(actual);
        }

         
        public bool IsPowerOfTwo(int n)
        { 
            if (n < 2) return n == 1;

            return CheckPowerOfTwo(n, 1);
        }

        private bool CheckPowerOfTwo(int n, Int64 currentVal)
        {
            return currentVal >= n ? n == currentVal : CheckPowerOfTwo(n, currentVal * 2);
        }
    }
}