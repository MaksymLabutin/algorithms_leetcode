using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            //[2,3,5,1,3], extraCandies = 3
            var candies = new[] {2, 3, 5, 1, 3};
            var extraCandies = 3;

            var acutal = KidsWithCandies(candies, extraCandies);
            
            CollectionAssert.AreEqual(new List<bool>(){ true, true, true, false, true }, acutal );
        }

        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            var res = new List<bool>();

            var max = int.MinValue;

            for (int i = 0; i < candies.Length; i++)
            {
                max = candies[i] > max ? candies[i] : max;
            }

            foreach (var candy in candies)
            {
                res.Add(candy + extraCandies >= max);
            }

            return res;
        }
    }
}