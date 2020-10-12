using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace _449._Serialize_and_Deserialize_BST
{
    public class Tests
    { 

        [Test]
        public void Test1()
        {
            var root = new TreeNode(2){left = new TreeNode(1), right = new TreeNode(4){left = new TreeNode(3)}};

            var actual = new Codec().serialize(root);

            var expected = "2,1,-,-,4,3,-,-,-";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2()
        {
            var data = "2,1,-,-,4,3,-,-,-"; 

            var actual = new Codec().deserialize(data); 

            Assert.AreEqual(2, actual.val);
            Assert.AreEqual(1, actual.left.val); 
            Assert.IsNull(actual.left.left);
            Assert.IsNull( actual.left.right);

            Assert.AreEqual(4, actual.right.val);
            Assert.AreEqual(3, actual.right.left.val);

            Assert.IsNull( actual.right.right);
        }

        public class Codec
        {

            // Encodes a tree to a single string.
            public string serialize(TreeNode root)
            {
                if (root == null) return "";
                var str = new StringBuilder();

                ReadDfs(str, root);

                return str.Remove(str.Length - 1, 1).ToString();
            }

            private void ReadDfs(StringBuilder str, TreeNode node)
            {
                if (node == null)
                {
                    str.Append("-,");
                    return;
                }

                str.Append($"{node.val},");
                ReadDfs(str, node.left);
                ReadDfs(str, node.right);
            }


            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data)
            {
                if (string.IsNullOrEmpty(data)) return null;

                var values = data.Split(',').ToList();

                var rootData = WriteNodes(values, 0);

                return rootData.newNode;
            }

            private (TreeNode newNode, int newPosition) WriteNodes(List<string> values, int position)
            {
                if(position == values.Count || values[position] == "-") return (null, position); 

                var currNode = new TreeNode(int.Parse(values[position]));

                var lData = WriteNodes(values, position + 1);
                currNode.left = lData.newNode;
                position = lData.newPosition;
                var rData = WriteNodes(values, position + 1);
                currNode.right = rData.newNode;
                position = rData.newPosition;

                return (currNode, position);
            }
        }


        //public class Codec
        //{

        //    // Encodes a tree to a single string.
        //    public string serialize(TreeNode root)
        //    {
        //        if (root == null) return "";
        //        var str = new StringBuilder();

        //        var q = new Queue<TreeNode>();
        //        q.Enqueue(root);
        //        var allNulls = false;

        //        while (!allNulls)
        //        {
        //            var size = q.Count;
        //            allNulls = true;

        //            var currStr = new StringBuilder();
        //            var currQ = new Queue<TreeNode>();

        //            while (size > 0)
        //            {
        //                var node = q.Dequeue();

        //                currQ.Enqueue(node.left);
        //                currQ.Enqueue(node.right);

        //                currStr.Append(node == null ? "-," : $"{node.val},");

        //                if (node != null) allNulls = false;

        //                size--;
        //            }

        //            if (allNulls) break;

        //            str.Append(currStr);
        //            while (currQ.Count > 0)
        //            {
        //                q.Enqueue(currQ.Dequeue());
        //            }

        //        }

        //        return str.Remove(str.Length - 1, 1).ToString();
        //    }

        //    // Decodes your encoded data to tree.
        //    public TreeNode deserialize(string data)
        //    {
        //        if (string.IsNullOrEmpty(data)) return null;

        //        var values = data.Split(',').ToList();

        //        var root = new TreeNode(int.Parse(values[0]));
        //        var q = new Queue<TreeNode>();
        //        q.Enqueue(root);

        //        for (var i = 1; i < values.Count; i += 2)
        //        {
        //            var node = q.Dequeue();
        //            if (node == null)
        //            {
        //                q.Enqueue(null);
        //                q.Enqueue(null);
        //                continue;
        //            }
        //            node.left = values[i] == "-" ? null : new TreeNode(int.Parse(values[i]));
        //            if (i + 1 < values.Count) node.right = values[i + 1] == "-" ? null : new TreeNode(int.Parse(values[i + 1]));
        //            q.Enqueue(node.left);
        //            q.Enqueue(node.right);
        //        }

        //        return root;
        //    }
        //}

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

    }
}