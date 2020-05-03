using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var rowIndex = 3;

            var actual = GetRow(rowIndex);

            Assert.AreEqual(1, actual[0]);
            Assert.AreEqual(3, actual[1]);
            Assert.AreEqual(3, actual[2]);
            Assert.AreEqual(1, actual[3]);
            Assert.AreEqual(4, actual.Count);
        }

        private List<int> prev = new List<int>(){1};
        
        public IList<int> GetRow(int rowIndex)
        {
            var res = new List<int> {1};

            for (var i = 1; i < prev.Count; i++)
            {
                res.Add(prev[i - 1] + prev[i]);
            }

            res.Add(1);

            prev = res;

            return prev.Count + 1 == rowIndex ? res : GetRow(rowIndex);
        }               
    }
}