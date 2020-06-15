using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var nums = new int[] { 3, 2, 1, 5, 6, 4 };
            var k = 2;

            var actual = FindKthLargest(nums, k);

            var expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var nums = new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            var k = 4;

            var actual = FindKthLargest(nums, k);

            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        public int FindKthLargest(int[] nums, int k)
        {
            if (nums.Length < 2) return nums.Length == 0 ? 0 : nums[0];

            var sortedArray = Sort(nums.ToList()); 

            return sortedArray[nums.Length - k];
        }

        private List<int> Sort(List<int> list)
        {
            if (list.Count < 2) return list;

            var mid = list.Count / 2;

            var lArray = Sort(list.Take(mid).ToList());
            var rArray = Sort(list.TakeLast(list.Count - mid).ToList());

            return Merge(lArray, rArray);
        }

        private List<int> Merge(List<int> lArray, List<int> rArray)
        {
            var capacity = lArray.Count + rArray.Count;

            var res = new List<int>(capacity);

            var lPointer = 0;
            var rPointer = 0;

            for (int i = 0; i < capacity; i++)
            {
                if (rPointer >= rArray.Count || lPointer < lArray.Count && lArray[lPointer] < rArray[rPointer])
                {
                    res.Add(lArray[lPointer++]);
                }
                else
                {
                    res.Add(rArray[rPointer++]);
                }
            }

            return res;
        }
    }
}