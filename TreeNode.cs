namespace System {
    public class TreeNode {
        public dynamic value;
        public int[] location;
        public Tree tree;

        public TreeNode(dynamic value, Tree tree) {
            this.value = value;
            this.tree = tree;
        }
    }
}