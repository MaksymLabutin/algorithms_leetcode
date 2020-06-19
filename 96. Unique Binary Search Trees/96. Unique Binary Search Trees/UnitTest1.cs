using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var n = 1;
            var actual = NumTrees(n);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test2()
        {
            var n = 2;
            var actual = NumTrees(n);
            var expected = 2;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test3()
        {
            var n = 3;
            var actual = NumTrees(n);
            var expected = 5;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test5()
        {
            var n = 5;
            var actual = NumTrees(n);
            var expected = 42;
            Assert.AreEqual(expected, actual);
        }

        public int NumTrees(int n)
        {
            if (n < 3) return n;

            var arr = new int[n + 1];
            arr[0] = 1;
            arr[1] = 1;
            arr[2] = 2;

            for (var i = 3; i <= n; i++)
            {
                var j = 0;
                for (; j < i; j++)
                {
                    arr[i] += arr[j] * arr[i - j - 1];
                } 
            }

            return arr[n];
        }
    }
}