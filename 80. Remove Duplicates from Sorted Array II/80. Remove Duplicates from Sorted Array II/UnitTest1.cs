using NUnit.Framework;

namespace Tests
{
    public class Tests
    {


        [Test]
        public void Test1()
        {
            var nums = new int[] { 1, 1, 1, 2, 2, 3 };
            var actual = RemoveDuplicates(nums);
            var expected = 5;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test2()
        {
            var nums = new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 };
            var actual = RemoveDuplicates(nums);
            var expected = 7;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var nums = new int[] { 0, 0, 0, 0, 0 };
            var actual = RemoveDuplicates(nums);
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4()
        {
            var nums = new int[] { 0, 0, 0, 0, 0, 1 };
            var actual = RemoveDuplicates(nums);
            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test5()
        {
            var nums = new int[] {0, 1, 2, 2, 2, 2, 2, 3, 4, 4, 4 };
            var actual = RemoveDuplicates(nums);
            var expected = 7;

            Assert.AreEqual(expected, actual);
        }

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length < 2) return nums.Length;
            var i = 0;

            for (var j = 1; j < nums.Length; j++)
            {
                if (nums[i] == nums[j])
                {
                    if (i > 0 && nums[i] == nums[i - 1]) continue; 
                }

                i++; 
                nums[i] = nums[j]; 
            }

            return i + 1;
        }
    }
}