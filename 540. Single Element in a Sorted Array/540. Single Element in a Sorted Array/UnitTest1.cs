using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var nums = new int[]{ 1, 1, 2, 3, 3, 4, 4, 8, 8 };
            var actual = SingleNonDuplicate(nums);
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var nums = new int[]{ 3, 3, 7, 7, 10, 11, 11 };
            var actual = SingleNonDuplicate(nums);
            var expected = 10;
            Assert.AreEqual(expected, actual);
        }

        public int SingleNonDuplicate(int[] nums)
        {

            var val = 0;
            foreach (var num in nums)
            {
                val ^= num;
            }

            return val;

        }
    }
}