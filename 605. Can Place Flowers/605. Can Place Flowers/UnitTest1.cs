using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var flowerbed = new int[] { 1, 0, 0, 0, 1 };
            var n = 1;

            var actual = CanPlaceFlowers(flowerbed, n);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test2()
        {
            var flowerbed = new int[] { 1, 0, 0, 0, 1 };
            var n = 2;

            var actual = CanPlaceFlowers(flowerbed, n);

            Assert.False(actual);
        }

        [Test]
        public void Test3()
        {
            var flowerbed = new int[] { 0 };
            var n = 1;

            var actual = CanPlaceFlowers(flowerbed, n);

            Assert.True(actual);
        }

        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            if (n == 0) return true;
            if (flowerbed.Length == 1) return n <= 1 && flowerbed[0] == 0;

            for (var i = 0; i < flowerbed.Length; i++)
            {
                if (flowerbed[i] == 1) continue;

                if (i > 0 && i + 1 < flowerbed.Length)
                {
                    if (flowerbed[i - 1] != 0 || flowerbed[i + 1] != 0) continue;
                    n--;
                    flowerbed[i] = 1;
                }
                else if (i == 0)
                {
                    if (flowerbed[i + 1] != 0) continue;
                        n--;
                    flowerbed[i] = 1;
                }

                else
                {
                    if (flowerbed[i - 1] != 0) continue;
                    n--;
                    flowerbed[i] = 1;
                }

                if (n <= 0) return true; 
            }

            return n == 0; 
        }

        
    }
}