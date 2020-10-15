using System;
using System.Collections.Generic;
using System.Linq;

namespace BST.Traversals
{
    public class BinaryTreeTraversals
    {
        //================PRE ORDER==================
        //it first go to the right becuse if node hase both righ and left 
        // and u put left second it will be on the top of the stack stack.Pop saves to variable
        public static IList<int> PreorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null) return result;

            var stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Any())
            {
                var current = stack.Pop();
                result.Add(current.val);


                if (current.right != null)
                {
                    stack.Push(current.right);
                }

                if (current.left != null)
                {
                    stack.Push(current.left);
                }
            }
            return result;
        }

        public static IList<int> PreorderTraversalRecursively(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;
            result.Add(root.val);

            //it can be also like if(root != null){above ifs blocks}
            if (root.left != null)
            {
                result.AddRange(PreorderTraversalRecursively(root.left));
            }

            if (root.right != null)
            {
                result.AddRange(PreorderTraversalRecursively(root.right));
            }

            //AddRange is diffrent than Add
            return result;
        }
        //=========version without the AddRange============
        public static IList<int> Ptr(TreeNode root)
        {
            var result = new List<int>();


            Pt(root, result);
            return result;
        }

        public static void Pt(TreeNode root, List<int> newList)
        {
            if (root == null) return;
            newList.Add(root.val);

            Pt(root.left, newList);
            Pt(root.right, newList);
        }

        //================IN ORDER==================
        //Basic Algorithm Using Stack

        //Keep Navigating to left most node and add to stack.
        //When no more items on left, it means reached the leaf node.
        //Use Stack to add items, so that the last leaf node is the first one to be removed.
        //Once the left Leaf node is processed, then process the parent node and then the right node.
        //The processing step for parent node in above step is not required as that node is either
        //a left or right node of a tree.Note that the root node is already added at the start.
        //Time Complexity : O(N), All elements are visited.

        //Space Complexity : O(K), Depends on the Height of the Tree (k).
        //We could use  Yield, therefore no memory for the new list.However,
        //internally, the state machine and iterator would use the memory.
        public static IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            var stack = new Stack<TreeNode>();
            TreeNode currentNode = root;

            while (currentNode != null || stack.Count != 0) 
                // dopoki ktorys z tych nie jest spelniony czyli curr moze byc nullem co nie konczy while
                //dlatego nie musimy dodac noda do stack od razu bo curr!= null
            {
                while (currentNode != null)
                {
                    // Traverse the Leftmost node until no more left nodes
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }
                if (stack.Count != 0)
                {
                    // Reached the end of the left Node, no more left nodes to process, So consume it.
                    currentNode = stack.Pop();
                    // We could use yield return so that the operation is lazy
                    result.Add(currentNode.val);
                    // Move to next
                    currentNode = currentNode.right;
                }
            }
            return result;
        }
        static List<int> list;
        public static IList<int> InorderTraversalRecursively(TreeNode root)
        {
            list = new List<int>();
            InOrder(root);
            return list;
        }
        public static void InOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            InOrder(node.left);
            list.Add(node.val);
            InOrder(node.right);
        }


        public IList<int> InorderTraversal2(TreeNode root) // emtpy tree, with one root node, with more nodes
        {
            if (root == null)
            {
                return new List<int>();
            }

            var nodes = new List<int>();

            var stack = new Stack<TreeNode>();
            stack.Push(root);

            var visited = new HashSet<TreeNode>();

            while (stack.Count > 0)
            {
                var current = stack.Peek();
                var left = current.left;

                while (left != null && !visited.Contains(left))
                {
                    stack.Push(left);
                    left = left.left;
                }

                var visit = stack.Pop();

                nodes.Add(visit.val);

                visited.Add(visit);

                if (visit.right != null)
                {
                    stack.Push(visit.right);
                }
            }

            return nodes;
        }


        //================POST ORDER==================
        //INTERATIVELY
        public static IList<int> PostOrderTraversal(TreeNode root)
        {
            if (root == null)
                return new List<int>();

            var stack = new Stack<TreeNode>();
            stack.Push(root);

            var result = new List<int>();
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                result.Add(current.val);

                if (current.left != null)
                    stack.Push(current.left);

                if (current.right != null)
                    stack.Push(current.right);
            }

            //var array = result.ToArray();
            //Array.Reverse(array);

            //result.Clear();
            //foreach (var item in array)
            //    result.Add(item);
            result.Reverse();
            return result;
        }

        public static IList<int> PostOrderTraversalDiff(TreeNode root)
        {
            List<int> arrList = new List<int>();
            if (root == null) return arrList;
            Stack<TreeNode> s1 = new Stack<TreeNode>();
            Stack<TreeNode> s2 = new Stack<TreeNode>();
            s1.Push(root);
            while (s1.Count > 0)
            {
                TreeNode temp = s1.Pop();
                s2.Push(temp);
                if (temp.left != null)
                {
                    s1.Push(temp.left);
                }
                if (temp.right != null)
                {
                    s1.Push(temp.right);
                }
            }

            while (s2.Count > 0)
                arrList.Add(s2.Pop().val);
            return arrList;
        }

        //RECURSIVELY
        public static IList<int> PostOrderTraversalRec(TreeNode root)
        {
            list = new List<int>();
            PostOrder(root);
            return list;
        }

        public static void PostOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            PostOrder(node.left);
            PostOrder(node.right);
            list.Add(node.val);
        }

        //================Level ORDER (Breadth-First Search)==================
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            var ans = new List<IList<int>>();
            var q = new Queue<TreeNode>();
            if (root != null)
            {
                q.Enqueue(root);
                ans.Add(new List<int>() { root.val });
            }

            while (q.Count > 0)
            {
                var nq = new Queue<TreeNode>();
                while (q.Count > 0)
                {
                    TreeNode node = q.Dequeue();
                    if (node.left != null)
                        nq.Enqueue(node.left);
                    if (node.right != null)
                        nq.Enqueue(node.right);
                }

                if (nq.Count > 0)
                    ans.Add(nq.Select(x => x.val).ToList());
                q = nq;
            }
            return ans;
        }

        public static IList<IList<int>> LevelOrderDiff(TreeNode root)
        {
            if (root == null) return new List<IList<int>>();

            var answer = new List<IList<int>>();
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var c = q.Count;    //it here cause the queue size changes all the time
                var lvl = new List<int>();
                for (var i = 0; i < c; i++)
                {
                    var node = q.Dequeue();
                    lvl.Add(node.val);
                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);

                }
                answer.Add(lvl);
            }
            return answer;
        }

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

        //tl(1,list, 0)
        //if(0 == 0)
        //list.add
        //list[0].add value 1
        //tl(3, list, 1)  
        //tl(2, list, 1)  
        //List{list[0]}


        //tl(3, list, 1)
        //if(list.count 1 == 1)
        //list.add 
        //list[1].add value 3
        //tl(5, list, 1 + 1)  
        //tl(4, list, 1 + 1 )
        //List{list[1,], list[3,]}

        //tl(5, list, 2)
        //if(list.count 2 == 2)
        //list.add 
        //list[2].add value 5
        //tl(null, list, 2 + 1)  
        //tl(null, list, 2 + 1 )   
        //List{list[1], list[3], list[5],}
        public static IList<int> xxxx(TreeNode root)
        {
            if (root == null)
                return new List<int>();

            IList<int> result = new List<int>();
            Stack<TreeNode> stack1 = new Stack<TreeNode>(),
                            stack2 = new Stack<TreeNode>();

            stack1.Push(root);

            while (stack1.Count != 0)
            {
                TreeNode node = stack1.Pop();

                stack2.Push(node);

                if (node.left != null)
                    stack1.Push(node.left);
                if (node.right != null)
                    stack1.Push(node.right);
            }

            while (stack2.Count != 0)
                result.Add(stack2.Pop().val);

            return result;
        }
    }
}



