using System.Xml.Linq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {

            var list = new ListNode(1)
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

            var actual = ReverseList(list);

            
            Assert.AreEqual(5, actual.val);
            Assert.AreEqual(4, actual.next.val);
            Assert.AreEqual(3, actual.next.next.val);
            Assert.AreEqual(2, actual.next.next.next.val);
            Assert.AreEqual(1, actual.next.next.next.next.val);
            Assert.IsNull(actual.next.next.next.next.next);
        }

        public ListNode ReverseList(ListNode head)
        {
            if (head == null) return null;

            var headNode = head;

            while (headNode.next != null)
            {
                var node = headNode.next;
                headNode.next = node.next;

                var tmp = head;
                head = node;
                head.next = tmp; 

            }

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