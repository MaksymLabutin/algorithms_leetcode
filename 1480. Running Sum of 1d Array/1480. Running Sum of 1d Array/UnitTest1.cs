using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        { 
            var nums = new int[] {1, 2, 3, 4};
            var actual = RunningSum(nums);
            var expected = new int[] {1, 3, 6, 10};
            CollectionAssert.AreEqual(expected, actual);
        }


        [Test]
        public void Test2()
        { 
            var nums = new int[] { 1, 1, 1, 1, 1 };
            var actual = RunningSum(nums);
            var expected = new int[] { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var nums = new int[] { 3, 1, 2, 10, 1 };
            var actual = RunningSum(nums);
            var expected = new int[] { 3, 4, 6, 16, 17 };
            CollectionAssert.AreEqual(expected, actual);
        }

        public int[] RunningSum(int[] nums)
        {
            for (var i = 1; i < nums.Length; i++)
            {
                nums[i] += nums[i - 1];
            } 

            return nums;
        }
    }
}