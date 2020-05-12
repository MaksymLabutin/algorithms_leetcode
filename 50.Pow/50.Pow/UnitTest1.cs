using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var actual = MyPow(2, 2);
            Assert.AreEqual(Math.Pow(2, 2), actual);
        }

        [Test]
        public void Test2()
        {
            var actual = MyPow(2, 256);
            Assert.AreEqual(Math.Pow(2, 256), actual);
        }


        [Test]
        public void Test4()
        {
            var actual = MyPow(2, 21);
            Assert.AreEqual(Math.Pow(2, 21), actual);
        }

        [Test]
        public void Test3()
        {
            var actual = MyPow(2, 257);
            Assert.AreEqual(Math.Pow(2, 257), actual);
        }

        [Test]
        public void Test5()
        {
            var actual = MyPow(2, int.MaxValue);
            Assert.AreEqual(Math.Pow(2, int.MaxValue), actual);
        }


        [Test]
        public void Test6()
        {
            var actual = MyPow(2, -2);
            Assert.AreEqual(Math.Pow(2, -2), actual);
        }


        [Test]
        public void Test7()
        {
            var actual = MyPow(0.00001, 2147483647);
            Assert.AreEqual(Math.Pow(0.00001, 2147483647), actual);
        }


        [Test]
        public void Test8()
        {
            var actual = MyPow(1, 2147483647);
            Assert.AreEqual(Math.Pow(1, 2147483647), actual);
        }

        [Test]
        public void Test9()
        {
            var actual = MyPow(-1, 2147483647);
            Assert.AreEqual(Math.Pow(-1, 2147483647), actual);
        }


        public double MyPow(double x, int n)
        {
            if (n == 0 || x == 1) return 1;

            if (x == -1) return n < 0 ? 1.00000 : -1.00000;
            double res = 1;
            var copiedN = n;

            n = n < 0 ? n * -1 : n;

            while (true)
            {
                var closestPow = GetClosestPow(x, n);
                res *= closestPow.x;

                if (double.IsPositiveInfinity(res)) return copiedN < 0 ? 0.00000 : double.PositiveInfinity;
                if (res == 0.00000) return copiedN < 0 ? double.PositiveInfinity : res;
                if (closestPow.n == n) break;
                n = n - closestPow.n;
            }

            return copiedN < 0 ? 1 / res : res;
        }

        private (double x, int n) GetClosestPow(double x, int n)
        {
            var currPow = 1;
            var prevPow = currPow;
            var prevX = x;

            while (currPow < n)
            {
                prevX = x;
                x *= x;
                prevPow = currPow;
                currPow *= 2;
                if (double.IsPositiveInfinity(prevX) || x == 0.00000) return (x, currPow);
            }

            return currPow > n ? (prevX, prevPow) : (x, currPow);
        }
    }
}