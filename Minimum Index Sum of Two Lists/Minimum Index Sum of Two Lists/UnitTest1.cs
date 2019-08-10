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

            var res = FindRestaurant(new[] { "Shogun", "Tapioca Express", "Burger King", "KFC" }, new[] { "Piatti", "The Grill at Torrey Pines", "Hungry Hunter Steakhouse", "Shogun" });

            CollectionAssert.AreEqual(new string[] { "Shogun" }, res);
        }

        [Test]
        public void Test2()
        {

            var res = FindRestaurant(new[] { "Shogun", "Tapioca Express", "Burger King", "KFC" }, new[] { "KFC", "Shogun", "Burger King" });

            CollectionAssert.AreEqual(new string[] { "Shogun" }, res);
        }

        [Test]
        public void Test3()
        {

            var res = FindRestaurant(new[] { "0", "1", "2", "3", "4" }, new[] { "9", "8", "7", "2", "6", "0" });

            CollectionAssert.AreEqual(new string[] { "2", "0" }, res);
        }

        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            var dic = new Dictionary<string, int>();
            var dicF = new Dictionary<int, List<string>>();

            for (var index = 0; index < list1.Length; index++)
            {
                dic.Add(list1[index], index);
            }

            var smallestIndex = int.MaxValue;

            for (int i = 0; i < list2.Length; i++)
            {
                if (!dic.ContainsKey(list2[i])) continue;

                var sumIndex = i + dic[list2[i]];

                if (dicF.ContainsKey(sumIndex))
                {
                    dicF[sumIndex].Add(list2[i]);
                }
                else
                {
                    if (smallestIndex > sumIndex) smallestIndex = sumIndex;

                    dicF.Add(sumIndex, new List<string>() { list2[i] });
                }
            }

            return dicF[smallestIndex].ToArray();
        }
    }
}