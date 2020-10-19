using Algorithm_A_Day.NodesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.DFS
{
    public class Path_Sum_II_LC_113
    {
        // recursively
        public static IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            var result = new List<IList<int>>();
            FindPaths(root, sum, new List<int>(), result);


            return result;
        }

        private static void FindPaths(TreeNode root, int sum, List<int> current, IList<IList<int>> result)
        {
            if (root == null) return;
            current.Add(root.val);

            if (root.left == null &&
                root.right == null &&
                root.val == sum)
            {
                result.Add(current);
            }

            FindPaths(root.left, sum - root.val, new List<int>(current), result);
            FindPaths(root.right, sum - root.val, new List<int>(current), result);

        }
    }




}
