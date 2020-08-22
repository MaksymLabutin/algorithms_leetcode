using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var height = new int[] {1, 8, 6, 2, 5, 4, 8, 3, 7};
            var actual = MaxArea(height);
            var expected = 49;
            Assert.AreEqual(expected, actual);
        }
         
        [Test]
        public void Test2()
        {
            var height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 8, 3, 7, 8, 6, 2, 5, 4, 99, 3, 7 };
            var actual = MaxArea(height);
            var expected = 1256;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var height = new int[] { 2, 3, 4, 5, 18, 17, 6 };
            var actual = MaxArea(height);
            var expected = 17;
            Assert.AreEqual(expected, actual);
        }
         

        public int MaxArea(int[] height)
        {
            int lPointer = 0;
            int rPointer = height.Length - 1;

            var max = 0;

            while (lPointer < rPointer)
            {
                max = Math.Max(max, CountMax(height, lPointer, rPointer));  

                if(height[lPointer] < height[rPointer]) lPointer++;
                else rPointer--;
            }

            return max;
        }

        private int CountMax(int[] height, int index1, int index2)
        {
            var min = Math.Min(height[index1], height[index2]);

            var res = (index2 - index1) * min;

            return res;
        }
    }
}