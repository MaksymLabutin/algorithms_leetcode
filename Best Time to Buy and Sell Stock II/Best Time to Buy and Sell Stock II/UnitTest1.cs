using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var arr = new[] { 7, 1, 5, 3, 6, 4 };

            var res = MaxProfit(arr);

            var expectedRes = 7;

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void Test2()
        {
            var arr = new[] { 1, 2, 3, 4, 5 };

            var res = MaxProfit(arr);

            var expectedRes = 4;

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void Test3()
        {
            var arr = new[] { 7, 6, 4, 3, 1 };

            var res = MaxProfit(arr);

            var expectedRes = 0;

            Assert.AreEqual(expectedRes, res);
        }

        public int MaxProfit(int[] prices)
        {
            if (prices.Length < 2) return 0;

            var profit = 0;
            var minPrice = prices[0];
            var maxPrice = prices[0];

            for(var i = 0; i < prices.Length; i++)
            {
                if (prices[i] > maxPrice) maxPrice = prices[i];
                else
                {
                    profit += maxPrice - minPrice; 
                    minPrice = prices[i];
                    maxPrice = minPrice;
                }
            }

            if (maxPrice > minPrice)
            {
                profit += maxPrice - minPrice;
            }


            return profit;
        }
    }
}