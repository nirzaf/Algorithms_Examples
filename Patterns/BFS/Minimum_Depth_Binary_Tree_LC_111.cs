using Algorithm_A_Day.BinaryTreeTraversal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.BFS
{
    public class Minimum_Depth_Binary_Tree_LC_111
    {
        public static int MinDepth(TreeNode root)
        {
            if (root == null) return 0;

            var s = new Queue<TreeNode>();
            root.val = 1;
            s.Enqueue(root);
            int result = 1;

            while(s.Count > 0)
            {
                var size = s.Count;


                for (int i = 0; i < size; i++)
                {
                    var curr = s.Dequeue();

                    if (curr.left != null)
                    {
                        curr.left.val = curr.val + 1;
                        s.Enqueue(curr.left);
                    }
                    if (curr.right != null)
                    {
                        curr.right.val = curr.val + 1;
                        s.Enqueue(curr.right);
                    }
                    if (curr.left == null && curr.right == null)
                    {
                        return curr.val;

                    }
                }
            }

            return result;
        }

        //with variable
        public int MinDepth2(TreeNode root)
        {
            if (root == null) return 0;

            // level order traversal
            Queue<TreeNode> level = new Queue<TreeNode>();
            level.Enqueue(root);
            int depth = 0;
            while (level.Count > 0)
            {
                // count level
                depth++;

                // traverse level
                int count = level.Count;
                while (count-- > 0)
                {
                    TreeNode node = level.Dequeue();
                    if (node.left == null && node.right == null) return depth;
                    if (node.left != null) level.Enqueue(node.left);
                    if (node.right != null) level.Enqueue(node.right);
                }
            }

            return depth;
        }

        //recirsive solution
        public int MinDepthRecur(TreeNode root)
        {
            int minDepth = int.MaxValue;
            //ref is used here so not the copy but memory of this exact variable
            findMinDepth(root, 0, ref minDepth);
            return minDepth == int.MaxValue ? 0 : minDepth;
        }

        private void findMinDepth(TreeNode node, int currentDepth, ref int minDepth)
        {
            if (node != null)
            {
                if (node.left == null && node.right == null)
                {
                    minDepth = Math.Min(minDepth, 1 + currentDepth);
                }

                else
                {
                    findMinDepth(node.left, currentDepth + 1, ref minDepth);
                    findMinDepth(node.right, currentDepth + 1, ref minDepth);
                }
            }
        }
    }
}
