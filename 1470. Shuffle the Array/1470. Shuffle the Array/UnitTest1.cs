using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var nums = new[] {2, 5, 1, 3, 4, 7};
            var n = 3;

            var actual = Shuffle(nums, n);

            var expected = new int[]{ 2, 3, 5, 4, 1, 7 };
            CollectionAssert.AreEqual(expected, actual);
        }

        public int[] Shuffle(int[] nums, int n)
        {
            var res = new int[nums.Length];
            var l = 0;
            var i = 0;
            while (i < nums.Length)
            {
                res[i++] = nums[l++];
                res[i++] = nums[n++];
            }
            return res;
        }
    }
}