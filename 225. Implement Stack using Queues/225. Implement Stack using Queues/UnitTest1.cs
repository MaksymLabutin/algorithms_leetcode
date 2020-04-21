using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            MyStack obj = new MyStack();
            obj.Push(1);
            obj.Push(2);
            obj.Push(3);
            Assert.AreEqual(3, obj.Pop());
            Assert.AreEqual(2, obj.Top());
            Assert.IsFalse(obj.Empty());
            Assert.AreEqual(2, obj.Pop());
            Assert.IsFalse(obj.Empty());
            Assert.AreEqual(1, obj.Pop());
            Assert.IsTrue(obj.Empty()); 
        }

        [Test]
        public void Test2()
        {
            MyStack obj = new MyStack();
            obj.Push(1);
            obj.Push(2);

            Assert.AreEqual(2, obj.Top());
            obj.Push(3);
            Assert.AreEqual(3, obj.Top()); 
        }

        public class MyStack
        {
            private Queue<int> _stack = new Queue<int>();
            private readonly Queue<int> _tmp = new Queue<int>();

            /** Initialize your data structure here. */
            public MyStack()
            {

            }

            /** Push element x onto stack. */
            public void Push(int x)
            {
                _tmp.Enqueue(x);
            }

            /** Removes the element on top of the stack and returns that element. */
            public int Pop()
            {
                if (_stack.Count == 0) MoveTmpToStack();

                return _stack.Dequeue();
            }

            /** Get the top element. */
            public int Top()
            { 
                MoveTmpToStack();
                return _stack.Peek();
            }

            /** Returns whether the stack is empty. */
            public bool Empty()
            {
                return _tmp.Count == 0 && _stack.Count == 0;
            }

            private void MoveTmpToStack()
            {
                if(_tmp.Count == 0) return;

                var l = _tmp.Count + _stack.Count;
                var arr = new int[l];

                var tmpCount = _tmp.Count - 1;
                if (_stack.Count > 0)
                {
                    for (var i = 0; i < tmpCount; i++)
                    {
                        arr[i] = _stack.Dequeue();
                    }
                } 

                for (var i = tmpCount; i >= 0; i--)
                {
                    arr[i] = _tmp.Dequeue();
                }

                _stack = new Queue<int>();

                for (var i = 0; i < arr.Length; i++)
                {
                    _stack.Enqueue(arr[i]);
                }
            }
        }

    }
}