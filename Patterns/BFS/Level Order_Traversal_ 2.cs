using Algorithm_A_Day.BinaryTreeTraversal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.BFS
{
    /// <summary>
    /// The algorithm is the same as Classic Level Order Traversal but we need to reverse the the list at the end or
    /// we can insert every new sublist at the beginning of the main list with list.Insert(0, Sublist) where 0 is the index 
    /// </summary>
    public class Level_Order_Traversal__2
    {
        public static IList<IList<int>> LevelOrderTraversal(TreeNode root)
        {
            if (root == null) return null;

            var result = new List<IList<int>>();

            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                int size = q.Count;
                var newList = new List<int>();

                for (int i = 0; i < size; i++)
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
                result.Add(newList); //result.Insert(0, newList);

            }
            result.Reverse();
            return result;
        }
    }
}
