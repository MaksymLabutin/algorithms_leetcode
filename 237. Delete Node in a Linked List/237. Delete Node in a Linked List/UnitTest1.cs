using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var node = new ListNode(5)
            {
                next = new ListNode(1)
                {
                    next = new ListNode(9)
                }
            };
            var head = new ListNode(4)
            {
                next = node
            };

            DeleteNode(node);
            Assert.AreEqual(4, head.val);
            Assert.AreEqual(1, head.next.val);
            Assert.AreEqual(9, head.next.next.val);
            Assert.Null(head.next.next.next);
        }

        [Test]
        public void Test2()
        {

            var head = new ListNode(4)
            {
                next = new ListNode(5)
            };

            DeleteNode(head);
            Assert.AreEqual(5, head.val);
            Assert.Null(head.next);
        }

        [Test]
        public void Test3()
        {
            var node = new ListNode(1)
            {
                next = new ListNode(9)
            };
            var head = new ListNode(4)
            {
                next = new ListNode(5)
                {
                    next = node
                }
            };

            DeleteNode(node);
            Assert.AreEqual(4, head.val);
            Assert.AreEqual(5, head.next.val);
            Assert.AreEqual(9, head.next.next.val);
            Assert.Null(head.next.next.next);
        }


        public void DeleteNode(ListNode node)
        {
            var prev = node;

            while (node.next != null)
            {
                node.val = node.next.val;
                prev = node;
                node = node.next;
            }

            prev.next = null;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}