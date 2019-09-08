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
            var res = TopKFrequent(new[] { 1, 1, 1, 2, 2, 3 }, 2);
            CollectionAssert.AreEqual(res, new List<int>{1,2});
        }

        [Test]
        public void Test2()
        {
            var res = TopKFrequent(new[] { 1, 1, 2, 2, 3,3,3,3,3,4,4,4,4,5,3,1,1,1,4,4,44, 3,3,3 }, 2);

            CollectionAssert.AreEqual(res, new List<int> {3, 4 });
        }

        public IList<int> TopKFrequent(int[] nums, int k)
        {
            var map = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (map.ContainsKey(num)) map[num] = map[num] + 1;
                else
                {
                    map.Add(num, 1);
                }
            }

            var res = map.OrderByDescending(_ => _.Value).Select(_ => _.Key).Take(k).ToList(); 
            return res;
        }
    }
}