using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var nums = new int[] {1, 2, 3, 1, 1, 3};

            var actual = NumIdenticalPairs(nums);

            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var nums = new int[] { 1, 1, 1, 1 };

            var actual = NumIdenticalPairs(nums);

            var expected = 6;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var nums = new int[] { 1, 2, 3 };

            var actual = NumIdenticalPairs(nums);

            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4()
        {
            var nums = new int[] {  };

            var actual = NumIdenticalPairs(nums);

            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        public int NumIdenticalPairs(int[] nums)
        {
            var memo = new Dictionary<int, int>();

            foreach (var el in nums)
            {
                if (memo.ContainsKey(el)) memo[el] += 1;
                else memo.Add(el, 1);
            }

            var pairs = 0;

            foreach (var el in memo)
            {
                pairs += el.Value * (el.Value - 1) / 2;
            }

            return pairs;
        }
    }
}