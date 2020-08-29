using Algorithm_A_Day.BinaryTreeTraversal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.BFS
{
    public class Level_Order_Traversal
    {
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null) return result;

            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                var c = q.Count; //every iteration count is diffrent
                var lvl = new List<int>();

                for (int i = 0; i < c; i++)
                {
                    var node = q.Dequeue();
                    lvl.Add(node.val);
                }
                result.Add(lvl);
            }

            return result;
        }
    }
}
