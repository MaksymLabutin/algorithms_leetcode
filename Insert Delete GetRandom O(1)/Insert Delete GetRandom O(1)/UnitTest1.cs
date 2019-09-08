using System;
using System.Collections.Generic;
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
            // Init an empty set.
            RandomizedSet randomSet = new RandomizedSet();

            // Inserts 1 to the set. Returns true as 1 was inserted successfully.
            var a = randomSet.Insert(1);
            randomSet.Insert(10); randomSet.Insert(20);


            Assert.IsTrue(a);

            // Returns false as 2 does not exist in the set.
            var a2 = randomSet.Remove(2);
            Assert.IsFalse(a2);

            // Inserts 2 to the set, returns true. Set now contains [1,2].
            var a3 = randomSet.Insert(2);
            Assert.IsTrue(a3);

            // getRandom should return either 1 or 2 randomly.
            var a4 = randomSet.GetRandom();
            var a121 = randomSet.GetRandom();
            var a4123 = randomSet.GetRandom();
            var a4123123 = randomSet.GetRandom();
            var a41 = randomSet.GetRandom();
            var a42 = randomSet.GetRandom();
            var a43 = randomSet.GetRandom();
            var a44 = randomSet.GetRandom();

            // Removes 1 from the set, returns true. Set now contains [2].
            var a5 = randomSet.Remove(1);
            Assert.IsTrue(a5);

            // 2 was already in the set, so return false.
            var a6 = randomSet.Insert(2);
            Assert.IsFalse(a6);

            // Since 2 is the only number in the set, getRandom always return 2.
            var a7 = randomSet.GetRandom();
        }
    }

    public class RandomizedSet
    {
        private List<int> _toShow;
        private readonly HashSet<int> _map;

        private Random r;

        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            _toShow = new List<int>();
            _map = new HashSet<int>();
            r = new Random();
        }


        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            var res = _map.Contains(val);

            if (!res) _map.Add(val);

            _toShow = new List<int>(_map);

            return !res;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            var res = _map.Contains(val);

            if (res) _map.Remove(val);
            _toShow = new List<int>(_map);

            return res;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            if (_toShow.Count == 0) _toShow = new List<int>(_map);

            var index = r.Next(0, _toShow.Count);
            var res = _toShow[index];

            _toShow.Remove(res);

            return res;
        }
    }

}