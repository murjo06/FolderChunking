namespace System {
    public struct TreeNode {
        public object value;
        public object parent;

        public TreeNode(object value) {
            this.value = value;
            parent = null;
        }
        public TreeNode(object value, object parent) {
            this.value = value;
            this.parent = parent;
        }
        public override string ToString() => $"[{value}, {parent}]";
    }
}