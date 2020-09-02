using System;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var coins = new int[] {1, 2, 5};
            var amount = 11;

            var actual = CoinChange(coins, amount);

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test2()
        {
            var coins = new int[] { 2};

            var amount = 3;

            var actual = CoinChange(coins, amount);

            var expected = -1;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var coins = new int[] { 0};

            var amount = 0;

            var actual = CoinChange(coins, amount);

            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        public int CoinChange(int[] coins, int amount)
        {
            if (coins.Length < 0 || amount < 0) return -1;

            coins = coins.OrderBy(_ => _).ToArray();
            var dp = new int[amount + 1];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue;
            }
            dp[0] = 0;

            for (int i = 0; i < dp.Length; i++)
            {
                foreach (var coin in coins)
                {
                    if (i < coin) break;

                    if(dp[i - coin] == int.MaxValue) continue;
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }

            return dp[amount] == int.MaxValue ? -1 : dp[amount];
        }
    }
}