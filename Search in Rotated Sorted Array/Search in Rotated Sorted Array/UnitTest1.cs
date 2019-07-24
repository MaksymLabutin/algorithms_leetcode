using System.Reflection.PortableExecutable;
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
            var res = Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0);
            Assert.AreEqual(res, 4);
        }

        [Test]
        public void Test2()
        {
            var res = Search(new int[] { 6, 7, 0, 1, 2, 4, 5 }, 0);
            Assert.AreEqual(res, 2);
        }

        [Test]
        public void Test7()
        {
            var res = Search(new int[] { 6, 7, 0, 1, 2, 4, 5 }, 7);
            Assert.AreEqual(res, 1);
        }

        [Test]
        public void Test3()
        {
            var res = Search(new int[] { 6, 7, 0, 1, 2, 4, 5 }, 5);
            Assert.AreEqual(res, 6);
        }

        [Test]
        public void Test4()
        {
            var res = Search(new int[] { 0, 1, 2, 4, 5, 6, 7 }, 5);
            Assert.AreEqual(res, 4);
        }
        [Test]
        public void Test5()
        {
            var res = Search(new int[] { 0, 1 }, 3);
            Assert.AreEqual(res, -1);
        }
        [Test]
        public void Test6()
        {
            var res = Search(new int[] { 0, 1, 4 }, 4);
            Assert.AreEqual(res, 2);
        }

        [Test]
        public void Test8()
        {
            var res = Search(new int[] { 7, 0, 4 }, 4);
            Assert.AreEqual(res, 2);
        }

        [Test]
        public void Test9()
        {
            var res = Search(new int[] {1, 3, 5 }, 1);
            Assert.AreEqual(res, 0);
        }

        public int Search(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;

            int left = 0, right = nums.Length - 1, pivot = nums[0];

            while (left <= right)
            {
                var mid = left + (right - left) / 2;

                if (nums[mid] == target) return mid;

                if (pivot > nums[mid])
                {
                    pivot = nums[mid]; 

                    if (nums[mid] < target && nums[nums.Length-1] >= target)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                else
                {
                    if (nums[mid] > target && target >= pivot)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
            }

            return -1;
        }
    }
}