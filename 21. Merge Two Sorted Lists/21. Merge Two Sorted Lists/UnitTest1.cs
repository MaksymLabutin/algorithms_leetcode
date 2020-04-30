using NUnit.Framework;

namespace Tests
{
    public class Tests
    {  
        [Test]
        public void Test1()
        {
            //1->2->4, 1->3->4

            var l1 = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(4)
                }
            };

            var l2 = new ListNode(1)
            {
                next = new ListNode(3)
                {
                    next = new ListNode(4)
                }
            };

            var actual = MergeTwoLists(l1, l2);

            Assert.AreEqual(1, actual.val);
            Assert.AreEqual(1, actual.next.val);
            Assert.AreEqual(2, actual.next.next.val);
            Assert.AreEqual(3, actual.next.next.next.val);
            Assert.AreEqual(4, actual.next.next.next.next.val);
            Assert.AreEqual(4, actual.next.next.next.next.next.val);
            Assert.Null(actual.next.next.next.next.next.next);
        }

        [Test]
        public void Test2()
        {
            //1->2->4, 1->3->4

            var l1 = new ListNode(1);

            var l2 = new ListNode(2) ;

            var actual = MergeTwoLists(l1, l2);

            Assert.AreEqual(1, actual.val);
            Assert.AreEqual(2, actual.next.val); 
            Assert.Null(actual.next.next.next);
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null) return l1 ?? l2;

            ListNode resHead = null;
            ListNode res = null;

            while (l1 != null || l2 != null)
            {
                int val;

                if (l2 == null || l1 != null && l2.val > l1.val)
                {
                    val = l1.val;
                    l1 = l1.next;
                }
                else
                {
                    val = l2.val;
                    l2 = l2.next;
                }
                 
                if (res != null)
                {
                   res.next = new ListNode(val);
                    res = res.next;

                }
                else
                {
                    res = new ListNode(val);
                    resHead = res;
                } 
                
            }

            return resHead;
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