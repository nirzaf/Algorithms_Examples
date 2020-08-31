using Algorithm_A_Day.BinaryTreeTraversal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.DFS
{
    public class Path_Sum_LC_112
    {
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return false;
            
            var s = new Stack<TreeNode>();
            s.Push(root);

            while(s.Count > 0)
            {
                var current = s.Pop();

                if (current.left == null &&
                    current.right == null && current.val == sum)
                {
                    return true;
                }

                if (current.right != null)
                {
                    current.right.val += current.val;
                    s.Push(current.right);
                }
                if (current.left != null)
                {
                    current.left.val += current.val;
                    s.Push(current.left);
                }
            }
            return false;
        }
    }
}
