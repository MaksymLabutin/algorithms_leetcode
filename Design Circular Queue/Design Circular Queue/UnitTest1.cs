using System;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            MyCircularQueue obj = new MyCircularQueue(3);

            bool param_1 = obj.EnQueue(1);
            bool param_2 = obj.EnQueue(2);
            bool param_3 = obj.EnQueue(3);
            bool param_4 = obj.EnQueue(4);

            bool d_1 = obj.DeQueue();
            bool param_5 = obj.EnQueue(4);

            bool d_2 = obj.DeQueue();
            bool d_3 = obj.DeQueue();
            bool d_4 = obj.DeQueue();
            bool d_5 = obj.DeQueue();
            int f_1 = obj.Front();

            int r_1 = obj.Rear();

            bool e_1 = obj.IsEmpty();

            bool full_1 = obj.IsFull();

        }

        [Test]
        public void Test2()
        {
            //["MyCircularQueue","enQueue","Rear","Rear","deQueue","enQueue","Rear","deQueue","Front","deQueue","deQueue","deQueue"]
            //    [[6],[6],[],[],[],[5],[],[],[],[],[],[]]
            MyCircularQueue obj = new MyCircularQueue(6);

            bool param_1 = obj.EnQueue(6);
            int r_1 = obj.Rear();
            int r_2 = obj.Rear();

            bool d_1 = obj.DeQueue();

            bool param_2 = obj.EnQueue(5);
            int r_3 = obj.Rear();
            bool d_2 = obj.DeQueue();
            int f_1 = obj.Front();
             
            bool d_3 = obj.DeQueue(); 
            bool d_4 = obj.DeQueue();
            bool d_5 = obj.DeQueue(); 

        }

        public class MyCircularQueue
        { 
            private int[] arr;
            private int tail;
            private int head;

            /** Initialize your data structure here. Set the size of the queue to be k. */
            public MyCircularQueue(int k)
            {
                arr = new int[k];
                tail = -1;
                head = -1;
            }

            /** Insert an element into the circular queue. Return true if the operation is successful. */
            public bool EnQueue(int value)
            {
                if (IsFull()) return false;

                if (IsEmpty()) head++;

                tail = tail + 1 >= arr.Length ? 0 : tail + 1;
                arr[tail] = value;

                return true;
            }

            /** Delete an element from the circular queue. Return true if the operation is successful. */
            public bool DeQueue()
            {
                if (IsEmpty()) return false;
                arr[head] = -1;

                if (tail == head)
                {
                    head = -1;
                    tail = -1;
                }
                else
                {
                    head = head + 1 > arr.Length - 1 ? 0 : head + 1;
                }

                return true;
            }

            /** Get the front item from the queue. */
            public int Front()
            {
                return head < 0 ? head : arr[head];
            }

            /** Get the last item from the queue. */
            public int Rear()
            {
                return tail < 0 ? tail : arr[tail];
            }

            /** Checks whether the circular queue is empty or not. */
            public bool IsEmpty()
            {
                return head == -1 && tail == -1;
            }

            /** Checks whether the circular queue is full or not. */
            public bool IsFull()
            {
                var tmp = tail + 1 >= arr.Length ? 0 : tail + 1;
                return tmp == head;
            }
        }
    }
}