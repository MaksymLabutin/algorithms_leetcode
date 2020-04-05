using NUnit.Framework;

namespace Tests
{
    public class Tests
    {


        [Test]
        public void Test1()
        {
            var arr = new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

            var res = MaxSubArray(arr);

            var expectedRes = 6;

            Assert.AreEqual(expectedRes, res);
        }



        [Test]
        public void Test2()
        {
            var arr = new int[0];

            var res = MaxSubArray(arr);

            var expectedRes = 0;

            Assert.AreEqual(expectedRes, res);
        }


        [Test]
        public void Test3()
        {
            var arr = new int[] { 1 };

            var res = MaxSubArray(arr);

            var expectedRes = 1;

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void Test4()
        {
            var arr = new int[] { -1 };

            var res = MaxSubArray(arr);

            var expectedRes = -1;

            Assert.AreEqual(expectedRes, res);
        }
         

        [Test]
        public void Test5()
        {
            var arr = new int[] {-2, -1 };

            var res = MaxSubArray(arr);

            var expectedRes = -1;

            Assert.AreEqual(expectedRes, res);
        }
         
        [Test]
        public void Test6()
        {
            var arr = new int[] {1, 2 };

            var res = MaxSubArray(arr);

            var expectedRes = 3;

            Assert.AreEqual(expectedRes, res);
        }
        
        public int MaxSubArray(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int sum = 0, max = int.MinValue;
            foreach (var num in nums)
            {
                sum += num;
                max = max > sum ? max : sum;
                if (sum < 0) sum = 0;
            }

            return max;
        }
    }
}