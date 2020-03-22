using NUnit.Framework;

namespace NumberStepsReduceNumberToZero
{
    public class Tests
    { 

        [Test]
        public void Should_return_6_When_number_14()
        {
            var num = 14;

            var res = NumberOfSteps(num);

            var expectedRes = 6;

            Assert.AreEqual(res, expectedRes);
        }


        [Test]
        public void Should_return_12_When_number_123()
        {
            var num = 123;

            var res = NumberOfSteps(num);

            var expectedRes = 12;

            Assert.AreEqual(res, expectedRes);
        }


        public int NumberOfSteps(int num)
        {
            var stepst = 0;

            while (num > 0)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                }
                else
                {
                    num -= 1;
                }

                stepst++;
            }

            return stepst;
        }
    }
}