using System;
using System.Collections;
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
            //["FreqStack","push","push","push","push","push","push","pop","pop","pop","pop"],
            //    [[],[5],[7],[5],[7],[4],[5],[],[],[],[]]

            var fs = new FreqStack();
            fs.Push(5);
            fs.Push(7);
            fs.Push(5);
            fs.Push(7);
            fs.Push(4);
            fs.Push(5);
            Assert.AreEqual(5, fs.Pop());
            Assert.AreEqual(7, fs.Pop());
            Assert.AreEqual(5, fs.Pop());
            Assert.AreEqual(4, fs.Pop());
            Assert.AreEqual(7, fs.Pop());
            Assert.AreEqual(5, fs.Pop());
        }

        public class FreqStack
        {
            private Dictionary<int, Stack<int>> _stack;
            private Dictionary<int, int> _freq;
            private int _maxFreq;
            public FreqStack()
            {
                _freq = new Dictionary<int, int>();
                _stack = new Dictionary<int, Stack<int>>();
                _maxFreq = 0;
            }

            public void Push(int x)
            { 
                if (_freq.ContainsKey(x)) _freq[x] += 1;
                else _freq.Add(x, 1); 
                _maxFreq = Math.Max(_maxFreq, _freq[x]);
                if(!_stack.ContainsKey(_maxFreq)) _stack.Add(_freq[x], new Stack<int>());
                _stack[_freq[x]].Push(x);
            }

            public int Pop()
            {
                var res = _stack[_maxFreq].Pop();
                _freq[res] -= 1;
                if (_stack[_maxFreq].Count == 0) _maxFreq--;
                return res;
            }
        }

    }
}