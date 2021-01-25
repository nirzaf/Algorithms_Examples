using System;
using System.Collections.Generic;
using System.Text;

namespace BST.Traversals
{
    class MiddleLvlBinaryTree
    {
        //================MAX DEPTH OF BINARY TREE ==================
        //RECURSIVELY
        public static int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int subtreesDepth = Math.Max(MaxDepth(root.left), MaxDepth(root.right));
            return 1 + subtreesDepth;
        }
        public static int MaxDepthDiff(TreeNode root)
        {
            if (root == null)
                return 0;
            int left = MaxDepthDiff(root.left);
            int right = MaxDepthDiff(root.right);
            int h;
            if(left > right)
            {
                h = 1 + left;
            }
            else
            {
                h = 1 + right;
            }

            return h;

        }
        //M(1) (root) finishes and left = 2 from M(3) and right = 2 from M(2);
        ////left is not bigger tha right so M(2) returns h = 1 + 1 (2)
        //M(2) finishes and left = 1 and right = 1;
        ////M(8) finishes and returns 1 
        //M(null) returns 0 for both right and left(for M(8))
        //M(2) right = M(8);
        //M(3) finishes and returns 1
        //M(null) returns 0 for both right and left(for M(3))
        //M(3) 
        //M(2) left = M(3)
        //left is not bigger tha right so M(3) returns h = 1 + 1 (2)
        //M(3) finishes and left = 1 and right = 1;
        //M(4) finishes(both l and r) and returns 1;
        // M(null) returns 0 for both right and left
        //     right = M(4)
        //M(3) resumes
        //M(5) finishes(both l and r) and returns 1;
        //M(null)right M(5) returns 0;
        //M(null)left M(5) return0;
        //M(5) left = M(null), right = M(null)
        //M(3) left = M(5)
        //M(1) left = M(3)





        //1 finishes returns 1 + 0
        //2 finishes returns 1 + 0
        //MaxDepth(null) right of 2 return 0
        //MaxDepth(3) finsihes returns 1 + 0
        //0= Math.Max(MaxDepth(null), MaxDepth(null));
        //MaxDepth(3)
        //0 = Math.Max(MaxDepth(3), MaxDepth(null))
        // Max.Depth(2) right of 1 
        //3 finishes returns 1 + 0;
        //4 finishes returns 1 + 0;
        //0 = Math.Max(MaxDepth(null) returns 0, MaxDepth(null) returns 0)
        //MaxDepth(4) right of 3 
        //5 finishes returns 1 + 0;
        //0 = Math.Max(MaxDepth(null) returns 0, MaxDepth(null) returns 0)
        //MaxDepth(5)
        //0 = Math.Max(MaxDepth(5), MaxDepth(4))
        //MaxDepth(3)
        //0 = Math.Max(MaxDepth(3), MaxDepth(2))
        //MaxDepth(1)




        //ITERATIVELY
        public int MaxDepthIter(TreeNode root)
        {
            if (root == null) return 0;
            int maxDepth = 0;
            Stack<DepthNode> stack = new Stack<DepthNode>();
            stack.Push(new DepthNode() { Node = root, Depth = 1 });
            while (stack.Count != 0)
            {
                DepthNode dn = stack.Pop();
                if (dn.Depth > maxDepth) maxDepth = dn.Depth;
                if (dn.Node.right != null) stack.Push(new DepthNode() { Node = dn.Node.right, Depth = dn.Depth + 1 });
                if (dn.Node.left != null)
                {
                    dn.Node = dn.Node.left;
                    dn.Depth++;
                    stack.Push(dn);
                }
            }
            return maxDepth;
        }
        private class DepthNode
        {
            public TreeNode Node { get; set; }
            public int Depth { get; set; }
        }

        //in this we have queue and dictionary we add nodes with level value to dictionary. We add node and take value from parent. root has 1 so child has 2 and their children have 3 etc
        //for every node we checks out local variable is bigger or value added witn node 
        public static int MaxDepthQ(TreeNode root)
        {
            if (root == null) return 0;

            var q = new Queue<TreeNode>();
            int maxDepth = 1;
            var map = new Dictionary<TreeNode, int>();

            map.Add(root, maxDepth);
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var curr = q.Dequeue();
                maxDepth = Math.Max(maxDepth, map[curr]);

                if (curr.left != null)
                {
                    q.Enqueue(curr.left);
                    map.Add(curr.left, map[curr] + 1);
                }

                if (curr.right != null)
                {
                    q.Enqueue(curr.right);
                    map.Add(curr.right, map[curr] + 1);
                }
            }
            return maxDepth;
        }

        //================SYMETRIC BINARY TREE ==================
        //ITERATIVELY
        public static bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return true;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root.left);
            stack.Push(root.right);

            while (stack.Count > 0)
            {
                TreeNode n1 = stack.Pop();
                TreeNode n2 = stack.Pop();

                //this conditional is here because if both leaf nodes are null
                //doesnt mean the tree is not symmetric !!
                if (n1 == null && n2 == null)
                    continue;

                if (n1 == null || n2 == null || n1.val != n2.val)
                    return false;

                stack.Push(n1.left);
                stack.Push(n2.right);

                stack.Push(n1.right);
                stack.Push(n2.left);
            }
            return true;
        }
        //RECURSIVELY
        public static bool IsSymmetricRecur(TreeNode root)
        {
            if (root == null) return true;
            return IsEqual(root.left, root.right);
        }

        public static bool IsEqual(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left == null || right == null) return false;
            if (left.val != right.val) return false;
            return IsEqual(left.left, right.right) && IsEqual(left.right, right.left);
        }
        //
        //
        //
        //
        //
        //
        //is(5,null) && is(4,3)
        //is(3,2)

        //================PATH SUM OF BINARY TREE ==================
        //ITERATIVELY
        public static bool HasPathSum(TreeNode root, int sum)
        {

            if (root == null) return false;
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode cur = stack.Pop();
                if (cur.left == null && cur.right == null && cur.val == sum) return true;
                if (cur.left != null)
                {
                    cur.left.val = cur.val + cur.left.val;
                    stack.Push(cur.left);
                }
                if (cur.right != null)
                {
                    cur.right.val = cur.val + cur.right.val;
                    stack.Push(cur.right);
                }
            }
            return false;
        }

        //RECURSIVELY
        public static bool HasPathSumRecur(TreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }
            else if (root != null && root.left == null &&
                root.right == null && root.val == sum)
            {
                return true;
            }
            else
            {
                int localSum = sum - root.val;
                return HasPathSumRecur(root.left, localSum) || HasPathSumRecur(root.right, localSum);
            }
            //if (root == null) return false;
            //if (root.val == sum && root.left == null && root.right == null) return true;
            //return HasPathSumRecur(root.left, sum - root.val) || HasPathSumRecur(root.right, sum - root.val);

            //int tally = 0;
            //public bool HasPathSum(TreeNode root, int sum)
            //{
            //    if (root == null)
            //    {
            //        return false;
            //    }

            //    tally += root.val;

            //    bool res = (root.left == null && root.right == null
            //                ? (tally == sum)
            //                : (HasPathSum(root.left, sum)
            //                    || HasPathSum(root.right, sum)));

            //    tally -= root.val;

            //    return res;
            //}


        }

        //===============Populating Next Right Pointers in Each Node
        
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next = null)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }

        //ITERATIVELY

        public static Node ConnectIter(Node root)
        {
            var preMostLeft = root;
            while (preMostLeft != null)
            {
                var cur = preMostLeft;
                while (cur != null && cur.left != null)
                {
                    cur.left.next = cur.right;
                    if (cur.next != null)
                    {
                        cur.right.next = cur.next.left;
                    }
                    cur = cur.next;
                }

                preMostLeft = preMostLeft.left;
            }

            return root;
        }
        //RECURSIVELY
        public Node ConnectRecur(Node root)
        {

            if (root == null)
                return null;

            if (root.left != null)
            {
                root.left.next = root.right;
                if (root.next != null)
                    root.right.next = root.next.left;
            }

            ConnectRecur(root.left);
            ConnectRecur(root.right);

            return root;

        }

    }

}
