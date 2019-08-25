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
            //["TwoSum","add","find"]
            //    [[],[0],[0]]

            var ts = new TwoSum();

            ts.Add(0);
            var res = ts.Find(0);
        }

        [Test]
        public void Test2()
        {
            //["TwoSum","add","add","add","find","find","find","find","find"]
            //    [[],[3],[2],[1],[2],[3],[4],[5],[6]]

            //Expected: [null,null,null,null,false,true,true,true,false]
            var ts = new TwoSum();

            ts.Add(3);
            ts.Add(2);
            ts.Add(1);
            var res1 = ts.Find(2);
            var res2 = ts.Find(3);
            var res3 = ts.Find(4);
            var res4 = ts.Find(5);
            var res5 = ts.Find(6);
        }


        [Test]
        public void Test3()
        {
            //["TwoSum","add","add","add","add","find","find","find","find"]
            //    [[],[0],[-1],[-1],[0],[-2],[0],[-1],[1]]

            //Expected: [null,null,null,null,null,true,true,true,false]
            var ts = new TwoSum();

            ts.Add(0);
            ts.Add(-1);
            ts.Add(-1);
            ts.Add(0);
            var res1 = ts.Find(-2);
            var res2 = ts.Find(0);
            var res3 = ts.Find(-1);
            var res4 = ts.Find(1);
        }


        [Test]
        public void Test4()
        {
            //["TwoSum","add","add","find","find","find","add","find","find","find","add","find"]
            //    [[],[1],[1],[0],[1],[2],[-1],[0],[1],[-2],[-1],[-2]]

            //Expected: [null,null,null,false,false,true,null,true,false,false,null,true]
            var ts = new TwoSum();

            ts.Add(1);
            ts.Add(1);
            var res1 = ts.Find(0); //false
            var res2 = ts.Find(1); // false
            var res3 = ts.Find(2); //true
            ts.Add(-1);
            var res4 = ts.Find(0);
            var res5 = ts.Find(1);
            var res6 = ts.Find(-2);

            ts.Add(-1); 
            var res7 = ts.Find(-2); 
        }


    }
    public class TwoSum
    {

        private readonly Dictionary<int, int> _map;

        /** Initialize your data structure here. */
        public TwoSum()
        {
            _map = new Dictionary<int, int>();
        }

        /** Add the number to an internal data structure.. */
        public void Add(int number)
        {
            if (_map.ContainsKey(number))
            {
                _map[number] = 2;
                return;
            }

            _map.Add(number, 1);
        }

        /** Find if there exists any pair of numbers which sum is equal to the value. */
        public bool Find(int value)
        {
           
            foreach (var el in _map.Keys)
            {
                if (!_map.ContainsKey(value - el)) continue;
                if (el * 2 == value && _map[value - el] == 1) continue;
                return true;
            }

            return false;
        }
    }
}