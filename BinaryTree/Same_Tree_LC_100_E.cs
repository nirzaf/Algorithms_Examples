using Algorithm_A_Day.NodesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_A_Day.BinaryTree
{
    public class Same_Tree_LC_100_E
    {
        //Iterative Queue Approach(DFS)
        //T : O(Min(NodeCount))
        //S : O(Max(depth))
        bool IsValidSameValNode(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            else if (p == null || q == null)
                return false;
            else if (p.val != q.val)
                return false;
            else
                return true;
        }
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            //for both empty
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;

            Stack<TreeNode> P_stack = new Stack<TreeNode>();
            Stack<TreeNode> Q_stack = new Stack<TreeNode>();

            P_stack.Push(p);
            Q_stack.Push(q);

            while (P_stack.Count > 0 || Q_stack.Count > 0)
            {
                if (P_stack.Count != Q_stack.Count)
                    return false;

                int size = P_stack.Count();
                for (int i = 0; i < size; i++)
                {
                    TreeNode cur_p = P_stack.Pop();
                    TreeNode cur_q = Q_stack.Pop();

                    if (IsValidSameValNode(cur_p, cur_q) == false)
                        return false;

                    if (cur_p != null && cur_q != null)
                    {
                        if (cur_p.left != null || cur_q.left != null)
                        {
                            P_stack.Push(cur_p.left);
                            Q_stack.Push(cur_q.left);
                        }

                        if (cur_p.right != null || cur_q.right != null)
                        {
                            P_stack.Push(cur_p.right);
                            Q_stack.Push(cur_q.right);
                        }
                    }
                }
            }
            return true;
        }

        //recursive
        public static bool IsSameTree2(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;

            if (p.val == q.val)
            {
                return IsSameTree2(p.left, q.left) && IsSameTree2(p.right, q.right);
            }

            return false;
        }


        //JS
        //LOL
        //var isSameTree = function(p, q) {
        //    if(JSON.stringify(p)=== JSON.stringify(q)){
        //    return true;
        //    }
        //    else{
        //    return false
        //    }
        //}

        //recursive
        //        var isSameTree = function(p, q){
        //        if(!p)
        //                return q? false : true;
        //        if(!q)
        //                return false;
        //        if(p.val !== q.val)
        //                return false;
        //        if(!isSameTree(p.left, q.left))
        //                return false;
        //        return isSameTree(p.right, q.right);
        //      };
        //iterative
        //        var isSameTree = function(p, q) 
        //{
        //        var list1 =[p], list2 =[q];

        //        while(list1.length > 0)
        //        {
        //                if(list1.length !== list2.length)
        //                        return false;
        //                for(let i=list1.length-1; i>= 0; i--)
        //                {
        //                        if(!list1[i] && !list2[i])
        //                                continue;
        //                        if(!list1[i] || !list2[i])
        //                                return false;
        //                        if(list1[i].val !== list2[i].val)
        //                                return false;
        //                }

        //    let children1 =[], children2 =[];
        //    list1.forEach(el=>{if(el){children1.push(el.left);children1.push(el.right);}});
        //list2.forEach(el => { if (el) { children2.push(el.left); children2.push(el.right); } });
        //list1 = children1;
        //list2 = children2;
        //        }
        //        return true;
        //};
}
}
