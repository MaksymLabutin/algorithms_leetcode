using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4)
                },
                right = new TreeNode(3)
            };

            var x = 4;
            var y = 3;

            var res = IsCousins(root, x, y);

            Assert.IsFalse(res);
        }

        [Test]
        public void Test2()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    right = new TreeNode(4)
                },
                right = new TreeNode(3)
                {
                    right = new TreeNode(5)
                }
            };

            var x = 5;
            var y = 4;

            var res = IsCousins(root, x, y);

            Assert.IsTrue(res);
        }

        [Test]
        public void Test3()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    right = new TreeNode(4)
                },
                right = new TreeNode(3)
            };

            var x = 2;
            var y = 3;

            var res = IsCousins(root, x, y);

            Assert.IsFalse(res);
        }

        public bool IsCousins(TreeNode root, int x, int y)
        {
            if (root == null) return false;

            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            var step = 0;
            (int partent, int k)? xParent = null;
            (int partent, int k)? yParent = null;

            while (q.Count > 0)
            {
                step++;
                var size = q.Count;

                for (var i = 0; i < size; i++)
                {
                    var node = q.Dequeue(); 

                    if (node.left?.val == x) xParent = (node.val, step);
                    else if (node.right?.val == x) xParent = (node.val, step);

                    if (node.left?.val == y) yParent = (node.val, step);
                    else if (node.right?.val == y) yParent = (node.val, step);
                    
                    if(node.left != null) q.Enqueue(node.left);
                    if(node.right != null) q.Enqueue(node.right);

                    if (xParent == null || yParent == null) continue;
                    q = new Queue<TreeNode>();
                    break;
                }
            }

            return yParent != null && xParent != null && xParent.Value.k == yParent.Value.k && xParent.Value.partent != yParent.Value.partent;
        }


        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}