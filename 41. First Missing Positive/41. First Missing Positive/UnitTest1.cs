using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            //Input: [1, 2, 0]
            //Output: 3
            var nums = new int[] {1, 2, 0};
            var actual = FirstMissingPositive(nums);
            var expected = 3;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test2()
        {  
            var nums = new int[] { 3, 4, -1, 1 };
            var actual = FirstMissingPositive(nums);
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test3()
        {  
            var nums = new int[] { 7, 8, 9, 11, 12 };
            var actual = FirstMissingPositive(nums);
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test4()
        {  
            var nums = new int[] { -1,-2 };
            var actual = FirstMissingPositive(nums);
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test5()
        {  
            var nums = new int[] { 0,1,2,3,4,5 };
            var actual = FirstMissingPositive(nums);
            var expected = 6;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test6()
        {  
            var nums = new int[] { 1 };
            var actual = FirstMissingPositive(nums);
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test7()
        {  
            var nums = new int[] {};
            var actual = FirstMissingPositive(nums);
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test8()
        {  
            var nums = new int[] {2,1};
            var actual = FirstMissingPositive(nums);
            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test9()
        {  
            var nums = new int[] {2};
            var actual = FirstMissingPositive(nums);
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test10()
        {  
            var nums = new int[] {1,1};
            var actual = FirstMissingPositive(nums);
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

         [Test]
        public void Test11()
        {
            var nums = new int[] { 3, 1 };
            var actual = FirstMissingPositive(nums);
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test12()
        {
            var nums = new int[] { 2, 1, 3 };
            var actual = FirstMissingPositive(nums);
            var expected = 4;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test13()
        {
            var nums = new int[] { 2, 1, 4 };
            var actual = FirstMissingPositive(nums);
            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test14()
        {
            var nums = new int[] { -10, -3, -100, -1000, -239, 1 };
            var actual = FirstMissingPositive(nums);
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test15()
        {
            var nums = new int[] {1, 2, 3, 10, 2147483647, 9 };
            var actual = FirstMissingPositive(nums);
            var expected = 4;

            Assert.AreEqual(expected, actual);
        }

        public int FirstMissingPositive(int[] nums)
        {
            if (nums.Length < 2)
            {
                if (nums.Length == 0) return 1;
                return nums[0] == 1 ? 2 : 1;
            } 

            for (var i = 0; i < nums.Length; i++)
            {
                if(nums[i] < 0 || nums[i] >= nums.Length || nums[i] == i) continue;

                Swap(nums, i);

                var j = i;
                while (j != nums[j])
                {  
                    if (nums[j] < 0 || nums[j] >= nums.Length  || nums[nums[j]] == nums[j]) break;

                    Swap(nums, j);
                }
            }

            for (var i = 1; i < nums.Length; i++)
            { 
                if (nums[i] != i) return i;
            }

            return nums[0] == nums[nums.Length - 1] + 1 ? nums[0] + 1 : nums.Length;
        }

        private void Swap(int[] arr, int i)
        {
            var tmp = arr[arr[i]];
            arr[arr[i]] = arr[i];
            arr[i] = tmp;
        }
    }
}