namespace System {
    public struct TreeNode {
        public dynamic value;
        public int[] location;
        public Tree tree;
        public Nullable<TreeNode> parent;

        public TreeNode(dynamic value, Tree tree) {
            this.value = value;
            this.tree = tree;
        }
    }
}