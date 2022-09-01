namespace System {
    public class Tree {
        public TreeNode[] nodes;

        public Tree(int[] values) {
            foreach(int value in values) {
                new TreeNode(value);
            }
        }
    }
}