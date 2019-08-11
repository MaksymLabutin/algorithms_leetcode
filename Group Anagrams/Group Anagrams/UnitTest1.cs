using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            var res = GroupAnagrams(new[] {"eat", "tea", "tan", "ate", "nat", "bat"});
            CollectionAssert.AreEqual(res, new List<List<string>>(){new List<string>(){ "eat", "tea", "ate" }, new List<string>(){ "tan", "nat" }, new List<string>(){ "bat" } });
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dic = new Dictionary<string, List<string>>();

            foreach (var str in strs)
            { 
                var orderedStr = OrderStringByAlphabeticaly(str);

                if (dic.ContainsKey(orderedStr))
                {
                    dic[orderedStr].Add(str);
                }
                else
                {
                    dic.Add(orderedStr, new List<string>(){ str });
                }
            }

            return new List<IList<string>>(dic.Values);
        }

        private string OrderStringByAlphabeticaly(string str)
        {
            char[] characters = str.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}