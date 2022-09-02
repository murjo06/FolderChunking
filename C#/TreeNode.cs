namespace System {
    public struct TreeNode {
        public dynamic value;
        public Tree tree;
        public Nullable<TreeNode> parent;
        public int numuricValue;

        public TreeNode(dynamic value, Tree tree) {
            this.value = value;
            this.tree = tree;
            parent = null;
        }
        public TreeNode(dynamic value, Tree tree, int parent) {
            this.value = value;
            this.tree = tree;
            this.parent = parent;
        }
    }
}