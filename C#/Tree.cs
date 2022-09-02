namespace System {
    public struct Tree {
        public TreeNode[] nodes;
        public int Length {get {return nodes.Length;}}

        public Tree(dynamic[] values, Nullable<int>[] parents) {
            nodes = new TreeNode[values.Length];
            var i = 0;
            foreach(int value in values) {
                nodes[i] = new TreeNode(value, this, parents[i]);
                i++;
            }
        }

        public TreeNode GetNode(int index) => nodes[index];
    }
}