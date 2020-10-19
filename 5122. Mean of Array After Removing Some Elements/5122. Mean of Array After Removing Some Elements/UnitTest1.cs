using System;
using System.Linq;
using Xunit;

namespace _5122._Mean_of_Array_After_Removing_Some_Elements
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var arr = new int[] {1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3};
            var actual = TrimMean(arr);
            var expected = 2.0000;
            Assert.Equal(expected, actual);
        }

        public double TrimMean(int[] arr)
        {
            if (arr.Length == 0) return 0;

            var sortedArr = arr.OrderBy(_ => _).ToList();
            var fiveProc = (int)(sortedArr.Count * 0.05);
            double res = 0;

            for (var i = fiveProc; i < sortedArr.Count - fiveProc; i++)
            {
                res += (double)sortedArr[i];
            }

            return (double)(res / (int)(sortedArr.Count * 0.9));
        }
    }
}
