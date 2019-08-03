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
            MyHashSet obj = new MyHashSet();
            obj.Add(1);
            obj.Add(2);
            obj.Add(2);
            var a = obj.Contains(1);
            var a1 = obj.Contains(3);
            var a2 = obj.Contains(2);
            obj.Remove(2);
            var a3 = obj.Contains(2); 

            Assert.Pass();
        }

        public class MyHashSet
        { 
            int ?[] arr;

            /** Initialize your data structure here. */
            public MyHashSet()
            {
                arr = new int?[1000001];
            }

            public void Add(int key)
            {
                arr[key] = key;
            }

            public void Remove(int key)
            {
                arr[key] = null; 
            }

            /** Returns true if this set contains the specified element */
            public bool Contains(int key)
            {
                return arr[key] == key;
            }
        }

        /**
         * Your MyHashSet object will be instantiated and called as such:
         * MyHashSet obj = new MyHashSet();
         * obj.Add(key);
         * obj.Remove(key);
         * bool param_3 = obj.Contains(key);
         */
    }
}