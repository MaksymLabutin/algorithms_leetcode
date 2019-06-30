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
            var res = FindMaxConsecutiveOnes(new int[] {1, 1, 0, 1, 1, 1});
            
            Assert.AreEqual(res, 3);
        }

        [Test]
        public void Test2()
        {
            var res = FindMaxConsecutiveOnes(new int[] {1, 0, 0, 0, 0, 0});
            
            Assert.AreEqual(res, 1);
        }

        [Test]
        public void Test3()
        {
            var res = FindMaxConsecutiveOnes(new int[] {0, 0, 0, 0, 0, 0});
            
            Assert.AreEqual(res, 0);
        }

        [Test]
        public void Test4()
        {
            var res = FindMaxConsecutiveOnes(new int[] {0, 1, 1, 1, 1, 1});
            
            Assert.AreEqual(res, 5);
        }

        [Test]
        public void Test5()
        {
            var res = FindMaxConsecutiveOnes(new int[] { 1, 0, 1, 1, 0, 1 });
            
            Assert.AreEqual(res, 2);
        }


        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int currIterations = 0, maxIterations = 0;

            for (var index = 0; index < nums.Length; index++)
            {
                if (nums[index] == 0)
                { 
                    maxIterations = maxIterations > currIterations ? maxIterations : currIterations;
                    currIterations = 0;
                }
                else
                {
                    currIterations++;
                }
            }

            return maxIterations > currIterations ? maxIterations : currIterations;
        }
    }
}