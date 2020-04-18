using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Mail;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var T = new int[] { 73, 74, 75, 71, 69, 72, 76, 73 };

            var res = DailyTemperatures(T);

            var expected = new int[] { 1, 1, 4, 2, 1, 1, 0, 0 };

            CollectionAssert.AreEqual(expected, res);
        }

        [Test]
        public void Test2()
        {
            var T = new int[] { 34, 80, 80, 34, 34, 80, 80, 80, 80, 34 };

            var res = DailyTemperatures(T);

            var expected = new int[] { 1, 0, 0, 2, 1, 0, 0, 0, 0, 0 };

            CollectionAssert.AreEqual(expected, res);
        }

        [Test]
        public void Test3()
        {
            var T = new int[] { 70, 70, 70, 70, 70 };

            var res = DailyTemperatures(T);

            var expected = new int[] { 0, 0, 0, 0, 0 };

            CollectionAssert.AreEqual(expected, res);
        }

        public int[] DailyTemperatures(int[] T)
        {
            var hm = new Dictionary<int, int>();

            var res = new int[T.Length];

            var maxT = 0;

            for (var i = T.Length - 1; i >= 0; i--)
            {
                if (T[i] > maxT)
                {
                    maxT = T[i];
                    hm.Add(T[i], i);
                    continue;
                }

                var searchVal = T[i] + 1;

                var minIndex = i;

                while (searchVal <= 100)
                {
                    if (hm.ContainsKey(searchVal))
                    {
                        if (minIndex == i) minIndex = hm[searchVal];
                        else minIndex = hm[searchVal] < minIndex ? hm[searchVal] : minIndex;
                    }
                    searchVal++;
                }

                if (hm.ContainsKey(T[i])) hm[T[i]] = i;
                else hm.Add(T[i], i);

                res[i] = minIndex - i;
            }

            return res;
        }
    }
}