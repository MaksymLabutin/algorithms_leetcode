using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            //var head = new int[] {1, 0, 1};

            var head = new ListNode(1)
            {
                next = new ListNode(0)
                {
                    next = new ListNode(1)
                }
            };
            var actual = GetDecimalValue(head);
            var expected = 5;
            Assert.AreEqual(expected, actual);
        } 


        public int GetDecimalValue(ListNode head)
        {
            var res = 0;

            while (head != null)
            {
                res <<= 1;
                res |= (byte)head.val; 
                head = head.next;
            }

            return res;
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