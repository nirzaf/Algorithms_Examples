using Algorithm_A_Day.NodesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.BinaryTree
{
    public class LeavesOfBt
    {
        public static int counter = 0;
        public static int LeavesNodeCount(TreeNode root)
        {
            if (root != null)
            {
                if (root.left == null && root.right == null) counter++;

                if (root.left != null)
                {
                    LeavesNodeCount(root.left);
                }
                if (root.right != null)
                {
                    LeavesNodeCount(root.right);
                }
            }
            return counter;
        }


        //ITERATIVELY
        public static int LeavesNodeCountIter(TreeNode root)
        {
            int counter = 0;
            if (root == null) return counter;

            var stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (current.left == null && current.right == null) counter++;

                if (current.right != null)
                {
                    stack.Push(current.right);
                }

                if (current.left != null)
                {
                    stack.Push(current.left);
                }
            }
            return counter;
        }
    }
}
