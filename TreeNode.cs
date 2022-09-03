namespace System {
    public struct TreeNode {
        public object value;
        public Nullable<int> parent;

        public TreeNode(object value) {
            this.value = value;
            parent = null;
        }
        public TreeNode(object value, Nullable<int> parent) {
            this.value = value;
            this.parent = parent;
        }
    }
}