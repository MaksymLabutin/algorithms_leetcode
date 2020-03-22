using NUnit.Framework;

namespace SearchInsertPosition
{
    public class SearchInsertTests
    { 

        [Test]
        public void Showd_return_index_2_When_target_is_in_the_second_index()
        {
            var arr = new int[]{ 1, 3, 5, 6 };
            var target = 5; 

            var res = SearchInsert(arr, target);

            var expectedIndex = 2;
            Assert.AreEqual(res, expectedIndex);
        }


        [Test]
        public void Showd_return_index_1_When_target_is_between_biger_and_smaller()
        {
            var arr = new int[] { 1, 3, 5, 6 };
            var target = 2;

            var res = SearchInsert(arr, target);

            var expectedIndex = 1;
            Assert.AreEqual(res, expectedIndex);
        }
        
        [Test]
        public void Showd_return_last_index_When_target_is_biggest()
        {
            var arr = new int[] { 1, 3, 5, 6 };
            var target = 7;

            var res = SearchInsert(arr, target);

            var expectedIndex = 4;
            Assert.AreEqual(res, expectedIndex);
        }
        
        [Test]
        public void Showd_return_index_0_When_target_is_smallest()
        {
            var arr = new int[] { 1, 3, 5, 6 };
            var target = 0;

            var res = SearchInsert(arr, target);

            var expectedIndex = 0;
            Assert.AreEqual(res, expectedIndex);
        }


        [Test]
        public void Showd_return_index_1_When_target_is_biggest()
        {
            var arr = new int[] { -1 };
            var target = 0;

            var res = SearchInsert(arr, target);

            var expectedIndex = 1;
            Assert.AreEqual(res, expectedIndex);
        }


        [Test]
        public void Showd_return_index_1_When_target_is_middle()
        {
            var arr = new int[] { -1 ,2};
            var target = 0;

            var res = SearchInsert(arr, target);

            var expectedIndex = 1;
            Assert.AreEqual(res, expectedIndex);
        }


        [Test]
        public void Showd_return_2_index_When_target_is_existed_in_array()
        {
            var arr = new int[] { 1, 4, 6, 7, 8, 9 };
            var target = 6;

            var res = SearchInsert(arr, target);

            var expectedIndex = 2;
            Assert.AreEqual(res, expectedIndex);
        }


        [Test]
        public void Showd_return_last_index_When_target_is_the_same_as_last()
        {
            var arr = new int[] { 1, 2 };
            var target = 2;

            var res = SearchInsert(arr, target);

            var expectedIndex = 1;
            Assert.AreEqual(res, expectedIndex);
        }


        [Test]
        public void Showd_return_1_index_When_target_is_the_same_as_1_element()
        {
            var arr = new int[] { 1, 3, 4, 5, 6 };
            var target = 3;

            var res = SearchInsert(arr, target);

            var expectedIndex = 1;
            Assert.AreEqual(res, expectedIndex);
        }


        public int SearchInsert(int[] nums, int target)
        {
            if (nums.Length == 0 || nums[0] >= target) return 0;
            if (nums[nums.Length - 1] < target) return nums.Length;

            var left = 0;
            var right = nums.Length;

            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (nums[mid] >= target)
                {
                    if (nums[mid - 1] < target) return mid;
                    if (target == nums[mid]) return mid - 1;
                    right = mid - 1;
                }
                else
                {
                    if (nums[mid + 1] >= target) return mid + 1;
                    left = mid;
                } 
            }

            return 0;
        }
    }
}