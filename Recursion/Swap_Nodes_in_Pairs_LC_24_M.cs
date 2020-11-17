using Algorithm_A_Day.NodesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Recursion
{
    public class Swap_Nodes_in_Pairs_LC_24_M
    {
        //recursive
        //public static ListNode SwapPairs(ListNode head)
        //{
        //    if (head == null || head.next == null) return head;

        //    return Helper(head);
        //}

        //private static ListNode Helper(ListNode head)
        //{

        //    var current = head;
        //    var nextCurrent = head.next;

        //    return current;

        //}

        public ListNode SwapPairs(ListNode head)
        {
            ListNode p = head;
            ListNode newStart = p.next;

            while (true)
            {
                var q = p.next;
                var temp = q.next;
                //base case for while loop
                if(temp == null || temp.next == null)
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
            var dummy = new ListNode(-1);
            dummy.next = head;

            var pre = dummy;
            while (pre != null && pre.next != null && pre.next.next != null)
            {
                var newEnd = pre.next;
                var newStart = pre.next.next;

                pre.next = newStart;
                newEnd.next = newStart.next;
                newStart.next = newEnd;
                pre = newEnd;
            }

            var newHead = dummy.next;
            dummy.next = null;

            return newHead;
        }
        // with modyfing values so against the constrains
        public ListNode SwapPairs4(ListNode head)
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
    }
}
