using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)
            };

            var res = BinaryTreePaths(root);

            CollectionAssert.AreEqual(res, new List<string>() { "1->2->5", "1->3" });
        }

        private readonly List<string> _list = new List<string>();

        public IList<string> BinaryTreePaths(TreeNode root)
        {
            Read(root, "");
            return _list;
        }

        private void Read(TreeNode node, string str)
        {
            if (node == null) return; 
            str += $"->{node.val}";
             
            Read(node.left, str);
            Read(node.right, str);

            if (node.left != null || node.right != null) return; 
            _list.Add(str.Remove(0, 2)); 
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