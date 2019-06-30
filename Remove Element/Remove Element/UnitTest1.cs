using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var arr = new int[] { 3, 2, 2, 3 };

            var res = RemoveElement(arr, 3);

            Assert.AreEqual(res, 2);
        }

        [Test]
        public void Test2()
        {
            var arr = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };

            var res = RemoveElement(arr, 2);

            Assert.AreEqual(res, 5);
        }

        public int RemoveElement(int[] nums, int val)
        {
            if (nums == null || nums.Length == 0) return 0;
            int start = 0, end = nums.Length - 1;
            while (start <= end)
            {
                if (nums[end] == val) end--;
                else if (nums[start] == val)
                { 
                    var temp = nums[end];
                    nums[end] = nums[start];
                    nums[start] = temp;
                    start++;
                    end--;
                }
                else start++;
            }
            return end + 1;
        }  
    }
}