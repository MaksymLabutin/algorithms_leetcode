using System;
using System.Threading;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var res = MySqrt(4);

            Assert.AreEqual(res, 2);
        }

        [Test]
        public void Test2()
        {
            var res = MySqrt(8);

            Assert.AreEqual(res, 2);
        }

        [Test]
        public void Test3()
        {
            var res = MySqrt(10);

            Assert.AreEqual(res, 3);
        }

        [Test]
        public void Test4()
        {
            var res = MySqrt(2147483647);

            Assert.AreEqual(res, 46340);
        }

        [Test]
        public void Test5()
        {
            var res = MySqrt(1024);

            Assert.AreEqual(res, 32);
        }

        [Test]
        public void Test6()
        {
            var res = MySqrt(2147395599);

            Assert.AreEqual(res, 46339);
        }

        public int MySqrt(int x)
        {
            if (x < 2) return x;

            int left = 1, right = 46340;

            while (true)
            {
                int mid = left + (right - left) / 2;
                int sqrt = mid * mid;

                if (sqrt < 0) return 46340;

                if (sqrt > x)
                {
                    right = mid + 1;
                    if ((mid - 1) * (mid - 1) <= x) return mid - 1;
                }
                else if (sqrt < x)
                {
                    left = mid + 1;

                    var i = (mid + 1) * (mid + 1);
                    if (i >= x) return i == x ? mid + 1 : mid;
                }
                else return mid;
            }
        }
    }
}