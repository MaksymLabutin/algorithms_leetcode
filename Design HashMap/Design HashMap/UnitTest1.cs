using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
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
            MyHashMap hashMap = new MyHashMap();
            hashMap.Put(1, 1);
            hashMap.Put(2, 2);
            var res = hashMap.Get(1);            // returns 1
            var res1 = hashMap.Get(3);            // returns -1 (not found)
            hashMap.Put(2, 1);          // update the existing value
            var res2 = hashMap.Get(2);            // returns 1 
            hashMap.Remove(2);          // remove the mapping for 2
            hashMap.Get(2);

            
        }

        public class MyHashMap
        { 
            private int[][] arr; 
            public MyHashMap()
            {
                arr = new int[1000001][];
            }

            /** value will always be non-negative. */
            public void Put(int key, int value)
            {
                arr[key] = new []{value};
            }

            /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
            public int Get(int key)
            {
                return arr[key] == null || arr[key][0] == -1 ? -1 : arr[key][0];
            }

            /** Removes the mapping of the specified value key if this map contains a mapping for the key */
            public void Remove(int key)
            {
                if(arr[key] == null) return;
                arr[key][0] = -1;
            }
        } 
    }
}