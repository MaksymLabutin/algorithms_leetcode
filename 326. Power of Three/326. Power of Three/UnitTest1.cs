using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var n = 27;
            var actual = IsPowerOfThree(n);
            Assert.True(actual);
        }


        private Int64 _currentN = 1;
        public bool IsPowerOfThree(int n)
        { 
            if (_currentN >= n) return _currentN == n;
            _currentN *= 3;
            return IsPowerOfThree(n);
        }   
    }
}