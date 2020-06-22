using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using static System.Int32;

namespace Tests
{
    public class Tests
    {


        [Test]
        public void Test1()
        {
            var num = 6;
            var actual = IsUgly(num);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test2()
        {
            var num = 8;
            var actual = IsUgly(num);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Test3()
        {
            var num = 2147483647;
            var actual = IsUgly(num);

            Assert.False(actual);
        }

        [Test]
        public void Test6()
        {
            var num = 2123366400;
            var actual = IsUgly(num);

            Assert.True(actual);
        }

        [Test]
        public void Test4()
        {
            var num = -8;
            var actual = IsUgly(num);

            Assert.False(actual);
        }

        [Test]
        public void Test5()
        {
            var num = 3;
            var actual = IsUgly(num);

            Assert.IsTrue(actual);
        }

        public bool IsUgly(int num)
        {
            if (num < 2) return num == 1;

            int num_2 = 0, num_3 = 0, num_5 = 0;
            Int64 next_multiply_num_2 = 2, next_multiply_num_3 = 3, next_multiply_num_5 = 5;

            var list = new List<long>(){1};

            long minNum = 0; 
            while (minNum < int.MaxValue && minNum <= num)
            {
                minNum = Math.Min(next_multiply_num_2, next_multiply_num_3);
                minNum = Math.Min(minNum, next_multiply_num_5);

                if (minNum == num) return true;

                if(list.BinarySearch(minNum) < 0) list.Add(minNum);
                 
                if (minNum == next_multiply_num_2)
                {
                    next_multiply_num_2 =  list[num_2] * 2;
                    num_2++;

                }
                else if (minNum == next_multiply_num_3)
                {
                    next_multiply_num_3 = list[num_3] * 3;
                    num_3++;

                }
                else if (minNum == next_multiply_num_5)
                {
                    next_multiply_num_5 = list[num_5] * 5;
                    num_5++;

                }

            }

            return false;
        }
    }
}