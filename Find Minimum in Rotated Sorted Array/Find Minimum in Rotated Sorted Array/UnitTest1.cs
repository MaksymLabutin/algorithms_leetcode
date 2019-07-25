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
            var res = FindMin(new[] { 4, 5, 6, 7, 0, 1, 2 });
            Assert.AreEqual(res, 0);
        }

        [Test]
        public void Test2()
        {
            var res = FindMin(new[] { 0, 1, 2, 4, 5, 6, 7});
            Assert.AreEqual(res, 0);
        }


        [Test]
        public void Test3()
        {
            var res = FindMin(new[] {1, 2, 4, 5, 6, 7, 0});
            Assert.AreEqual(res, 0);
        }

        [Test]
        public void Test4()
        {
            var res = FindMin(new[] {6, 7, 0, 1, 2, 4, 5 });
            Assert.AreEqual(res, 0);
        }
        [Test]
        public void Test5()
        {
            var res = FindMin(new[] {7, 0, 1, 2, 4, 5, 6 });
            Assert.AreEqual(res, 0);
        }
        [Test]
        public void Test6()
        {
            var res = FindMin(new[] {7});
            Assert.AreEqual(res, 7);
        }

        public int FindMin(int[] nums)
        {  
            int left = 0, right = nums.Length;

            while (left < right)
            {
                var mid = left + (right - left) / 2; 
                if (nums[mid] > nums[mid - 1] && nums[mid] > nums[0])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            
            return nums[left];
        }
    }
}