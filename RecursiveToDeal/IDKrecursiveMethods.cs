using Algorithm_A_Day.NodesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.RecursiveToDeal
{
    public class IDKrecursiveMethods
    {
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            if (root.left == null) return 1 + MinDepth(root.right);
            if (root.right == null) return 1 + MinDepth(root.left);
            return 1 + Math.Min(MinDepth(root.left), MinDepth(root.right));
        }
    }
}
