using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var res = FindMin(new[] { 4, 5, 6, 7, 0, 0, 1, 2 });
            Assert.AreEqual(res, 0);
        }

        [Test]
        public void Test2()
        {
            var res = FindMin(new[] { 0, 0, 1, 1, 2, 2, 4, 4, 5, 5, 5, 6, 7, 7, 7 });
            Assert.AreEqual(res, 0);
        }


        [Test]
        public void Test3()
        {
            var res = FindMin(new[] { 1, 1, 2, 2, 2, 2, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 7, 7, 7, 7, 7, 7, 7, 0 });
            Assert.AreEqual(res, 0);
        }

        [Test]
        public void Test4()
        {
            var res = FindMin(new[] { 6, 7, 0, 1, 2, 4, 5 });
            Assert.AreEqual(res, 0);
        }
        [Test]
        public void Test5()
        {
            var res = FindMin(new[] { 7, 0, 1, 2, 4, 5, 6 });
            Assert.AreEqual(res, 0);
        }
        [Test]
        public void Test6()
        {
            var res = FindMin(new[] { 7 });
            Assert.AreEqual(res, 7);
        }

        [Test]
        public void Test7()
        {
            var res = FindMin(new[] { 1, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 });
            Assert.AreEqual(res, 1);
        }

        [Test]
        public void Test8()
        {
            var res = FindMin(new[] { 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 });
            Assert.AreEqual(res, 7);
        }

        [Test]
        public void Test9()
        {
            var res = FindMin(new[] { 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 });
            Assert.AreEqual(res, 7);
        }


        [Test]
        public void Test10()
        {
            var res = FindMin(new[] { 2, 2, 2, 0, 1 });
            Assert.AreEqual(res, 0);
        }

        [Test]
        public void Test11()
        {
            var res = FindMin(new[] { 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 1 });
            Assert.AreEqual(res, 1);
        }

        [Test]
        public void Test12()
        {
            var res = FindMin(new[] { 3, 1, 3 });
            Assert.AreEqual(res, 1);
        }

        [Test]
        public void Test13()
        {
            var res = FindMin(new[] { 3, 1, 3, 3 });
            Assert.AreEqual(res, 1);
        }


        [Test]
        public void Test14()
        {
            var res = FindMin(new[] { 3, 1, 3, 3, 3, 3, 3, 3, 3, 3 });
            Assert.AreEqual(res, 1);
        }


        [Test]
        public void Test15()
        {
            var res = FindMin(new[] { 3, 1, 3, 3, 3, 3, 3, 3, 3, 4 });
            Assert.AreEqual(res, 1);
        }


        [Test]
        public void Test16()
        {
            var res = FindMin(new[] { 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2 });
            Assert.AreEqual(res, 0);
        }


        public int FindMin(int[] nums)
        {
            if (nums.Length < 2) return nums.Length < 1 ? 0 : nums[0];

            return nums[0] == nums[nums.Length - 1] ? TwoPointers(nums) : Bs(nums);
        }

        private int TwoPointers(int[] nums)
        {
            int left = 0, right = 1;

            while (right < nums.Length)
            {
                if (nums[left] > nums[right]) return nums[right];
                right++;
            }

            return nums[left];
        }

        private int Bs(int[] nums)
        {
            int left = 0, right = nums.Length;

            var min = int.MaxValue;

            while (left < right)
            {
                var mid = left + (right - left) / 2;

                if (mid == 0) break;


                if (nums[mid] < nums[mid - 1]) return nums[mid];
                if (nums[mid] >= nums[mid - 1] && nums[mid] > nums[0])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }

                min = min > nums[mid] ? nums[mid] : min;
            }


            left = 0;
            right = nums.Length;

            while (left < right)
            {
                var mid = left + (right - left) / 2;

                if (mid == 0 || nums[mid] < nums[mid - 1]) return nums[mid];
                if (nums[mid] >= nums[mid - 1] && nums[mid] >= nums[0])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }

                min = min > nums[mid] ? nums[mid] : min;
            }

            return left == nums.Length - 1 ? min : nums[0];
        }
    }
}