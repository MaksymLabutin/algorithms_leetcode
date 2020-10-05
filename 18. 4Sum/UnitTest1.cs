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
            var nums = new int[] {1, 1, 1, 1, 1, 1};
            var target = 4;

            var actual = FourSum(nums, target);

            var extpected = new List<List<int>> {new List<int>() {1, 1, 1, 1}};
            CollectionAssert.AreEqual(extpected, actual);
        }


        [Test]
        public void Test2()
        {
            var nums = new int[] { 1, 0, -1, 0, -2, 2 };
            var target = 0;

            var actual = FourSum(nums, target);

            var extpected = new List<List<int>> {  new List<int>() { -2, -1, 1, 2 },  new List<int>(){ -2, 0, 0, 2 }, new List<int>() { -1, 0, 0, 1 } };
            CollectionAssert.AreEqual(extpected, actual);
        }
        
        [Test]
        public void Test3()
        {
            var nums = new int[] { 1, 0, -1 };
            var target = 0;

            var actual = FourSum(nums, target);

            var extpected = new List<List<int>> { };
            CollectionAssert.AreEqual(extpected, actual);
        }

        [Test]
        public void Test4()
        { 
            var nums = new int[] { -3, -1, 0, 2, 4, 5 };
            var target = 0;

            var actual = FourSum(nums, target);

            var extpected = new List<List<int>> { new List<int>(){ -3, -1, 0, 4 } };
            CollectionAssert.AreEqual(extpected, actual);
        }

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            if (nums.Length < 4) return new List<IList<int>>();
            var memo = new Dictionary<int, List<(int l, int r, int lIndex, int rIndex)>>();

            nums = nums.OrderBy(_ => _).ToArray();

            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    var sum = nums[i] + nums[j];

                    var tuple = (nums[i], nums[j], i, j);

                    if(!memo.ContainsKey(sum)) memo.Add(sum, new List<(int, int, int, int)>{tuple});
                    else
                    {
                        memo[sum].Add(tuple);
                    }
                }
            }

            var hs = new HashSet<IList<int>>(new SequenceComparer<int>());
            foreach (var sum in memo)
            {
                var searchVal = target - sum.Key;
                if(!memo.ContainsKey(searchVal)) continue;

                foreach (var valueTuple in sum.Value)
                {
                    foreach (var tuple in memo[searchVal])
                    {
                        if(tuple.lIndex == valueTuple.lIndex || tuple.rIndex == valueTuple.lIndex || tuple.rIndex == valueTuple.rIndex || tuple.lIndex == valueTuple.rIndex) continue;
                        var arr = new List<int> {tuple.l, tuple.r, valueTuple.l, valueTuple.r};
                        arr = arr.OrderBy(_ => _).ToList();
                        if(hs.Contains(arr)) continue;
                        hs.Add(arr);
                    }
                }
            }

            return new List<IList<int>>(hs);
        }

        class SequenceComparer<T> : IEqualityComparer<IEnumerable<T>>
        {
            public bool Equals(IEnumerable<T> seq1, IEnumerable<T> seq2)
            {
                return seq1.SequenceEqual(seq2);
            }

            public int GetHashCode(IEnumerable<T> seq)
            {
                int hash = 1234567;
                foreach (T elem in seq)
                    hash = hash * 37 + elem.GetHashCode();
                return hash;
            }
        }

    }
}