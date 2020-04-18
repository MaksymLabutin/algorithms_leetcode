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
            if (T == null || T.Length == 0)
                return new int[0];

            int n = T.Length;
            Stack<int> st = new Stack<int>();
            int[] res = new int[n]; 

            for (int i = n - 1; i >= 0; i--)
            {
                while (st.Count > 0 && T[st.Peek()] <= T[i])
                {
                    st.Pop();
                }


                res[i] = st.Count > 0 ? st.Peek() - i : 0;

                st.Push(i);
            }

            return res;
        }
    }
}