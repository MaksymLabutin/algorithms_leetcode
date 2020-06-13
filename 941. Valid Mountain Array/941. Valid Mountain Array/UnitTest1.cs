using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var A = new int[] { 2, 1 };
            var actual = ValidMountainArray(A);
            Assert.IsFalse(actual);
        }

        [Test]
        public void Test2()
        {
            var A = new int[] { 3, 5, 5 };
            var actual = ValidMountainArray(A);
            Assert.IsFalse(actual);
        }

        [Test]
        public void Test3()
        {
            var A = new int[] { 0, 3, 2, 1 };
            var actual = ValidMountainArray(A);
            Assert.IsTrue(actual);
        }


        [Test]
        public void Test4()
        {
            var A = new int[] { 0, 1, 0, 1 };
            var actual = ValidMountainArray(A);
            Assert.IsFalse(actual);
        }

        [Test]
        public void Test5()
        {
            var A = new int[] { 0, 1, 2, 3 };
            var actual = ValidMountainArray(A);
            Assert.IsFalse(actual);
        }

        [Test]
        public void Test6()
        {
            var A = new int[] { 5, 4, 3, 2, 1 };
            var actual = ValidMountainArray(A);
            Assert.IsFalse(actual);
        }

        public bool ValidMountainArray(int[] A)
        {
            if (A.Length < 3) return false;
            if (A[0] >= A[1]) return false;

            var isUp = true;

            for (var i = 0; i < A.Length - 1; i++)
            {
                if (A[i] > A[i + 1])
                {
                    isUp = false;
                }
                else
                {
                    if (!isUp || A[i] == A[i + 1]) return false;
                }
            }

            return !isUp;
        }
    }
}