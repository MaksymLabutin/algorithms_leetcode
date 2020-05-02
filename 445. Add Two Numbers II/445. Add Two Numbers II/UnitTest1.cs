using NUnit.Framework;

namespace Tests
{
    public class Tests
    {


        [Test]
        public void Test1()
        {
            //Input: (7-> 2-> 4-> 3) +(5-> 6-> 4)
            //Output: 7-> 8-> 0-> 7
            var l1 = new ListNode(7)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(4)
                    {
                        next = new ListNode(3)
                    }
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
            Assert.AreEqual(8, actual.next.val);
            Assert.AreEqual(0, actual.next.next.val);
            Assert.AreEqual(7, actual.next.next.next.val);
            Assert.Null(actual.next.next.next.next);
        }

        [Test]
        public void Test2()
        {
            var l1 = new ListNode(7);
            var l2 = new ListNode(5);

            var actual = AddTwoNumbers(l1, l2); 

            Assert.AreEqual(1, actual.val);
            Assert.AreEqual(2, actual.next.val); 
            Assert.Null(actual.next.next);
        }

        private int _additional = 0;

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {

            var l1S = GetSize(l1);
            var l2S = GetSize(l2);

            while (l1S != l2S)
            {
                if (l1S > l2S)
                {
                    var node = new ListNode(0)
                    {
                        next = l2
                    };

                    l2 = node;
                    l2S++;
                }
                else
                {
                    var node = new ListNode(0)
                    {
                        next = l1
                    };

                    l1 = node;
                    l1S++;
                }
            } 
            var res = new ListNode(1)
            {
                next = SumNodes(l1,l2)
            };


            return _additional > 0 ? res : res.next;
        }

        private ListNode SumNodes(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null) return null;

            var next = SumNodes(l1.next, l2.next);

            var nodeVal = l1.val + l2.val + _additional;
            _additional = nodeVal > 9 ? 1 : 0; 

            var node = new ListNode(nodeVal > 9 ? nodeVal - 10 : nodeVal)
            {
                next = next
            };
              
            return node;
        }

        private int GetSize(ListNode head)
        {
            var l = 0;
            while (head != null)
            {
                head = head.next;
                l++;
            }

            return l;
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