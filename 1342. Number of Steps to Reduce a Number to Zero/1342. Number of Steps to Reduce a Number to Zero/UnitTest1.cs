using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var num = 14;
            var actual = NumberOfSteps(num);
            var expected = 6;
            Assert.AreEqual(expected, actual);
        }

        public int NumberOfSteps(int num)
        {

            var step = 0;
            while (num > 0)
            {
                if (num % 2 == 0) num = num >> 1;
                else num -= 1;
                step++;
            }

            return step;
        }
    }
}