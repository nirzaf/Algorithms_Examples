using Algorithm_A_Day.BinaryTreeTraversal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.BFS
{
    public class Level_Order_Traversal
    {
        //iterative solution
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null) return result;

            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                int size = q.Count;
                var newList = new List<int>();

                for (int i = 0; i < size; i++)// every time queue has diffrent size
                {
                    var curr = q.Dequeue();
                    newList.Add(curr.val);

                    if (curr.left != null)
                    {
                        q.Enqueue(curr.left);
                    }

                    if (curr.right != null)
                    {
                        q.Enqueue(curr.right);
                    }
                }
                result.Add(newList);

            }
            return result;
        }

        // recursive solution
        public static IList<IList<int>> LevelOrderRecur(TreeNode root)
        {
            IList<IList<int>> list = new List<IList<int>>();
            TreeLevel(root, list, 0);
            return list;
        }
        public static void TreeLevel(TreeNode root, IList<IList<int>> list, int level)
        {
            if (root != null)
            {
                if (list.Count == level)
                    list.Add(new List<int>());
                list[level].Add(root.val);
                TreeLevel(root.left, list, level + 1);
                TreeLevel(root.right, list, level + 1);
            }
        }
    }
}
