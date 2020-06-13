using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var arr = new int[] { 10, 2, 5, 3 };
            var actual = CheckIfExist(arr);
            Assert.IsTrue(actual);
        }

        [Test]
        public void Test2()
        {
            var arr = new int[] { 7, 1, 14, 11 };
            var actual = CheckIfExist(arr);
            Assert.IsTrue(actual);
        }

        [Test]
        public void Test3()
        {
            var arr = new int[] { 3, 1, 7, 11 };
            var actual = CheckIfExist(arr);
            Assert.IsFalse(actual);
        }

        [Test]
        public void Test4()
        {
            var arr = new int[] { 0, 0 };
            var actual = CheckIfExist(arr);
            Assert.IsTrue(actual);
        }

        public bool CheckIfExist(int[] arr)
        {
            if (arr.Length < 2) return false;

            var dic = new HashSet<int>();

            foreach (var t in arr)
            {
                if (dic.Contains(t))
                {
                    if (t == 0) return true;
                    continue;
                }
                if (dic.Contains(t * 2) || t % 2 == 0 && dic.Contains(t / 2)) return true;
                dic.Add(t);
            }

            return false;
        }
    }
}