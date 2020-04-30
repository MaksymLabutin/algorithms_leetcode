using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var l1 = new ListNode(2)
            {
                next = new ListNode(4)
                {
                    next = new ListNode(3)
                }
            };
            var l2 = new ListNode(5)
            {
                next = new ListNode(6)
                {
                    next = new ListNode(4)
                }
            };

            var actual = AddTwoNumbers(l1, l2);


            Assert.AreEqual(7, actual.val);
            Assert.AreEqual(0, actual.next.val);
            Assert.AreEqual(8, actual.next.next.val);
            Assert.Null(actual.next.next.next);
        }

        [Test]
        public void Test2()
        {
            var l1 = new ListNode(9)
            {
                next = new ListNode(9)
            };
            var l2 = new ListNode(9);

            var actual = AddTwoNumbers(l1, l2);


            Assert.AreEqual(8, actual.val);
            Assert.AreEqual(0, actual.next.val);
            Assert.AreEqual(1, actual.next.next.val);
            Assert.Null(actual.next.next.next);
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null) return l1 ?? l2;

            ListNode node = null;
            ListNode nodeHead = null;

            int additional = 0;

            while (l1 != null || l2 != null)
            {

                int val = 0;
                if (l1 != null && l2 != null)
                {
                    val = l1.val + l2.val;
                }
                else if(l1 == null)
                {
                    val = l2.val;
                }
                else
                {
                    val = l1.val; 
                }

                val += additional;

                additional = 0;

                if (val > 9)
                {
                    val = val - 10;
                    additional = 1;
                }

                if (node != null)
                {
                    node.next = new ListNode(val);
                    node = node.next;
                }
                else
                {
                    node = new ListNode(val);
                }

                if (nodeHead == null) nodeHead = node;

                l1 = l1?.next;
                l2 = l2?.next;
            }

            if (additional != 0 && node != null) node.next = new ListNode(1);

            return nodeHead;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}