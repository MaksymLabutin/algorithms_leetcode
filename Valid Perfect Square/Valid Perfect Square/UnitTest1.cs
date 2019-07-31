using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var res = IsPerfectSquare(16);
            Assert.IsTrue(res);
        }


        [Test]
        public void Test2()
        {
            var res = IsPerfectSquare(12);
            Assert.IsFalse(res);
        }


        [Test]
        public void Test3()
        {
            var res = IsPerfectSquare(1);
            Assert.IsTrue(res);
        }


        [Test]
        public void Test4()
        {
            var res = IsPerfectSquare(808201);
            Assert.IsTrue(res);
        }

        [Test]
        public void Test5()
        {
            var res = IsPerfectSquare(2147395600);
            Assert.IsTrue(res);
        }

        public bool IsPerfectSquare(int num)
        {
            int left = 0, right = num;

            while (left < right)
            {
                var mid = left + (right - left) / 2;

                int sqrt = (long)(mid) * (long)(mid) > int.MaxValue ? -1 : mid * mid;

                if (sqrt == num) return true;

                if (sqrt > num || sqrt < 0)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left * left == num;
        }
    }
}