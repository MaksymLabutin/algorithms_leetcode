using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            //[1,4,2,6], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
            var head = new ListNode(1);
            head.next = new ListNode(4);
            head.next.next = new ListNode(2);
            head.next.next.next = new ListNode(6);

            var root = new TreeNode(1)
            {
                left = new TreeNode(4)
                {
                    right = new TreeNode(2)
                    {
                        left = new TreeNode(1)
                    }
                },
                right = new TreeNode(4)
                {
                    left = new TreeNode(2)
                    {
                        left = new TreeNode(6),
                        right = new TreeNode(8)
                        {
                            left = new TreeNode(1),
                            right = new TreeNode(3)
                        }
                    }
                }
            };

            var actual = IsSubPath(head, root);

            Assert.True(actual);
        }


        private ListNode _copiedHead;
        private HashSet<(ListNode n, TreeNode r)> _visited;


        public bool IsSubPath(ListNode head, TreeNode root)
        {
            _copiedHead = head;
            _visited = new HashSet<(ListNode n, TreeNode r)>();
            return Visit(head, root);
        }

        private bool Visit(ListNode head, TreeNode root)
        {
            if (root == null || head == null) return head == null;

            if (_visited.Contains((head, root))) return false;
            else _visited.Add((head, root));

            var l = false;
            var r = false;
            if (root.val == head.val)
            {
                l = Visit(head.next, root.left);
                r = Visit(head.next, root.right);
                return r || l || Visit(_copiedHead, root.left) || Visit(_copiedHead, root.right);
            }
            else
            {
                return Visit(_copiedHead, root.left) || Visit(_copiedHead, root.right);
            }

        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
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