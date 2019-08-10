using System.Collections.Generic;
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
            var res = TwoSum(new int[] {2, 7, 11, 15}, 9);

            CollectionAssert.AreEqual(res, new int[]{0,1});
        }

        public int[] TwoSum(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();

            for (int index = 0; index < nums.Length; index++)
            {
                var searchInd = target - nums[index];

                if (dic.ContainsKey(searchInd)) return new[] {dic[searchInd], index};

                if(dic.ContainsKey(nums[index])) continue;
                
                dic.Add(nums[index], index);
            }

            return new int[]{};
        }
    }
}