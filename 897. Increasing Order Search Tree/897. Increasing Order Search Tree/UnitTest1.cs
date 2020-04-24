using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            //[5,3,6,2,4,null,8,1,null,null,null,7,9]


            var root = new TreeNode(5)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(2)
                    {
                        left = new TreeNode(1)
                    },
                    right = new TreeNode(4)
                },
                right = new TreeNode(6)
                {
                    right = new TreeNode(8)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(9)
                    }
                }
            };

            var actual = IncreasingBST(root);

            

            Assert.IsTrue(true);


        }


        private Queue<TreeNode> q = new Queue<TreeNode>();
        public TreeNode IncreasingBST(TreeNode root)
        {
            Visit(root); 
            var node = q.Dequeue();
            root = new TreeNode(node.val);
            var res = root;
            while (q.Count > 0)
            { 
                node = q.Dequeue();
                res.right = new TreeNode(node.val);
                res = res.right;
            }

            return root;
        }

        private void Visit(TreeNode node)
        {
            if (node == null) return;
            Visit(node.left);
            q.Enqueue(node);
            Visit(node.right); 
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