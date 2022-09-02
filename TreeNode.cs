namespace System {
    public struct TreeNode {
        public object value;
        public Tree tree;
        public Nullable<int> parent;

        public TreeNode(object value, Tree tree) {
            this.value = value;
            this.tree = tree;
            parent = null;
        }
        public TreeNode(object value, Tree tree, Nullable<int> parent) {
            this.value = value;
            this.tree = tree;
            this.parent = parent;
        }
    }
}