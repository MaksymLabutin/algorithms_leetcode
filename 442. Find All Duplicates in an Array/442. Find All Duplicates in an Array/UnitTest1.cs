using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var nums = new int[] { 4, 3, 2, 7, 8, 2, 3, 1 };
            var actual = FindDuplicates(nums);
            var expected = new List<int>() { 3,2 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var nums = new int[] { 1,2,3,4,5 };
            var actual = FindDuplicates(nums);
            var expected = new List<int>() { };
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var nums = new int[] { 1,2,3,4,5,1,2,4,5 };
            var actual = FindDuplicates(nums);
            var expected = new List<int>() { 1,2,4,5};
            CollectionAssert.AreEqual(expected, actual);
        }

        public IList<int> FindDuplicates(int[] nums)
        {
            var res = new HashSet<int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (i + 1 != nums[i])
                {
                    while (nums[i] != i + 1)
                    {
                        if (nums[i] == nums[nums[i] - 1])
                        {
                            if(!res.Contains(nums[i])) res.Add(nums[i]);
                            break;
                        }
                        var tmp = nums[i]; 
                        nums[i] = nums[nums[i] - 1];
                        nums[tmp - 1] = tmp;
                    }
                }
            }

            return res.ToList();
        }
    }
}