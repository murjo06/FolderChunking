namespace System {
    public struct Tree {
        public TreeNode[] nodes;

        public Tree(dynamic[] values, Nullable<int> parent) {
            var i = 0;
            foreach(int value in values) {
                nodes[i] = new TreeNode(value, this);
                i++;
            }
        }
    }
}