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
            var nums = new int[] {3, 1, 4, 1, 5};
            var k = 2;

            var actual = FindPairs(nums, k);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }
       
        [Test]
        public void Test2()
        {
            var nums = new int[] { 1, 2, 3, 4, 5 };
            var k = 1;

            var actual = FindPairs(nums, k);

            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var nums = new int[] { 1, 3, 1, 5, 4 };
            var k = 0;

            var actual = FindPairs(nums, k);

            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4()
        {
            var nums = new int[] { 1, 2, 4, 4, 3, 3, 0, 9, 2, 3 };
            var k = 3;

            var actual = FindPairs(nums, k);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test5()
        {
            var nums = new int[] { -1, -2, -3 };
            var k = 1;

            var actual = FindPairs(nums, k);

            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        public int FindPairs(int[] nums, int k)
        {
            if (nums.Length == 0) return 0;

            nums = nums.OrderBy(_ => _).ToArray();

            var uniqe = new HashSet<(int, int)>();
            var answer = 0;

            for (var i = 0; i < nums.Length; i++)
            { 
                var j = nums.Length - 1;
                while (i < j)
                {
                    var diff = nums[j] - nums[i];
                    if (diff <= k)
                    {
                        if (diff == k && !uniqe.Contains((nums[i], nums[j])))
                        {
                            answer += 1;
                            uniqe.Add((nums[i], nums[j]));
                        }
                        break;
                    }

                    j--;

                } 
            }

            return answer;
        }
    }
}