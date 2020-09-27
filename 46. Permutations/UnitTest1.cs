using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var nums = new int[] { 1, 2, 3 };
            var actual = Permute(nums);
            var expected = new List<List<int>>()
            {

                new List<int>{1, 2, 3},
                new List<int>{1, 3, 2},
                new List<int>{2, 1, 3},
                new List<int>{2, 3, 1},
                new List<int>{3, 1, 2},
                new List<int>{3, 2, 1},
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        private IList<IList<int>> _res;
        public IList<IList<int>> Permute(int[] nums)
        {
            _res = new List<IList<int>>();
            if (nums.Length == 0) return _res;

            Permute(nums, new HashSet<int>());

            return _res;
        }

        public void Permute(int[] nums, HashSet<int> values)
        {
            if (nums.Length == values.Count)
            {
                _res.Add(new List<int>(values));
                return;
            } 

            foreach (var num in nums)
            { 
                if(values.Contains(num)) continue;
                values.Add(num);
                Permute(nums, values);
                values.Remove(num);
            } 
        }

    }
}