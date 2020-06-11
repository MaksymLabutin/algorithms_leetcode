using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {


        [Test]
        public void Test1()
        {
            //[1,2,0,0]
            //-340
            var A = new int[] { 1, 2, 0, 0 };
            var K = -340;

            var actual = AddToArrayForm(A, K);

            var expected = new List<int>() { 0, 8, 6, 0 };

            CollectionAssert.AreEqual(expected, actual);

        }
        [Test]
        public void Test2()
        {
            //[9,9,9,9,9,9,9,9,9,9]
            //1
            var A = new int[] { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            var K = 1;

            var actual = AddToArrayForm(A, K);

            var expected = new List<int>() { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            CollectionAssert.AreEqual(expected, actual);

        }
        [Test]
        public void Test3()
        {
            var A = new int[] { 0 };
            var K = 23;

            var actual = AddToArrayForm(A, K);

            var expected = new List<int>() { 2, 3 };

            CollectionAssert.AreEqual(expected, actual);
        }

        public IList<int> AddToArrayForm(int[] A, int K)
        {
            List<int> result = new List<int>();
            int cur = K, N = A.Length;
            int i = N - 1;
            while (i >= 0 || cur > 0)
            {
                if (i >= 0)
                    cur += A[i];
                int digit = cur % 10;
                cur = cur / 10;
                result.Add(digit);
                i--;
            }
            result.Reverse();
            return result;
        }

        //public IList<int> AddToArrayForm(int[] A, int K)
        //{
        //    var isNegative = K < 0;
        //    if (isNegative) K *= (-1);

        //    var res = new List<int>();
        //    var aPointer = A.Length - 1;
        //    for (var i = Math.Max(K.ToString().Length, A.Length); i > 0; i--)
        //    {
        //        var val = K % 10;
        //        K /= 10;

        //        if (aPointer >= 0)
        //        {
        //            if (isNegative)
        //            {
        //                if (A[aPointer] - val < 0)
        //                {
        //                    val = 10 + A[aPointer] - val;
        //                    K += 1;
        //                }
        //                else
        //                {
        //                    val = A[aPointer] - val; 
        //                }
        //            }
        //            else
        //            {
        //                if (val + A[aPointer] > 9)
        //                {
        //                    val = val + A[aPointer] - 10;
        //                    K += 1;
        //                }
        //                else
        //                {
        //                    val = val + A[aPointer];
        //                }
        //            }
        //        }

        //        aPointer--;
        //        res.Insert(0, val);
        //    }

        //    if (K > 0) res.Insert(0, K);
        //    if (K < 0) res[0] -= 1;

        //    return res;
        //}

    }
}