using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST.Traversals
{
    class AdvancedBT
    {
        //The the basic idea is to take the last element in postorder array as the root,
        //find the position of the root in the inorder array;
        //then locate the range for left sub-tree and right sub-tree and do recursion.
        //Use a HashMap to record the index of root in the inorder array.
        //==========Construct Binary Tree from Inorder and Postorder Traversal===========
        //ITERATIVELY
        public static TreeNode BuildTreeInPostIter(int[] inorder, int[] postorder)
        {
            if (postorder.Length == 0) return null;
            // stack that maintains the node along with its inorder index
            Stack<Tuple<TreeNode, int>> stack = new Stack<Tuple<TreeNode, int>>();
            // last of postorder is the root
            var root = new TreeNode(postorder[postorder.Length - 1]);
            stack.Push(new Tuple<TreeNode, int>(root, Array.IndexOf(inorder, root.val)));

            for (int i = postorder.Length - 2; i >= 0; --i)
            {
                // get the next element from post order
                //var inorder = new int[] { 9, 3, 15, 20, 7 };
                //var postorder = new int[] { 9, 15, 7, 20, 3 };
                var node = new TreeNode(postorder[i]);
                // get its inorder index
                var inOrderId = Array.IndexOf(inorder, node.val);
                if (stack.Count > 0)
                {
                    // if the current inorder index is greater than previous inorder index
                    // the element is on right side
                    if (inOrderId > stack.Peek().Item2)
                    {
                        stack.Peek().Item1.right = node;
                    }
                    else
                    {
                        // the element is on the left side of one the elements in stack
                        // unwind the stack till you find a best place
                        var top = stack.Pop();
                        while (stack.Count > 0 && stack.Peek().Item2 > inOrderId)
                        {
                            top = stack.Pop();
                        }
                        top.Item1.left = node;
                    }
                    stack.Push(new Tuple<TreeNode, int>(node, inOrderId));
                }
            }
            return root;
        }
        //RECURSIVELY
        public TreeNode BuildTreeInPostRecur(int[] inorder, int[] postorder)
        {
            return DFS(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
        }

        private TreeNode DFS(int[] inOrder, int inLeft, int inRight, int[] postOrder, int postLeft, int postRight)
        {
            if (postLeft > postRight)
            {
                return null;
            }

            var curValue = postOrder[postRight];

            var count = 0;
            var i = inLeft;

            while (i <= inRight)
            {
                if (inOrder[i] == curValue)
                {
                    break;
                }
                i++;
                count++;
            }

            var cur = new TreeNode(curValue);
            cur.left = DFS(inOrder, inLeft, i - 1, postOrder, postLeft, postLeft + count - 1);
            cur.right = DFS(inOrder, i + 1, inRight, postOrder, postLeft + count, postRight - 1);

            return cur;
        }




        //==========Construct Binary Tree from Inorder and Preorder Traversal===========
        //The basic idea is here:
        //Say we have 2 arrays, PRE and IN.
        //Preorder traversing implies that PRE[0] is the root node.
        //Then we can find this PRE[0] in IN, say it's IN[5].
        //Now we know that IN[5] is root, so we know that IN[0] - IN[4] is on the left side, IN[6] to the end is on the right side.
        //Recursively doing this on subarrays, we can build a tree out of it :)

        //ITERATIVELY
        public TreeNode BuildTreePreInIter(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0) return null;

            int iPre = 1, iIn = 0;
            var root = new TreeNode(preorder[0]);
            var stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Any() && iPre < preorder.Length)
            {
                var node = stack.Peek();

                if (node.val == inorder[iIn])
                {
                    stack.Pop();
                    iIn++;

                    while (stack.Count != 0 && stack.Peek().val == inorder[iIn])
                    {
                        node = stack.Pop();
                        iIn++;
                    }

                    if (iPre < preorder.Length)
                    {
                        node.right = new TreeNode(preorder[iPre++]);
                        stack.Push(node.right);
                    }
                }
                else
                {
                    node.left = new TreeNode(preorder[iPre++]);
                    stack.Push(node.left);
                }
            }

            return root;
        }

        //RECURSIVELY
        public static TreeNode BuildTreePreInRecur(int[] preorder, int[] inorder)
        {
            if (preorder == null || preorder.Length == 0 || inorder == null || inorder.Length == 0)
                return null;
            return Build(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }

        public static TreeNode Build(int[] preorder, int preStart, int preEnd, int[] inorder, int inStart, int inEnd)
        {

            if (inStart > inEnd || preStart > preEnd)
                return null;

            TreeNode node = new TreeNode(preorder[preStart]);
            int nodeIdx = Array.IndexOf(inorder, preorder[preStart]);
            //var inorder = new int[] { 9, 3, 15, 20, 7 };
            //var preorder = new int[] { 3, 9, 20, 15, 7 };
            node.left = Build(preorder, preStart + 1, preStart + (nodeIdx - inStart), inorder, inStart, nodeIdx - 1);
            node.right = Build(preorder, preStart + (nodeIdx - inStart) + 1, preEnd, inorder, nodeIdx + 1, inEnd);
            return node;
        }

        //d(preeorder, 0 + 1,

        //LOWEST COMMON ANCESTOR
        //RECURSIVELY

        public static TreeNode LCARecur(TreeNode root, TreeNode p, TreeNode q)
        {
            if(root == null || p == null || q == null)
            {
                return null;
            }

            if (root.val == q.val || root.val == p.val) return root;

            var left = LCARecur(root.left, p, q);
            var right = LCARecur(root.right, p, q);

            if (left != null && right != null) return root;
            else if (left != null) return left;
            else return right;
        }

        //ITERATIVELY
        public static TreeNode LCAIter(TreeNode root, TreeNode p, TreeNode q)
        {
            
            if (root == null)
            {
                return null;
            }
            if ((p == root) || (q == root))
            {
                return root;
            }
            if (root.left == null && root.right == null)
            {
                return null;
            }
            List<TreeNode> path1 = new List<TreeNode>();
            List<TreeNode> path2 = new List<TreeNode>();

            path1 = getPath(root, p, path1);
            path2 = getPath(root, q, path2);
            if (path1.Count > 1 && path2.Count > 1)
            {
                for (int i = 0; i < path1.Count; i++)
                {
                    if ((i == path1.Count - 1 || i == path2.Count - 1) && path1[i] == path2[i])
                    {
                        return path1[i];
                    }
                    if (path1[i] != path2[i])
                    {
                        return path1[i - 1];
                    }
                }
            }
            return null;
        }
        /**
            * Return the path from root to node
            */
        private static List<TreeNode> getPath(TreeNode root, TreeNode node, List<TreeNode> path)
        {
            if (root == null)
            {
                return path;
            }
            if (root == node)
            {
                path.Add(root);
                return path;
            }
            if (root.left == node)
            {
                path.Add(root);
                path.Add(root.left);
                return path;
            }
            if (root.right == node)
            {
                path.Add(root);
                path.Add(root.right);
                return path;
            }
            if (isLeftChild(root, node))
            {
                path.Add(root);
                return getPath(root.left, node, path);
            }
            else
            {
                path.Add(root);
                return getPath(root.right, node, path);
            }
        }
        /**
                * Return true if the a given node is in the left subtree
            */
        private static bool isLeftChild(TreeNode root, TreeNode node)
        {
            return isChild(root.left, node);
        }

        /**
            * Return true if the a given node is in the right subtree
        */
        private static bool isRightChild(TreeNode root, TreeNode node)
        {
            return isChild(root.right, node);
        }

        /**
            * Return true if the a given node is a child of the tree rooted at parent.
        */
        private static bool isChild(TreeNode parent, TreeNode child)
        {
            if (parent == null)
            {
                return false;
            }
            if (parent == child)
            {
                return true;
            }
            return (isChild(parent.left, child) || isChild(parent.right, child));
        }


        //============SERIALIZATION

        static void preorderSerialize(TreeNode node, StringBuilder sb)
        {
            if (node == null)
            {
                sb.Append("#,");
                return;
            }

            sb.Append(node.val); sb.Append(",");

            preorderSerialize(node.left, sb);
            preorderSerialize(node.right, sb);
        }

        static TreeNode preorderDeserialize(string[] nodes, ref int pos)
        {
            if (nodes[pos] == "#")
            {
                pos++;
                return null;
            }
            var node = new TreeNode(int.Parse(nodes[pos++]));
            node.left = preorderDeserialize(nodes, ref pos);
            node.right = preorderDeserialize(nodes, ref pos);
            return node;
        }

        // Encodes a tree to a single string.
        public static string serialize(TreeNode root)
        {
            var sb = new StringBuilder();
            preorderSerialize(root, sb);
            return sb.ToString().Trim(','); //remove trailing comma
        }

        // Decodes your encoded data to tree.
        public static TreeNode deserialize(string data)
        {
            int pos = 0;
            var tokens = data.Split(',');
            return preorderDeserialize(tokens, ref pos);
        }


    }
}
   


