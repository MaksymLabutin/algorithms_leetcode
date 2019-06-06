using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pascal_s_Triangle
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var res = Generate(2);
        }


        public IList<IList<int>> Generate(int numRows)
        {

            if (numRows == 0) return new List<IList<int>>();

            IList<IList<int>> arrays = new List<IList<int>>()
            {
                new List<int>(1){1}
            };

            if (numRows == 1) return arrays;

            arrays.Add(new List<int>(2) { 1, 1 });

            if (numRows == 1) return arrays;


            for (var level = 3; level <= numRows; level++)
            {

                var arr = GetNewArr(arrays[level - 2], level);
                arrays.Add(arr);
            }

            return arrays;
        }


        //если уровень четный, то можно посчитать только половину еррея и потом развернуть результат и добавить в новый массивы
        public List<int> GetNewArr(IList<int> prevList, int currLevel)
        {
            var list = new List<int>(currLevel) { 1, currLevel - 1 };
              
            for (var index = 2; index < currLevel - 1; index++)
            {
                list.Add(prevList[index - 1] + prevList[index]);
            }

            list.Add(1);

            return list;
        }
    }
}
