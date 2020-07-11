using System.Collections;
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
            var nums = new int[] {1, 2};
            var actual = Subsets(nums);

            var expected = new List<IList<int>>()
            {
                new List<int>() {1},
                new List<int>() {2},
                new List<int>() {1, 2},
                new List<int>() { }
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        public IList<IList<int>> Subsets(int[] nums)
        {

            if (nums.Length == 0) return new List<IList<int>>() {new List<int>()};

            var res = new List<IList<int>>(){new List<int>{ nums[0] } };
           
            for (var i = 1; i < nums.Length; i++)
            {
                var tmp = new List<IList<int>>();

                foreach (var arr in res)
                {
                    var copiedArr = new int[arr.Count + 1];
                    arr.CopyTo(copiedArr, 0);
                    copiedArr[copiedArr.Length - 1] = nums[i];
                    tmp.Add(copiedArr);
                }
                res.Add(new List<int>() { nums[i] });
                res.AddRange(tmp);
            }
           

            res.Add(new List<int>());

            return res;
        }
    }
}