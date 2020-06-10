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
            var A = new int[] {0 };
            var K = 23;

            var actual = AddToArrayForm(A, K);

            var expected = new List<int>() { 2,3};

            CollectionAssert.AreEqual(expected, actual); 
        }

        public IList<int> AddToArrayForm(int[] A, int K)
        {
          
        }
 
    }
}