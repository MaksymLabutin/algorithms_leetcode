using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var A = new int[][]
            {
                new []{ 1, 2, 3 },
                new []{ 4, 5, 6 },
                new []{ 7, 8, 9 }

            };

            var actual = MinFallingPathSum(A);

            var expected = 12;
            Assert.AreEqual(expected, actual);
        }

        public int MinFallingPathSum(int[][] A)
        {

            if (A.Length == 1) return 1;//todo

            for (var i = A.Length - 1; i >= 0; i++)
            {
                for (var j = A[i].Length - 2; j < A[0].Length; j--)
                {
                    if(i > 0 && j + 1 <= )
                    A[]
                }
            }
            return 1;
        }
    }
}