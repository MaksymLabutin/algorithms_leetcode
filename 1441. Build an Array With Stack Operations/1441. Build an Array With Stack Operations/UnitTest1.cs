using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var target = new int[] { 1, 3 };
            var n = 3;

            var actual = BuildArray(target, n);

            var expected = new List<string>() { "Push", "Push", "Pop", "Push" };

            CollectionAssert.AreEqual(expected, actual);
        }


        [Test]
        public void Test2()
        {
            var target = new int[] { 1, 2, 3 };
            var n = 3;

            var actual = BuildArray(target, n);

            var expected = new List<string>() { "Push", "Push", "Push" };

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var target = new int[] { 2, 3, 4 };
            var n = 4;

            var actual = BuildArray(target, n);

            var expected = new List<string>() { "Push", "Pop", "Push", "Push", "Push" };

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Test4()
        {
            var target = new int[] { 5, 8, 11 };
            var n = 100;

            var actual = BuildArray(target, n);

            var expected = new List<string>() { "Push", "Pop", "Push", "Pop", "Push", "Pop", "Push", "Pop", "Push", "Push", "Pop", "Push", "Pop", "Push", "Push", "Pop", "Push", "Pop", "Push" };

            CollectionAssert.AreEqual(expected, actual);
        }

        public IList<string> BuildArray(int[] target, int n)
        { 
            var pushOperation = "Push";
            var popOperation = "Pop";

            var res = new List<string>();
            var currVal = 0;

            foreach (var element in target)
            {
                currVal++;
                res.Add(pushOperation);

                if (element == currVal) continue;

                while (currVal != element)
                {
                    res.Add(popOperation);
                    res.Add(pushOperation);
                    currVal++;
                }
            }
             
            return res;
        }
    }
}