using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            MinStack minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            minStack.Push(-3);
            minStack.Push(-3);
            minStack.Push(-3);
            minStack.Push(-3);
            minStack.Push(-3);
            minStack.Push(-3);
            minStack.Push(-3);
            minStack.Push(-3);
            minStack.Push(-3);
            minStack.Push(-3);
            minStack.Push(-3);
            minStack.Push(-3);
            minStack.Push(-3);
            minStack.Push(-3);
            minStack.Push(-3);
            minStack.Push(-3);
            minStack.Push(-3);
            minStack.Push(-3);
            minStack.GetMin(); // Returns - 3.
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Pop();
            minStack.Top(); // Returns 0.
            minStack.GetMin(); // Returns - 2.
        }

        public class MinStack
        {
            private int[] _arr;
            private int _pointer;

            private int _minVal;
            /** initialize your data structure here. */
            public MinStack()
            {
                _arr = new int[10];
                _pointer = -1;
                _minVal = int.MaxValue;
            }

            public void Push(int x)
            {
                if (_arr.Length <= _pointer + 1) Resize(_arr.Length * 2);
                _arr[++_pointer] = x;
                _minVal = _minVal > x ? x : _minVal;
            }

            public void Pop()
            {
                if (_arr.Length / 3 > _pointer) Resize(_arr.Length / 3);
                _pointer = _pointer - 1 < 0 ? -1 : --_pointer;

                _minVal = _arr[_pointer + 1] == _minVal ? SearchMin() : _minVal;

            }

            public int Top()
            {
                return _pointer == -1 ? 0 : _arr[_pointer];
            }

            public int GetMin()
            {
                return _pointer < 0 ? 0 : _minVal;
            }

            private void Resize(int size)
            {
                var arr = new int[size];

                for (var i = 0; i < _pointer + 1; i++)
                {
                    arr[i] = _arr[i];
                }

                _arr = arr;
            }

            private int SearchMin()
            {
                var minVal = int.MaxValue;

                for (var i = 0; i < _pointer + 1; i++)
                {
                    if (minVal < _arr[i]) continue;
                    minVal = _arr[i];
                }

                return minVal;
            } 
        }
    }
}