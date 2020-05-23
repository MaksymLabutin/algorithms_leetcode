using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var nums = new int[] { 3, 2, 3 };
            var actual = MajorityElement(nums);
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var nums = new int[] { 2, 2, 1, 1, 1, 2, 2 };
            var actual = MajorityElement(nums);
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        public int MajorityElement(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            var dic = new Dictionary<int, int>();
            var max = (0, 0);
            foreach (var num in nums)
            {
                if (dic.ContainsKey(num))
                {
                    dic[num] += 1;
                    if (dic[num] > max.Item2) max = (num, dic[num]);
                }
                else  dic.Add(num, 1);
            }

            return max.Item1;
        }
    }
}