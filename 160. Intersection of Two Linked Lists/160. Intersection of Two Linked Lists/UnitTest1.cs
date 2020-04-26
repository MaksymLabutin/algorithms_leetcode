using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            var intersection = new ListNode(8)
            {
                next = new ListNode(4)
                {
                    next = new ListNode(5)
                }
            };
            var headA = new ListNode(4)
            {
                next = new ListNode(1)
            };
            headA.next.next = intersection;

            var headB = new ListNode(5)
            {
                next = new ListNode(0)
                {

                    next = new ListNode(1)

                }
            };

            headB.next.next.next = intersection;

            var actual = GetIntersectionNode(headA, headB);

            var expected = 8;

            Assert.AreEqual(expected, actual.val);
        }

        [Test]
        public void Test2()
        {
             
            var headA = new ListNode(2)
            {
                next = new ListNode(6)
                {
                    next = new ListNode(4)
                }
            }; 

            var headB = new ListNode(1)
            {
                next = new ListNode(5) 
            }; 

            var actual = GetIntersectionNode(headA, headB);

            Assert.IsNull(actual);
        }

        [Test]
        public void Test3()
        {
             
            var headA = new ListNode(4); 

           
            var actual = GetIntersectionNode(headA, null);
             

            Assert.IsNull(actual);
        }

        [Test]
        public void Test4()
        {
            var intersection = new ListNode(2)
            {
                next = new ListNode(4) 
            };

            var headA = new ListNode(0)
            {
                next = new ListNode(9)
                {
                    next = new ListNode(1)
                }
            };
            headA.next.next.next = intersection;

            var headB = new ListNode(3);

            headB.next = intersection;

            var actual = GetIntersectionNode(headA, headB);

            var expected = 2;

            Assert.AreEqual(expected, actual.val);
        }

        [Test]
        public void Test5()
        {
            var listNode = new ListNode(0);
            var headA = listNode; 

            var headB = listNode; 

            var actual = GetIntersectionNode(headA, headB);

            var expected = 0;

            Assert.AreEqual(expected, actual.val);
        }


        [Test]
        public void Test6()
        {
            var listNode = new ListNode(3);
            var headA = listNode; 

            var headB = new ListNode(2)
            {
                next = listNode
            }; 

            var actual = GetIntersectionNode(headA, headB);

            var expected = 3;

            Assert.AreEqual(expected, actual.val);
        }


        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) return null;
            ListNode a = headA;
            ListNode b = headB;

            while (a != b)
            {
                a = a == null ? headB : a.next;
                b = b == null ? headA : b.next;
            }
            return a;

        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}