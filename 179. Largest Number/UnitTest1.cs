using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var nums = new int[] {10, 2};

            var actual = LargestNumber(nums);

            var expected = "210";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var nums = new int[] { 3, 30, 34, 5, 9 };

            var actual = LargestNumber(nums);

            var expected = "9534330";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test3()
        {
            var nums = new int[] { 3, 30, 34, 5, 9, 123, 4124, 1525, 235, 235, 125, 23, 51, 235, 1235, 1235, 12, 351, 235, 1235, 4, 2134, 567457, 546, 77689, 46 };

            var actual = LargestNumber(nums);

            var expected = "977689567457554651464412435134330235235235235232134152512512351235123512312";

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test4()
        {
            var nums = new int[] { 0,0 };

            var actual = LargestNumber(nums);

            var expected = "0";

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test5()
        {
            var nums = new int[] {824, 938, 1399, 5607, 6973, 5703, 9609, 4398, 8247};

            var actual = LargestNumber(nums);

            var expected = "9609938824824769735703560743981399";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test6()
        {
            var nums = new int[] {1, 4, 2,3,44,43,42};

            var actual = LargestNumber(nums);

            var expected = "4444342321";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test7()
        {
            var nums = new int[] {4704, 6306, 9385, 7536, 3462, 4798, 5422, 5529, 8070, 6241, 9094, 7846, 663, 6221, 216, 6758, 8353, 3650, 3836, 8183, 3516, 5909, 6744, 1548, 5712, 2281, 3664, 7100, 6698, 7321, 4980, 8937, 3163, 5784, 3298, 9890, 1090, 7605, 1380, 1147, 1495, 3699, 9448, 5208, 9456, 3846, 3567, 6856, 2000, 3575, 7205, 2697, 5972, 7471, 1763, 1143, 1417, 6038, 2313, 6554, 9026, 8107, 9827, 7982, 9685, 3905, 8939, 1048, 282, 7423, 6327, 2970, 4453, 5460, 3399, 9533, 914, 3932, 192, 3084, 6806, 273, 4283, 2060, 5682, 2, 2362, 4812, 7032, 810, 2465, 6511, 213, 2362, 3021, 2745, 3636, 6265, 1518, 8398};

            var actual = LargestNumber(nums);

            var expected = "98909827968595339456944893859149094902689398937839883538183810810780707982784676057536747174237321720571007032685668066758674466986636554651163276306626562416221603859725909578457125682552954605422520849804812479847044453428339323905384638363699366436503636357535673516346233993298316330843021297028227452732697246523622362231322812216213206020001921763154815181495141713801147114310901048";

            Assert.AreEqual(expected, actual);
        }

        public string LargestNumber(int[] nums)
        { 
            var res = Sort(nums.ToList());
            if (res.Count == 0 || res.First() == 0) return "0";

            var str = new StringBuilder();
            foreach (var val in res)
            {
                str.Append(val);
            }

            return str.ToString();
        }

        private List<int> Sort(List<int> arr)
        {
            if (arr.Count < 2) return arr;

            var l = Sort(arr.Take(arr.Count / 2).ToList());
            var r = Sort(arr.Skip(arr.Count / 2).ToList());

            return Merge(l, r);
        }

        private List<int> Merge(List<int> left, List<int> right)
        {
            var lPointer = 0;
            var rPointer = 0;

            var l = left.Count + right.Count;
            var res = new List<int>();

            for (var i = 0; i < l; i++)
            {
                var lValStr = lPointer < left.Count ? left[lPointer].ToString() : "0";
                var rValStr = rPointer < right.Count ? right[rPointer].ToString() : "0";
          
                Int64 lVal = Int64.Parse(lValStr + rValStr);
                Int64 rVal = Int64.Parse(rValStr + lValStr);

                if (rPointer >= right.Count || lVal > rVal)
                {
                    res.Add(left[lPointer++]);
                }
                else
                {
                    res.Add(right[rPointer++]);
                }
            }

            return res;
        }
    }
}