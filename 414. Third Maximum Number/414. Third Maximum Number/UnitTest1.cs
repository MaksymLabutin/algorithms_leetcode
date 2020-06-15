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
            var nums = new int[] { 3, 2, 1 };
            var actual = ThirdMax(nums);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var nums = new int[] { 1, 2 };
            var actual = ThirdMax(nums);
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var nums = new int[] { 2, 2, 3, 1 };
            var actual = ThirdMax(nums);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        public int ThirdMax(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var sortedArray = Sort(nums.ToList());

            if (nums.Length < 3) return sortedArray[sortedArray.Count - 1];

            var k = 3;

            var i = sortedArray.Count - 2;
            for (; i >= 0; i--)
            {
                if (sortedArray[i] >= sortedArray[i + 1]) continue;
                k--;
                if(k == 1) break;
            }

            return k == 1 ? sortedArray[i] : sortedArray[sortedArray.Count - 1];
        }

        private List<int> Sort(List<int> nums)
        {
            if (nums.Count < 2) return nums;

            var mid = nums.Count / 2;

            var lArray = Sort(nums.Take(mid).ToList());
            var rArray = Sort(nums.TakeLast(nums.Count - mid).ToList());

            return Merge(lArray, rArray);
        }

        private List<int> Merge(List<int> lArray, List<int> rArray)
        {
            var capacity = lArray.Count + rArray.Count;
            var res = new List<int>(capacity);

            var lPointer = 0;
            var rPointer = 0;

            for (var i = 0; i < capacity; i++)
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