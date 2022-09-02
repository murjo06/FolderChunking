namespace System {
    public class Tree {
        public TreeNode[] nodes;

        public Tree(int[] values) {
            var i = 0;
            foreach(int value in values) {
                nodes[i] = new TreeNode(value, this);
                i++;
            }
        }
    }
}