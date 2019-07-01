using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
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
            var res = MinSubArrayLen(7, new int[] { 2, 3, 1, 8, 4, 3 });

            Assert.AreEqual(res, 1);
        }

        [Test]
        public void Test2()
        {
            var res = MinSubArrayLen(7, new int[] { 0 });

            Assert.AreEqual(res, 0);
        }

        [Test]
        public void Test3()
        {
            var res = MinSubArrayLen(7, new int[] { 2, 3, 1, 2, 4, 3 });

            Assert.AreEqual(res, 2);
        }

        [Test]
        public void Test4()
        {
            var res = MinSubArrayLen(11, new int[] { 1, 2, 3, 4, 5 });

            Assert.AreEqual(res, 3);
        }

        [Test]
        public void Test5()
        {
            var res = MinSubArrayLen(6, new int[] { 1, 1, 1, 1, 1 });

            Assert.AreEqual(res, 0);
        }

        [Test]
        public void Test6()
        {
            var res = MinSubArrayLen(15, new int[] { 1, 2, 3, 4, 5 });

            Assert.AreEqual(res, 5);
        }
        [Test]
        public void Test7()
        {
            var res = MinSubArrayLen(218, new int[] { 12, 28, 83, 4, 25, 26, 25, 2, 25, 25, 25, 12 });

            Assert.AreEqual(res, 8);
        }

        public int MinSubArrayLen(int s, int[] nums)
        {
            int sum = 0, len = 0, i = 0, j = 0;
            while (sum >= s || j < nums.Length)
                if (sum < s) sum += nums[j++];
                else
                {
                    if (len == 0 || len > j - i)
                        if ((len = j - i) == 1) return len;
                    sum -= nums[i++];
                }
            return len;
        }
        
        //it works but 14 tastcase faild. Time limite error
        //public int MinSubArrayLen(int s, int[] nums)
        //{
        //    var minLenght = 2;
        //    int index = 0, sum = 0, pointer = 0;
        //    while (minLenght <= nums.Length)
        //    {
        //        sum = 0;

        //        var i = index + minLenght;
        //        for (; index < i;)
        //        {
        //            sum += nums[index];
        //            if (nums[index] >= s) return 1;
        //            if (sum >= s) return minLenght;
        //            index++;
        //        }

        //        index = ++pointer;

        //        if (index + minLenght <= nums.Length) continue;

        //        pointer = 0;
        //        index = 0;
        //        minLenght++;

        //    }

        //    return sum >= s ? minLenght : 0;
        //}


    }
}