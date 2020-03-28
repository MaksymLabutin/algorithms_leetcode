using NUnit.Framework;

namespace CountNegativeNumbersSortedMatrix
{
    public class Tests
    {


        [Test]
        public void Test1()
        {
            var grid = new int[][] {new [] { 4, 3, 2, -1 } , new []{ 3, 2, 1, -1 }, new []{ 1, 1, -1, -2 }, new []{ -1, -1, -2, -3 } };

            var res = CountNegatives(grid);

            var expectedRes = 8;
            Assert.AreEqual(expectedRes, res);
        }


        [Test]
        public void Test2()
        {
            var grid = new int[][] { new[] { 3,2 }, new[] { 1,0 }};

            var res = CountNegatives(grid);

            var expectedRes = 0;
            Assert.AreEqual(expectedRes, res);
        }

        
        [Test]
        public void Test3()
        {
            var grid = new int[][] { new[] { -1, -1 }, new[] { -1, -1} };

            var res = CountNegatives(grid);

            var expectedRes = 4;
            Assert.AreEqual(expectedRes, res);
        }

        public int CountNegatives(int[][] grid)
        {
            var counter = 0;

            foreach (var arr in grid)
            {
                if (arr[arr.Length - 1] >= 0) continue;

                if (arr[0] < 0)
                {
                    counter += arr.Length;
                    continue;
                }

                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] >= 0) break;
                    counter++;
                }
            }

            return counter;
        }
    }
}