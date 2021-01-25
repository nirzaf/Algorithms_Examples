using Algorithm_A_Day.NodesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.BFS
{
    public class Average_of_Levels_in_Binary_Tree_LC_637
    {
        public static IList<double> AverageOfLevels(TreeNode root)
        {
            var result = new List<double>();
            if (root == null) return result;

            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                double size = q.Count;
                double currentSum = 0;
                for (int i = 0; i < size; i++)
                {
                    var current = q.Dequeue();
                    currentSum += current.val;
                    if (current.left != null)
                    {
                        q.Enqueue(current.left);
                    }
                    if (current.right != null)
                    {
                        q.Enqueue(current.right);
                    }
                }
                double avr = currentSum / size;
                result.Add(avr);
            }
            return result;
        }
    }
}
