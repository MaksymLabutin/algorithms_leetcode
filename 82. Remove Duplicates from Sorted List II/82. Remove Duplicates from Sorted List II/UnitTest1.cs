using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            //Input: 1->2->3->3->4->4->5
            //Output: 1->2->5

            var head = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(3)
                        {
                            next = new ListNode(4)
                            {
                                next = new ListNode(4)
                                {
                                    next = new ListNode(5)
                                }
                            }
                        }
                    }
                }
            };

            var actual = DeleteDuplicates(head);

            Assert.AreEqual(1, actual.val);
            Assert.AreEqual(2, actual.next.val);
            Assert.AreEqual(5, actual.next.next.val);
            Assert.Null(actual.next.next.next);
        }

     
        [Test]
        public void Test2()
        {
            //Input: 1->1->1->2->3
            //Output: 2->3

            var head = new ListNode(1)
            {
                next = new ListNode(1)
                {
                    next = new ListNode(1)
                    {
                        next = new ListNode(2)
                        {
                            next = new ListNode(3)
                            {
                                next = new ListNode(3)
                            }
                        }
                    }
                }
            };

            var actual = DeleteDuplicates(head);

            Assert.AreEqual(2, actual.val); 
            Assert.Null(actual.next);
        }

        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head?.next == null) return head;

            var copiedHead = head;

            var repeatedNodes = new HashSet<int>(); 

            while (copiedHead?.next != null)
            {
                if (copiedHead.val == copiedHead.next.val)
                {
                    if (!repeatedNodes.Contains(copiedHead.val)) repeatedNodes.Add(copiedHead.val);
                }
                copiedHead = copiedHead.next;
            }

            copiedHead = head;
            var res = new ListNode(0);
            var copiesRes = res;

            while (copiedHead != null)
            {
                if (!repeatedNodes.Contains(copiedHead.val))
                {
                    res.next = new ListNode(copiedHead.val);
                    res = res.next;
                } 
                copiedHead = copiedHead.next;
            }

            return copiesRes.next;
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