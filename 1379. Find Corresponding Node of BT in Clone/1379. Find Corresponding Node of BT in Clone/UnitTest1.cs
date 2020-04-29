using NUnit.Framework;

namespace Tests
{
    public class Tests
    { 
        [Test]
        public void Test1()
        {
            var original = new TreeNode(1);
            var cloned = new TreeNode(1);
            var target = original;

            var actual = GetTargetCopy(original, cloned, target);

            Assert.AreEqual(actual, cloned);
        }

        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            if (original == null) return null;

            if (original == target) return cloned;

            var left = GetTargetCopy(original.left, cloned.left, target);

            var right = GetTargetCopy(original.right, cloned.right, target);
            return left ?? right;

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