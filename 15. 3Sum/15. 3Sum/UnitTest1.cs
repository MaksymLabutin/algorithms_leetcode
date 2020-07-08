using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var nums = new int[] { -1, 0, 1, 2, -1, -4 };

            var actual = ThreeSum(nums);

            var expected = new List<IList<int>>
            {
                new List<int>(){-1, -1, 2},
                new List<int>(){-1, 0, 1}
            };

            CollectionAssert.AreEqual(expected, actual); ;
        }

        [Test]
        public void Test2()
        {
            var nums = new int[] { -1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            var actual = ThreeSum(nums);

            var expected = new List<IList<int>>
            {
                new List<int>(){-1,0,1}, 
            };

            CollectionAssert.AreEqual(expected, actual); ;
        }

        [Test]
        public void Test3()
        {
            var nums = new int[] { -1, 0, 1, 1, 1, 1,  1, 1, 1, 1, 1, 1000, -1000, -2000, 2000, 11111, -11111 };

            var actual = ThreeSum(nums);
            var expected = new List<IList<int>>
            {
                new List<int>(){-11111,0,11111}, 
                new List<int>(){-2000,0,2000}, 
                new List<int>(){-1000,0,1000}, 
                new List<int>(){-1,0,1}
            };

            CollectionAssert.AreEqual(expected, actual); ;
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var threeSum = new List<IList<int>>();

            if (nums.Length < 3) return threeSum;

            var memo = new HashSet<(int, int, int)>();
            var dictionary = new Dictionary<int, List<int>>(); 

            var sortedArray = nums.ToList().OrderBy(_ => _).ToList();

            for (var i = 0; i < sortedArray.Count; i++)
            {
                if (dictionary.ContainsKey(sortedArray[i])) dictionary[sortedArray[i]].Add(i);
                else dictionary.Add(sortedArray[i], new List<int>() { i });
            }

            var visited = new HashSet<int>();
            for (var x = 0; x < sortedArray.Count - 1; x++)
            {
                if(visited.Contains(sortedArray[x])) continue;
                visited.Add(sortedArray[x]);

                for (var y = x + 1; y < sortedArray.Count; y++)
                {
                    var val = 0 - (sortedArray[x] + sortedArray[y]);

                    if (!dictionary.ContainsKey(val) || !dictionary[val].Any(_ => _ != x && _ != y)) continue;
                    {
                        var arr = new List<int> { sortedArray[x], sortedArray[y], val }.OrderBy(_ => _).ToList();
                        if (memo.Contains((arr[0], arr[1], arr[2]))) continue;

                        memo.Add((arr[0], arr[1], arr[2]));
                        threeSum.Add(arr);
                    }

                }
            }

            return threeSum;
        }
    }
}