using Algorithm_A_Day.NodesModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <summary>
        /// for sum 22 we substruct each node value every recursive call
        /// so at the end if sum = 0, both childs are null it added list to the list
        /// we pass new list with current(include this call) values every call
        /// </summary>
       
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
        //recursively
        //public static IList<IList<int>> PathSum2(TreeNode root, int sum)
        //{
        //    var result = new List<IList<int>>();

        //    if (root == null) return result;
        //    var stack = new Stack<TreeNode>();
        //    stack.Push(root);
        //    var currentList = new List<int>();
        //    int tempSum = sum;
            

        //    while (stack.Count > 0)
        //    {
        //        var current = stack.Pop();
        //        currentList.Add(current.val);
        //        tempSum -= current.val;

        //        if (currentList.Sum() == sum)
        //        {
        //            result.Add(currentList);
        //        }

        //        if(current.right != null)
        //        {
        //            stack.Push(current.right);
        //        }

        //        if (current.left != null)
        //        {
        //            stack.Push(current.left);
        //        }
        //    }




        //}
    }




}
