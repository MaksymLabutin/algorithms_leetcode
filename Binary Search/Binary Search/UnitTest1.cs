using System;
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
            var res = Search(new int[] { -1, 0, 3, 5, 9, 12 }, 9);
            Assert.AreEqual(res, 4);
        }

        [Test]
        public void Test2()
        {
            var res = Search(new int[] { -1, 0, 1, 3, 5, 9, 12 }, 12);
            Assert.AreEqual(res, 6);
        }

        [Test]
        public void Test3()
        {
            var res = Search(new int[] { -1, 0, 1, 3, 5, 9, 12 }, 3);
            Assert.AreEqual(res, 3);
        }

        [Test]
        public void Test4()
        {
            var res = Search(new int[] { -1, 0, 1, 3, 5, 9, 12 }, 2);
            Assert.AreEqual(res, -1);
        }

        [Test]
        public void Test5()
        {
            var res = Search(new int[] { -1, 0, 1, 3, 5, 9, 12 }, -1);
            Assert.AreEqual(res, 0);
        }

        [Test]
        public void Test6()
        {
            var res = Search(new int[] { 2, 4 }, 0);
            Assert.AreEqual(res, -1);
        }

        [Test]
        public void Test7()
        {
            var res = Search(new int[] {-1, 0, 3, 5, 9, 12}, 13);
            Assert.AreEqual(res, -1);
        }

        public int Search(int[] nums, int target)
        {
            var length = nums.Length;
            var pointer = 0;

            while (length > 0 && pointer >= 0 && pointer < nums.Length)
            {
                length = length % 2 == 0 || length == 1 ? length / 2 : length / 2 + 1;

                if (nums[pointer] > target)
                {
                    pointer -= length;
                }
                else if (nums[pointer] < target)
                {
                    pointer += length;
                }
                else
                {
                    return pointer;
                }
            }

            return -1;
        }
    }
}