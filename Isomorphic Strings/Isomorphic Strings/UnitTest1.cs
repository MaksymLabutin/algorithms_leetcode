using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var res = IsIsomorphic("add", "egg");

            Assert.IsTrue(res);
        }

        [Test]
        public void Test2()
        {
            var res = IsIsomorphic("add", "egc");

            Assert.IsFalse(res);
        }

        [Test]
        public void Test3()
        {
            var res = IsIsomorphic("aba", "baa");

            Assert.IsFalse(res);
        }

        public bool IsIsomorphic(string s, string t)
        {
            var map1 = new Dictionary<char, char>();
            var map2 = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!map1.ContainsKey(s[i]) && !map2.ContainsKey(t[i]))
                {
                    map1.Add(s[i], t[i]);
                    map2.Add(t[i], s[i]);
                }
                else if ((map1.ContainsKey(s[i]) && map1[s[i]] != t[i]) || (map2.ContainsKey(t[i]) && map2[t[i]] != s[i]))
                    return false;
            }
            return true;
        }


        //public bool IsIsomorphic(string s, string t)
        //{
        //    var dicS = new Dictionary<char, List<int>>();
        //    var dicT = new Dictionary<char, List<int>>();

        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        if (dicS.ContainsKey(s[i]) || dicT.ContainsKey(t[i]))
        //        {
        //            if (!dicS.ContainsKey(s[i]) || !dicT.ContainsKey(t[i])) return false;

        //            for (var index = 0; index < dicS[s[i]].Count; index++)
        //            {
        //                if (dicS[s[i]][index] != dicT[t[i]][index]) return false;
        //            }
        //        }

        //        if (dicS.ContainsKey(s[i]))
        //        {
        //            dicS[s[i]].Add(i);
        //        }
        //        else
        //        {
        //            dicS.Add(s[i], new List<int>() { i });
        //        }

        //        if (dicT.ContainsKey(t[i]))
        //        {
        //            dicT[t[i]].Add(i);
        //        }
        //        else
        //        {
        //            dicT.Add(t[i], new List<int>() { i });

        //        }
        //    }

        //    return true;
        //}
    }
}