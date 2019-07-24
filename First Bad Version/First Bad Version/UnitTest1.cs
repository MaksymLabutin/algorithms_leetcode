using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private int BadValue;

        [Test]
        public void Test1()
        {
            BadValue = 3;
            var res = FirstBadVersion(8);
            Assert.AreEqual(res, BadValue);
        }

        [Test]
        public void Test2()
        {
            BadValue = 11;
            var res = FirstBadVersion(11);
            Assert.AreEqual(res, BadValue);
        }


        [Test]
        public void Test3()
        {
            BadValue = 10;
            var res = FirstBadVersion(11);
            Assert.AreEqual(res, BadValue);
        }
        [Test]
        public void Test4()
        {
            BadValue = 9;
            var res = FirstBadVersion(11);
            Assert.AreEqual(res, BadValue);
        }
        [Test]
        public void Test5()
        {
            BadValue = 8;
            var res = FirstBadVersion(11);
            Assert.AreEqual(res, BadValue);
        }
        [Test]
        public void Test6()
        {
            BadValue = 7;
            var res = FirstBadVersion(11);
            Assert.AreEqual(res, BadValue);
        }
        [Test]
        public void Test7()
        {
            BadValue = 6;
            var res = FirstBadVersion(11);
            Assert.AreEqual(res, BadValue);
        }

        [Test]
        public void Test8()
        {
            BadValue = 5;
            var res = FirstBadVersion(11);
            Assert.AreEqual(res, BadValue);
        } 

        [Test]
        public void Test9()
        {
            BadValue = 4;
            var res = FirstBadVersion(11);
            Assert.AreEqual(res, BadValue);
        }

        [Test]
        public void Test10()
        {
            BadValue = 3;
            var res = FirstBadVersion(11);
            Assert.AreEqual(res, BadValue);
        }

        [Test]
        public void Test11()
        {
            BadValue = 2;
            var res = FirstBadVersion(11);
            Assert.AreEqual(res, BadValue);
        }

        [Test]
        public void Test12()
        {
            BadValue = 1;
            var res = FirstBadVersion(11);
            Assert.AreEqual(res, BadValue);
        }
  

        public int FirstBadVersion(int n)
        {
            int left = 1, right = n;

            while (left < right)
            {
                var mid = left + (right - left) / 2;

                if (isBadVersion(mid))
                { 
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            } 
            return left;
        }


        bool isBadVersion(int val)
        {
            return val >= BadValue;
        }
    }
}