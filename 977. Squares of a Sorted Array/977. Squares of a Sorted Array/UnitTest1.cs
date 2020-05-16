using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            //[-4,-1,0,3,10]
            var A = new int[] { -4, -1, 0, 3, 10 };
            var actual = SortedSquares(A);
            var expected = new int[] { 0, 1, 9, 16, 100 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        { 
            var A = new int[] { -7, -3, 2, 3, 11 };
            var actual = SortedSquares(A);
            var expected = new int[] { 4, 9, 9, 49, 121 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        { 
            var A = new int[] { -1,1 };
            var actual = SortedSquares(A);
            var expected = new int[] { 1,1 };
            CollectionAssert.AreEqual(expected, actual);
        }

        public int[] SortedSquares(int[] A)
        {
            
            var startPointer = FindStartPositiveVal(A);
            var lPointer = startPointer - 1;
            var rPointer = startPointer;

            var res = new int[A.Length];
            var i = 0;
            while (i < A.Length)
            {
                if (lPointer >= 0 && rPointer < A.Length)
                {
                    res[i] = Math.Abs(A[lPointer]) < A[rPointer]
                        ? A[lPointer] * A[lPointer--]
                        : A[rPointer] * A[rPointer++];
 
                }
                else if(lPointer >= 0)
                {
                    res[i] = A[lPointer] * A[lPointer--];
                }
                else
                {
                    res[i] = A[rPointer] * A[rPointer++];
                }

                i++;
            }

            return res;
        }

        private int FindStartPositiveVal(int[] A)
        {
            var i = 0;

            while (i < A.Length - 1)
            {
                if (A[i++] >= 0) return --i; 
            }

            return i;
        }
    }
}