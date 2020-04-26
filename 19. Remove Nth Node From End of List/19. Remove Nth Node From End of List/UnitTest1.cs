using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private ListNode _head;
        [SetUp]
        public void SetUp()
        {
            _head = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                        }
                    }
                }
            };
        }


        [Test]
        public void Test1()
        {
            var actual = RemoveNthFromEnd(_head, 2);

            Assert.AreEqual(actual.val, 1);
            Assert.AreEqual(actual.next.val, 2);
            Assert.AreEqual(actual.next.next.val, 3);
            Assert.AreEqual(actual.next.next.next.val, 5);
            Assert.IsNull(actual.next.next.next.next);
        }

        [Test]
        public void Test2()
        {
            var actual = RemoveNthFromEnd(_head, 1);

            Assert.AreEqual(actual.val, 1);
            Assert.AreEqual(actual.next.val, 2);
            Assert.AreEqual(actual.next.next.val, 3);
            Assert.AreEqual(actual.next.next.next.val, 4);
            Assert.IsNull(actual.next.next.next.next);
        }

        [Test]
        public void Test3()
        {
            var actual = RemoveNthFromEnd(_head, 3);

            Assert.AreEqual(actual.val, 1);
            Assert.AreEqual(actual.next.val, 2);
            Assert.AreEqual(actual.next.next.val, 4);
            Assert.AreEqual(actual.next.next.next.val, 5);
            Assert.IsNull(actual.next.next.next.next);
        }


        [Test]
        public void Test4()
        {
            var actual = RemoveNthFromEnd(_head, 4);

            Assert.AreEqual(actual.val, 1);
            Assert.AreEqual(actual.next.val, 3);
            Assert.AreEqual(actual.next.next.val, 4);
            Assert.AreEqual(actual.next.next.next.val, 5);
            Assert.IsNull(actual.next.next.next.next);
        }

        [Test]
        public void Test5()
        {
            var actual = RemoveNthFromEnd(_head, 5);

            Assert.AreEqual(actual.val, 2);
            Assert.AreEqual(actual.next.val, 3);
            Assert.AreEqual(actual.next.next.val, 4);
            Assert.AreEqual(actual.next.next.next.val, 5);
            Assert.IsNull(actual.next.next.next.next);
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {

            if (head == null) return null;

            var q = new Queue<ListNode>();

            var node = head;
            while (node != null)
            {
                q.Enqueue(node);
                node = node.next;
            }

            if (n == q.Count) return head.next;

            while (q.Count > n + 1)
            {
                q.Dequeue();
            }

            var prev = q.Dequeue();
            prev.next = q.Dequeue()?.next;

            return head;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }

}