using Algorithm_A_Day.NodesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Recursion
{
    
    public class Swap_Nodes_in_Pairs_LC_24_M
    {
        //recursive
        public ListNode SwapPairs(ListNode head)
        {
            if (head?.next == null)
                return head;

            var first = head;
            var second = head.next;
            var remaining = second.next;

            second.next = first;
            first.next = SwapPairs(remaining);

            return second;
        }


        /// <summary>
        /// a->b->c->d 
        /// second node in orginal LL is always a start in new LL
        /// each iteration we're changing second node pointer direction so for a->b  to a-><-b
        /// we are loosing connection to c node so we save it in temporary variable 
        /// then we set new pointer for a to next of temp(d) variable  b->a->d
        /// then we change temp for second pair of nodes (temp alwasy point for the next of second node in a pair)
        /// 1->2->3->4
        /// 
        /// p = 1->2->3->4->5, newStart = 2->3->4->5
        /// FIRST ITERATION
        /// q = 2->3->4->5
        /// temp = 3->4->5
        /// q.next = p           q = 2->1->2->1 and so on | dla 2 ustawiamy next 1 ale ze ta jedynka wskazywala na 2(ktora wsazuje na 1) to sie zapetla
        ///        | q -> p -> q-> p ..... q next to jest p a p next to q
        /// 
        /// p.next = temp.next   p = 1->4->5->null
        /// p = temp             p = 3->4->5->null
        ///                      q = 2-1-4-5-null
        /// SECOND ITERATION
        /// q = 4->5
        /// temp = 5->null
        /// q.next = p           q = 4->3->4->3 and so on q -> p -> q-> p ..... q next to jest p a p next to q
        /// temp.next == null so 
        /// p.next = temp        p = 3->5
        ///                      q = 4-3-5   
        /// while breaks
        /// </summary>

        public static ListNode SwapPairs2(ListNode head)
        {
            ListNode p = head;
            ListNode newStart = p.next;

            while (true)
            {
                var q = p.next;
                var temp = q.next;
                q.next = p;     
                //base case for while loop
                if(temp == null)
                {
                    p.next = null;
                    break;
                }
                if(temp.next == null)
                {
                    p.next = temp;
                    break;
                }
                p.next = temp.next;
                p = temp;
            }

            return newStart;
        }

        public ListNode SwapPairs3(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode dummy = new ListNode(0, head);
            ListNode previous = dummy;
            ListNode current = previous.next;
            ListNode next = current.next;

            //    P    C    N
            // I: D -> 1 -> 2 -> 3
            // O:      2 -> 1 -> 3

            while (current != null && next != null)
            {
                previous.next = next;      // (P)D -> (N)2 -> 3,  (C)1 -> 2
                current.next = next.next;  // D -> 2 -> 3,  1 -> 3 
                next.next = current;       // (P)D -> (N)2 -> (C)1 -> 3

                previous = current;
                current = current.next;
                if (current != null)
                {
                    next = current.next;
                }
            }

            return dummy.next;
        }
        // with modyfing values so against the constrains
        public static ListNode SwapPairs4(ListNode head)
        {
            
            ListNode current = head;
            //currnet.next != null for odd count linklist
            while (current != null && current.next != null)
            {
                int tmp = current.val;
                current.val = current.next.val;
                current.next.val = tmp;
                current = current.next.next;
            }
            return head;
        }

        // todo:????
        public ListNode SwapPairs5(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            var res = head.next;
            ListNode parent = null;
            while (head != null)
            {
                SwapNodes(ref parent, ref head);
                head = head.next;
            }
            return res;
        }

        private void SwapNodes(ref ListNode parent, ref ListNode node)
        {
            var nextNode = node.next;
            if (nextNode == null)
                return;

            if (parent != null)
                parent.next = nextNode;
            node.next = nextNode.next;
            nextNode.next = node;
            parent = node;
        }
    }
}
