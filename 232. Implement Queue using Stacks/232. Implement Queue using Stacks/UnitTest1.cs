using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            MyQueue obj = new MyQueue();
            obj.Push(1);
            obj.Push(2);
            Assert.AreEqual(1, obj.Pop()); 
            Assert.IsFalse(obj.Empty());
            Assert.AreEqual(2, obj.Peek());  
            Assert.IsFalse(obj.Empty());
            Assert.AreEqual(2, obj.Pop()); 
            Assert.IsTrue(obj.Empty());
        }

        public class MyQueue
        {
            private Stack<int> _ordered;
            private Stack<int> _tmp;

            /** Initialize your data structure here. */
            public MyQueue()
            {
                _ordered = new Stack<int>();
                _tmp = new Stack<int>();
            }

            /** Push element x to the back of queue. */
            public void Push(int x)
            {
                _tmp.Push(x);
            }

            /** Removes the element from in front of queue and returns that element. */
            public int Pop()
            {
                if (_ordered.Count == 0) MoveTmpToOrdered();
                return _ordered.Pop();
            }

            /** Get the front element. */
            public int Peek()
            {
                if (_ordered.Count == 0) MoveTmpToOrdered();
                return _ordered.Peek();
            }

            /** Returns whether the queue is empty. */
            public bool Empty()
            {
                return _ordered.Count == 0 && _tmp.Count == 0;
            }

            private void MoveTmpToOrdered()
            {
                while (_tmp.Count > 0)
                {
                    _ordered.Push(_tmp.Pop());
                }
            }
        }

    }
}