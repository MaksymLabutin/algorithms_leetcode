using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        
         
        [Test]
        public void Test1()
        {
            var input = new int[] {3, 1, 2, 4};
            var actual = SortArrayByParity(input);
            var expected = new int[] {4, 2, 1, 3};
            CollectionAssert.AreEqual(expected, actual);
        }

        public int[] SortArrayByParity(int[] A)
        { 
            var l = 0;
            var r = A.Length - 1;
            while (l < r)
            {
                if (A[l] % 2 != 0 && A[r] % 2 == 0) Swap(A, l++, r--);
                else if (A[r] % 2 == 0) l++;
                else r--;
            }

            return A;
        }

        private void Swap(int[] A, int l, int r)
        {
            var tmp = A[l];
            A[l] = A[r];
            A[r] = tmp;
        }
    }
}