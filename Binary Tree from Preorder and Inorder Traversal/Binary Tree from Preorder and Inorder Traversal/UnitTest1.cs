using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var res = BuildTree(new int[] { 3, 9, 20, 15, 7 }, new int[] { 9, 3, 15, 20, 7 });

        }


        //inorder [1,9,5,10,3,11,6,12,2,13,7,4,8]
        //preorder [1,2,3,5,9,10,6,11,12,4,7,13,8]


        //inorder [7,3,8,14,9,4,10,1,11,5,12,2,13,6]
        //preorder [1,14,3,7,8,4,9,10,2,5,11,12,6,13]

        private int _pointer = -1;

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (inorder.Length == 0) return null;

            var map = new Dictionary<int, int>();

            for (var index = 0; index < inorder.Length; index++)
            {
                map.Add(inorder[index], index);
            }

            var node = Visit(preorder, map, 0, preorder.Length - 1);

            return node;
        }

        public TreeNode Visit(int[] preorder, Dictionary<int, int> map, int left, int right)
        {
            if (left > right) return null;
            _pointer++;

            var root = new TreeNode(preorder[_pointer]);

            var index = map[root.val];

            root.left = Visit(preorder, map, left, index - 1);
            root.right = Visit(preorder, map, index + 1, right);

            return root;
        }

        public class TreeNode
        {
            public TreeNode(int x) { val = x; }

            public int val;
            public TreeNode left;
            public TreeNode right;
        }
    }
}