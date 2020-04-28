using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [SetUp]
        public void SetUp()
        {
            _head = null;
        }

        [Test]
        public void Test1()
        {
            var head = new ListNode(1)
            {
                next = new ListNode(2)
            };

            var isPalindrome = IsPalindrome(head);

            Assert.False(isPalindrome);
        }

        [Test]
        public void Test2()
        {
            var head = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(2)
                    {
                        next = new ListNode(1)
                    }
                }
            };

            var isPalindrome = IsPalindrome(head);

            Assert.True(isPalindrome);
        }

        [Test]
        public void Test3()
        {
            var isPalindrome = IsPalindrome(null);

            Assert.True(isPalindrome);
        }

        private ListNode _head;

        public bool IsPalindrome(ListNode head)
        {
            _head = head;

            var res = Visit(head);

            return res;
        }

        private bool Visit(ListNode node)
        {
            if (node == null) return true;

            var isPalindrome = Visit(node.next);

            if (isPalindrome && node.val == _head.val)
            {
                _head = _head.next;
                return true;
            }
            else
            {
                return false;
            }
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}