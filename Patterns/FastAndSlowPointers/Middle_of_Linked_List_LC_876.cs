using Algorithm_A_Day.NodesModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Algorithm_A_Day.Patterns.FastAndSlowPointers
{
    public class Middle_of_Linked_List_LC_876
    {
        public ListNode MiddleNode(ListNode head)
        {
            if (head == null) return head;

            //here when fast pointer reaches null and move 2x faster than slow
            // means slow will be in the middle == middle of linked list
            var slow = head;
            var fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;

            //var slow = head;
            //var fast = head.next;

            //while (fast != null)
            //{
            //    slow = slow.next;

            //    if (fast.next != null)
            //    {
            //        fast = fast.next.next;
            //    }
            //    else
            //    {
            //        fast = null;
            //    }
            //}

            //return slow;
        }
    }
}
