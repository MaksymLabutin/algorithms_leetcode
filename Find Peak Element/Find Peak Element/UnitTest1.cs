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
            var res = FindPeakElement(new[] { 1, 2, 3, 1 });

            Assert.AreEqual(res, 2);
        }

        [Test]
        public void Test2()
        {
            var res = FindPeakElement(new[] { 10, 20, 10, 30, 50, 60, 40 });

            Assert.IsTrue(res == 1 || res == 5);
        }

        [Test]
        public void Test3()
        {
            var res = FindPeakElement(new[] { 1, 2, 1, 3, 5, 6 });

            Assert.IsTrue(res == 1 || res == 5 );
        }

        [Test]
        public void Test4()
        {
            var res = FindPeakElement(new[] { 1, 2});

            Assert.IsTrue(res == 1);
        }

        [Test]
        public void Test5()
        {
            var res = FindPeakElement(new[] { 2, 1});

            Assert.IsTrue(res == 0);
        }

        public int FindPeakElement(int[] nums)
        {
            if (nums.Length < 2) return 0;

            int left = 0, right = nums.Length;

            while (true)
            {
                var mid = left + (right - left) / 2;

                var beforeValue = mid == 0 ? int.MinValue : nums[mid - 1];
                var nextValue = mid == nums.Length - 1 ? int.MinValue : nums[mid + 1];
                if (nums[mid] > beforeValue && nums[mid] > nextValue) return mid;

                if (beforeValue < nums[mid] && nextValue > nums[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
                
            }
        }
    }
}