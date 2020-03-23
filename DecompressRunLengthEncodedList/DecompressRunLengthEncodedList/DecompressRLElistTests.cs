using System.Text;
using NUnit.Framework;

namespace DecompressRunLengthEncodedList
{
    public class DecompressRLElistTests
    {
         

        [Test]
        public void Test1()
        {
            var nums = new[] {1, 2, 3, 4};

            var res = DecompressRLElist(nums);

            var expectedRes = new[] {2, 4, 4, 4};

            CollectionAssert.AreEqual(expectedRes, res);
        }


        [Test]
        public void Test2()
        {
            var nums = new[] { 1, 1, 2, 3 };

            var res = DecompressRLElist(nums);

            var expectedRes = new[] { 1,3,3 };

            CollectionAssert.AreEqual(expectedRes, res);
        }


        public int[] DecompressRLElist(int[] nums)
        {

            var lenght = 0;

            for (int i = 0; i < nums.Length; i += 2)
            {
                lenght += nums[i];
            }

            var res = new int[lenght];
            var pointer = 0;
            for (var i = 0; i < nums.Length; i += 2)
            {
                for (int j = 0; j < nums[i]; j++)
                {
                    res[pointer++] = nums[i + 1];
                }
            }

            return res;
        }
    }
}