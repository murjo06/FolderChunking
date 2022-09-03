namespace System {
    public struct TreeNode {
        public object value;
        public string parent;

        public TreeNode(object value) {
            this.value = value;
            parent = null;
        }
        public TreeNode(object value, string parent) {
            this.value = value;
            this.parent = parent;
        }
    }
}