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
            var res = SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8);
            CollectionAssert.AreEqual(res, new[] { 3, 4 });
        }

        [Test]
        public void Test2()
        {
            var res = SearchRange(new int[] { 1, 1, 1, 1, 1, 10 }, 1);
            CollectionAssert.AreEqual(res, new[] { 0, 4 });
        }

        [Test]
        public void Test3()
        {
            var res = SearchRange(new int[] { 0, 1, 1, 1, 1, 10 }, 1);
            CollectionAssert.AreEqual(res, new[] { 1, 4 });
        }

        [Test]
        public void Test4()
        {
            var res = SearchRange(new int[] { 0, 1, 1, 1, 1, 1 }, 1);
            CollectionAssert.AreEqual(res, new[] { 1, 5 });
        }

        [Test]
        public void Test5()
        {
            var res = SearchRange(new int[] { 1, 1, 1, 1, 1, 1 }, 1);
            CollectionAssert.AreEqual(res, new[] { 0, 5 });
        }

        [Test]
        public void Test6()
        {
            var res = SearchRange(new int[] { 0, 1, 2, 2, 2, 2 }, 1);
            CollectionAssert.AreEqual(res, new[] { 1, 1 });
        }

        [Test]
        public void Test7()
        {
            var res = SearchRange(new int[] { 0, 1, 2, 2, 2, 2 }, 6);
            CollectionAssert.AreEqual(res, new[] { -1, -1 });
        }

        [Test]
        public void Test8()
        {
            var res = SearchRange(new int[] { 1 }, 1);
            CollectionAssert.AreEqual(res, new[] { 0, 0 });
        }

        [Test]
        public void Test9()
        {
            var res = SearchRange(new int[] { 1, 3 }, 1);
            CollectionAssert.AreEqual(res, new[] { 0, 0 });
        }

        public int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length < 1) return new int[] { -1, -1 };

            if (nums.Length == 1) return target == nums[0] ? new[] {0,0} : new int[] { -1, -1 };

            int left = 0, right = nums.Length;

            while (left < right)
            {
                var mid = left + (right - left) / 2;

                if (nums[mid] != target)
                {
                    if (nums[mid] < target)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                else
                {
                    int start = mid, end = mid;

                    while (start >= 0 && end < nums.Length)
                    {
                        if (nums[start] != target && nums[end] != target) return new[] { ++start, --end };

                        if (nums[start] == target) start--;
                        if (nums[end] == target) end++;
                    }

                    start = start >= 0 && nums[start] == target ? start : start + 1;
                    end = end < nums.Length && nums[end] == target ? end : end - 1;

                    return new[] { start, end };
                }
            }

            if (left != nums.Length && nums[left] == target) return new[] {left, left};

            return new[] { -1, -1 };
        }
    }
}