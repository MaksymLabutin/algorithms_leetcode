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
            var res = SingleNumber(new int[] { 2, 2, 1 });

            Assert.AreEqual(res, 1);
        }

        [Test]
        public void Test2()
        {
            var res = SingleNumber(new int[] { 4, 1, 2, 1, 2 });

            Assert.AreEqual(res, 4);
        }

        public int SingleNumber(int[] nums)
        {
            var set = new HashSet<int>();

            for (var i = 0; i < nums.Length; i++)
            { 
                if (set.Contains(nums[i])) set.Remove(nums[i]);
                else
                {
                    set.Add(nums[i]);
                }
            }

            return set.FirstOrDefault();
        }
    }
}