namespace System {
    public struct Tree {
        public TreeNode[] nodes;
        public int Length {get {return nodes.Length;}}

        public Tree(dynamic[] values, Nullable<int>[] parent) {
            nodes = new TreeNode[values.Length];
            var i = 0;
            var currentParent;
            foreach(int value in values) {
                nodes[i] = new TreeNode(value, this);
                i++;
            }
        }
    }
}