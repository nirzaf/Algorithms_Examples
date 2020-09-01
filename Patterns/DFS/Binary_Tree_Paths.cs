using Algorithm_A_Day.BinaryTreeTraversal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.DFS
{
    public class Binary_Tree_Paths
    {
        //iteratively
        public static IList<string> BinaryTreePaths(TreeNode root)
        {
            var result = new List<string>();
            if (root == null) return result;

            var s = new Stack<TreeNode>();
            s.Push(root);
            string path = string.Empty;


            while (s.Count > 0)
            {
                var curr = s.Pop();
                path += curr.val.ToString() + "->";

                if (curr.right != null)
                {
                    s.Push(curr.right);
                }
                if (curr.left != null)
                {
                    s.Push(curr.left);

                }

                if (curr.left == null && curr.right == null)
                {
                    result.Add(path.Trim(new char[] {'-','>' }));
                    path = path.Substring(0, path.Length - 3);
                }
            }
            return result;
        }

        // recursively
        public static IList<string> BinaryTreePathsRecur(TreeNode root)
        {
            var result = new List<string>();
            DFS(root, new List<string>(), result);
            return result;
            
        }

        private static void DFS(TreeNode root, List<string> oneResult, List<string> result)
        {
            if (root == null) return;

            oneResult.Add($"{root.val}");

            if(root.left == null && root.right ==null){
                //leaf node
                result.Add(string.Join("->", oneResult));
            }else
            {
                DFS(root.left, oneResult, result);
                DFS(root.right, oneResult, result);
            }
            oneResult.RemoveAt(oneResult.Count - 1);
        }
    }
}
