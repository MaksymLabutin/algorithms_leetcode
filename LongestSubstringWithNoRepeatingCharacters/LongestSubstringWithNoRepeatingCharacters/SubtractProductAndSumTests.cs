using NUnit.Framework;

namespace LongestSubstringWithNoRepeatingCharacters
{
    public class SubtractProductAndSumTests
    { 

        [Test]
        public void Test1()
        {
            var n = 234;

            var res = SubtractProductAndSum(n);

            var expectedRes = 15;

            Assert.AreEqual(expectedRes, res);
        }


        [Test]
        public void Test2()
        {
            var n = 0;

            var res = SubtractProductAndSum(n);

            var expectedRes = 0;

            Assert.AreEqual(expectedRes, res);
        }



        [Test]
        public void Test3()
        {
            var n = 4421;

            var res = SubtractProductAndSum(n);

            var expectedRes = 21;

            Assert.AreEqual(expectedRes, res);
        }


        public int SubtractProductAndSum(int n)
        {
            var sum = 0;
            var prod = 1;

            foreach (var symbol in n.ToString())
            {
                sum += int.Parse(symbol.ToString());
                prod *= int.Parse(symbol.ToString());
            }

            return prod - sum;
        }
    }
}