using System;
using System.Collections.Generic;
using Xunit;

namespace _148._Sort_List
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        public ListNode SortList(ListNode head)
        {
            var heap = new SortedList<int, ListNode>(new InvertedComparer());

            while (head != null)
            {
                heap.Add(head.val, head);
                head = head.next;
            }

            ListNode newHead = null;
            ListNode copiedNewHead = null;

            foreach (var listNode in heap)
            {
                if (newHead == null)
                {
                    newHead = new ListNode(listNode.Key);
                    copiedNewHead = newHead;
                }
                else
                {
                    newHead.next = new ListNode(listNode.Key);
                    newHead = newHead.next;
                } 
            }

            return copiedNewHead;
        }
        private class InvertedComparer : IComparer<int>
        { 
            public int Compare(int x, int y)
            {
                return x > y ? 1 : -1;
            }
        }


        public class ListNode
        {
                 public int val;
                    public ListNode next;
                     public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}
