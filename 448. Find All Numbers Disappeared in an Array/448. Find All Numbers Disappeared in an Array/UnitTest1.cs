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
            var nums = new int[] {4, 3, 2, 7, 8, 2, 3, 1};
            var actual = FindDisappearedNumbers(nums);
            var expected = new int[] {5, 6};
            CollectionAssert.AreEqual(expected, actual);
        }

        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            var res = new List<int>(nums.Length);
            for (var i = 1; i <= nums.Length; i++)
            {
                res.Add(i);
            }

            for (var i = 0; i < nums.Length; i++)
            {
                res[nums[i] - 1] = -1;
            }

            return res.Where(_ => _ > 0).ToList();
        }
    }
}