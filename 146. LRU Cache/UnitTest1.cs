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
            LRUCache cache = new LRUCache(2 /* capacity */ );

            cache.Put(1, 1);
            cache.Put(2, 2);
            Assert.AreEqual(1,cache.Get(1));       // returns 1
            cache.Put(3, 3);    // evicts key 2
            Assert.AreEqual(-1, cache.Get(2));       // returns -1 (not found)
            cache.Put(4, 4);    // evicts key 1
            Assert.AreEqual(-1,cache.Get(1));       // returns -1 (not found)
            Assert.AreEqual(3, cache.Get(3));       // returns 3
            Assert.AreEqual(4, cache.Get(4));       // returns 4
        }

        [Test]
        public void Test2()
        {
            //["LRUCache","put","get","put","get","get"]
            //    [[1],[2,1],[2],[3,2],[2],[3]]
            LRUCache cache = new LRUCache(1 /* capacity */ );

            cache.Put(2, 1); 
            Assert.AreEqual(1,cache.Get(2));       // returns 1
            cache.Put(3, 2);    // evicts key 2
            Assert.AreEqual(-1, cache.Get(2));       // returns -1 (not found)
            Assert.AreEqual(2, cache.Get(3));       // returns -1 (not found)
          
        }

        public class LRUCache
        { 
            private readonly Dictionary<int, int> _memo;
            private readonly List<int> _q;
            private int _c;

            public LRUCache(int capacity)
            {
                _c = capacity; 
                _memo = new Dictionary<int, int>();
                _q = new List<int>();
            }

            public int Get(int key)
            {
                if (!_memo.ContainsKey(key)) return -1;

                _q.Remove(key);
                _q.Insert(0, key);

                return _memo[key];
            }

            public void Put(int key, int value)
            {
                if (_memo.ContainsKey(key))
                {
                    _memo[key] = value; 
                    _q.Remove(key);
                    _q.Insert(0, key);
                }
                else
                {
                    if (_memo.Count < _c)
                    {
                        _memo.Add(key, value);
                    }
                    else
                    {
                        var el = _q.Last();
                        _memo.Remove(el);
                        _q.RemoveAt(_q.Count - 1);

                        _memo.Add(key, value);
                        _q.Remove(key);
                    }
                    _q.Insert(0, key);

                }
            }
        }

    }
}