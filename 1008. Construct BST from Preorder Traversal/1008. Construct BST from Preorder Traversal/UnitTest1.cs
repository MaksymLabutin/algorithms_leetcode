using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        
        [Test]
        public void Test1()
        {
            var input = new int[] {8, 5, 1, 7, 10, 12};

            var actual = BstFromPreorder(input);

            var expected = new int?[] {8, 5, 10, 1, 7, null, 12};

            Assert.AreEqual(expected, actual);
        }

        public TreeNode BstFromPreorder(int[] preorder)
        {
            if (preorder.Length == 0) return null;
            
            var root = new TreeNode(preorder[0]);

            for (var i = 1; i < preorder.Length; i++)
            {
                Insert(root, preorder[i]);
            }   
            
            return root;
        }

        private TreeNode Insert(TreeNode node, int val)
        {
            if(node == null) return new TreeNode(val);

            if (val > node.val)
            {
                node.right = Insert(node.right, val);
            }
            else
            {
                node.left = Insert(node.left, val);
            }

            return node;
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