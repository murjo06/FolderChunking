namespace System {
    public struct Tree {
        public TreeNode[] nodes;
        public int Length {get {return nodes.Length;}}

        public Tree(object[] values, object[] parents) {
            nodes = new TreeNode[values.Length];
            int i = 0;
            foreach(object value in values) {
                nodes[i] = new TreeNode(value, parents[i]);
                i++;
            }
        }

        public TreeNode GetNode(int index) => nodes[index];
        public override string ToString() {
            string stringNodes = "";
            foreach(TreeNode node in nodes) {
                stringNodes += node.ToString();
            }
            return stringNodes;
        }
    }
}