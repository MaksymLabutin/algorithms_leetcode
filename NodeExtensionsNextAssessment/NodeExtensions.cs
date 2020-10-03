using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NodeExtensionsNextAssessment
{
    public static class NodeExtensions
    { 
        public static Node Next(this Node node)
        {
            if (node == null) return null;

            if (node.Children != null && !Equals(node.Children, Enumerable.Empty<Node>())) return node.Children.First(); 

            return TryGetNextNode(node);
        }
         
        private static Node TryGetNextNode(Node node)
        {
            Node nextNode = null;

            while (nextNode == null)
            {
                var parent = node.Parent;

                if (parent == null) return null;

                var hasVal = false;
                foreach (var parentChild in parent.Children)
                {
                    if (hasVal) nextNode = parentChild;
                    if (node == parentChild) hasVal = true;
                }

                node = parent;
            }

            return nextNode;
        }
    }

    public class Node
    {
        private List<Node> _children;

        public Node(int data, params Node[] nodes)
        {
            Data = data;
            AddRange(nodes);
        }

        public Node Parent { get; set; }

        public IEnumerable<Node> Children
        {
            get
            {
                return _children != null
                    ? _children
                    : Enumerable.Empty<Node>();
            }
        }

        public int Data { get; private set; }

        public void Add(Node node)
        {
            Debug.Assert(node.Parent == null);

            if (_children == null)
            {
                _children = new List<Node>();
            }

            _children.Add(node);
            node.Parent = this;
        }

        public void AddRange(IEnumerable<Node> nodes)
        {
            foreach (var node in nodes)
            {
                Add(node);
            }
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
