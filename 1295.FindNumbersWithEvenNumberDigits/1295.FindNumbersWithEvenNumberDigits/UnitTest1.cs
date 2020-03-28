using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var nums = new []{ 12, 345, 2, 6, 7896};

            var res = FindNumbers(nums);

            var expectedRes = 2;
            Assert.AreEqual(expectedRes, res);
        }


        [Test]
        public void Test2()
        {
            var nums = new[] { 555, 901, 482, 1771 };

            var res = FindNumbers(nums);

            var expectedRes = 1;
            Assert.AreEqual(expectedRes, res);
        }

        public int FindNumbers(int[] nums)
        {
            var counter = 0;
            foreach (var num in nums)
            {
                if (num.ToString().Length % 2 == 0) counter++;
            }

            return counter;
        }
    }
}