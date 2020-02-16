using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var nums1 = new[] {1, 2, 3, 0, 0, 0}; 
            Merge(nums1, 3, new[] {2, 5, 6}, 3);

            CollectionAssert.AreEqual(nums1, new int[]{1,2,2,3,5,6});
        }

        [Test]
        public void Test2()
        {
            var nums1 = new[] {0}; 
            Merge(nums1, 0, new[] {1}, 1);

            CollectionAssert.AreEqual(nums1, new int[]{1});
        }

        [Test]
        public void Test3()
        {
            var nums1 = new[] { 4, 0, 0, 0, 0, 0 }; 
            Merge(nums1, 1, new[] { 1, 2, 3, 5, 6 }, 5);

            CollectionAssert.AreEqual(nums1, new int[]{1, 2, 3, 4, 5, 6});
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if(n == 0) return;

            while (m + n > 0)
            {

                if (m - 1 >= 0 && nums1[m - 1] > nums2[n - 1])
                {
                    nums1[m + n - 1] = nums1[m - 1];
                    nums1[m - 1] = 0;
                    m--;
                }
                else
                {
                    nums1[m + n - 1] = nums2[--n];
                    if (n <= 0) return;

                }
            }
          
            
        }
    }
}