using Algorithm_A_Day.NodesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.DFS
{
    public class Binary_Tree_Paths
    {
        //iteratively with new property IsVisited
        // TODO important to understand example !
        public static IList<string> BinaryTreePaths(TreeNode root)
        {
            var result = new List<string>();
            if (root == null) return result;

            var s = new Stack<TreeNode>();
            s.Push(root);
            var temp = root.left;


            while (s.Count > 0)
            {
                //store left sub tree nodes
                //it makes sure that left side of the top node is null
                while(temp != null)
                {
                    s.Push(temp);
                    temp = temp.left;
                }

                var top = s.Peek();

                if (!top.isVisited)
                {
                    top.isVisited = true;
                    //set temp to the right node
                    temp = top.right;
                    //check the right side
                    if (temp == null)
                    {
                        //both sides are null so we can print current stack
                        string stackString = PrintStack(s);
                        result.Add(stackString);
                        //pop visited node from stack
                        s.Pop();
                    }
                }
                else
                {
                    //pop visited node from stack
                    s.Pop();
                }    
            }
            return result;
        }

        private static string PrintStack(Stack<TreeNode> s)
        {
            string result = string.Empty;
            var enumerator = s.GetEnumerator();

            while (enumerator.MoveNext())
            {
                result += enumerator.Current.val.ToString() + ">-";
            }

            var charrArray = result.ToCharArray();
            Array.Reverse(charrArray);
            return new string(charrArray).Trim(new char[] { '-', '>' });
        }

        // iterative with 2 Queues np Stack 
        // brilliant !!!
        public static IList<string> BinaryTreePaths2Queues(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            Queue<string> qStr = new Queue<string>();
            IList<string> result = new List<string>();
            if (root == null) return result;
            queue.Enqueue(root); qStr.Enqueue(root.val.ToString());
            while (queue.Count != 0)
            {
                TreeNode cur = queue.Dequeue();
                string curStr = qStr.Dequeue();
                if (cur.left == null && cur.right == null) result.Add(curStr);
                if (cur.left != null)
                {
                    queue.Enqueue(cur.left);
                    qStr.Enqueue(curStr + "->" + cur.left.val);
                }
                if (cur.right != null)
                {
                    queue.Enqueue(cur.right);
                    qStr.Enqueue(curStr + "->" + cur.right.val);
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
