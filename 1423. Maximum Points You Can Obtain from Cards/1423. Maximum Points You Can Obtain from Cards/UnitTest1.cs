using System;
using Xunit;

namespace _1423._Maximum_Points_You_Can_Obtain_from_Cards
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var cardPoints = new int[] {1, 2, 3, 4, 5, 6, 1};
            var k = 3;

            var actual = MaxScore(cardPoints, k);

            var expected = 12;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Test2()
        {
            var cardPoints = new int[] { 2, 2, 2 };
            var k = 2;

            var actual = MaxScore(cardPoints, k);

            var expected = 4;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test3()
        {
            var cardPoints = new int[] {        9,7,7,9,7,7,9};
            var k = 7;

            var actual = MaxScore(cardPoints, k);

            var expected = 55;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Test4()
        {
            var cardPoints = new int[] { 1, 1000, 1 };
            var k = 1;

            var actual = MaxScore(cardPoints, k);

            var expected = 1;

            Assert.Equal(expected, actual);
        }
       

        [Fact]
        public void Test5()
        {
            var cardPoints = new int[] { 1, 79, 80, 1, 1, 1, 200, 1 };
            var k = 3;

            var actual = MaxScore(cardPoints, k);

            var expected = 202;

            Assert.Equal(expected, actual);
        }
        public int MaxScore(int[] cardPoints, int k)
        {

            var prevLeftValue = 0;

            for (int i = 0; i < k; i++)
            {
                prevLeftValue += cardPoints[i];
            }

            var max = prevLeftValue;

            var prevRightValue = 0;
            for (int i = 0; i < k; i++)
            {
                prevLeftValue -= cardPoints[k - i - 1];
                prevRightValue += cardPoints[cardPoints.Length - 1 - i];
                max = Math.Max(max, prevLeftValue + prevRightValue);
            }

            return max;
        }
    }
}
