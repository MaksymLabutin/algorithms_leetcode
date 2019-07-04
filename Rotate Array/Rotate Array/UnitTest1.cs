using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
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
            var nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            Rotate(nums, 3);
            Assert.AreEqual(nums, new int[] { 5,6,7,1,2,3,4 });

        }

        [Test]
        public void Test2()
        {
            var nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            Rotate(nums, 8);
            Assert.AreEqual(nums, new int[] { 7,1,2,3,4,5,6 });

        }
        [Test]
        public void Test3()
        {
            var nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            Rotate(nums, 16);
            Assert.AreEqual(nums, new int[] { 6,7,1,2,3,4,5 });

        }
        [Test]
        public void Test4()
        {
            var nums = new int[] { 1, 2 };
            Rotate(nums, 3);
            Assert.AreEqual(nums, new int[]{2,1});

        }
        [Test]
        public void Test5()
        {
            var nums = new int[] { 1, 2, 3, 4, 5, 6 };
            Rotate(nums, 2); 
            Assert.AreEqual(nums, new int[]{5,6,1,2,3,4});
        }

        [Test]
        public void Test6()
        {
            var nums = new int[] { 1, 2, 3};
            Rotate(nums, 4);
            Assert.AreEqual(nums, new int[] { 3,1,2});

        }

        

        //fastest
        public void Rotate(int[] nums, int k)
        {
            k = k % nums.Length;
            int len = nums.Length;

            int[] temp = new int[len];

            for (int i = 0; i < len; i++)
            {
                temp[(i + k) % len] = nums[i];
            }
            for (int i = 0; i < len; i++)
            {
                nums[i] = temp[i];
            }
        }

        //public void Rotate(int[] nums, int k)
        //{
        //    if (nums.Length <= 1 || nums.Length == k || k == 0) return;

        //    k = k > nums.Length ? nums.Length - (k - (k / nums.Length) * nums.Length) : nums.Length - k;

        //    var res = new int[nums.Length];

        //    for (var i = 0; i < nums.Length; i++)
        //    {
        //        res[i] = nums[k];

        //        if (++k >= nums.Length) k = 0;
        //    }

        //    for (var j = 0; j < nums.Length; j++)
        //    {
        //        nums[j] = res[j];
        //    }
        //}
    }
}