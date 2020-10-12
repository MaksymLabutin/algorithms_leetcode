using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        
        [Test]
        public void Test1()
        {
            var arr = new int[] {1, 2};
            var actual = UniqueOccurrences(arr);
            
            Assert.IsFalse(actual); 
        }

        public bool UniqueOccurrences(int[] arr)
        {

            var memo = new Dictionary<int, int>();

            foreach (var el in arr)
            {
                if (memo.ContainsKey(el)) memo[el] += 1;
                else memo.Add(el, 1);
            }

            var hs = new HashSet<int>();

            foreach (var el in memo)
            {
                if (hs.Contains(el.Value)) return false;
                hs.Add(el.Value);
            }

            return true;
        }
    }
}