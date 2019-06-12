using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Add_Binary
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var res = AddBinary("1010", "1011");
        }

        public string AddBinary(string a, string b)
        {

            var arrA = a.ToCharArray().Select(n => int.Parse(n.ToString())).ToList();
            var arrB = b.ToCharArray().Select(n => int.Parse(n.ToString())).ToList();

            var res = arrA.Count > arrB.Count ? Sum(arrA, arrB) : Sum(arrB, arrA); 
            return res;
        }

        public string Sum(List<int> first, List<int> second)
        {
            var str = new StringBuilder();
            var over = 0;
            var firstIndex = first.Count;
            var secondIndex = second.Count;

            while (firstIndex != 0)
            {
                var valF = first[firstIndex - 1];
                var valS = secondIndex > 0 ? second[secondIndex - 1] : 0;

                var currSum = over + valS + valF; 

                if (currSum == 3)
                {
                    str.Insert(0, 1); 
                    over = 1;
                }
                else if (currSum == 2)
                {
                    str.Insert(0, 0);
                    over = 1;
                }
                else
                {
                    str.Insert(0, currSum);
                    over = 0;
                }

                secondIndex--;
                firstIndex--;
            }

            if (str.Length < first.Count || over == 1)
            {
                str.Insert(0, over);
            }

            return str.ToString();

        }
    }
}
