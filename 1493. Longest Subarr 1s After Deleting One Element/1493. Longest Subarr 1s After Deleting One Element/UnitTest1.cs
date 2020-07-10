using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var nums = new int[] { 1, 1, 0, 0, 1, 1, 1, 0, 1 };

            var actual = LongestSubarray(nums);

            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var nums = new int[] { 0, 0, 0 };

            var actual = LongestSubarray(nums);

            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var nums = new int[] { 1, 1, 0, 1 };

            var actual = LongestSubarray(nums);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test4()
        {
            var nums = new int[] { 0, 1, 1, 1, 0, 1, 1, 0, 1 };

            var actual = LongestSubarray(nums);

            var expected = 5;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test5()
        {
            var nums = new int[] {1, 1, 1 };

            var actual = LongestSubarray(nums);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        public int LongestSubarray(int[] nums)
        {
            var list = new List<int>();
            var curr = 0;
            foreach (var num in nums)
            {
                if (num == 0)
                {
                    list.Add(curr);
                    curr = 0;
                    continue;
                }

                if (list.Count > 0) list[list.Count - 1] += 1;
                curr++;
            }

            if (curr > 0) list.Add(curr);

            var longestSubarray = list.Max();
            return longestSubarray == nums.Length ? longestSubarray - 1 : longestSubarray;
        }
    }
}