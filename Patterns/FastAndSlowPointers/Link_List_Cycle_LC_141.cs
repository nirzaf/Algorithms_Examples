using Algorithm_A_Day.NodesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.FastAndSlowPointers
{

    /// <summary>
    /// Move slow pointer by one and fast pointer by two every time.
    /// If slow pointer and faster poiner can meet, then there is cycle. Otherwise, there is no cycle.
    /// Floyd's Cycle Detection is the name of this algo. Explanation:
    /// https://www.youtube.com/watch?v=LUm2ABqAs1w
    /// https://leetcode.com/problems/linked-list-cycle/discuss/710326/C-Floyd's-cycle-detection-(slow-fast-pointer)
    /// </summary>
    public class Link_List_Cycle_LC_141
    {
        public static ListNode HasCycle(ListNode head)
        {
            if (head == null) return null;

            var fast = head;
            var slow = head;

            // if any time fast is null that means thery is no cycle
            // if  fast.next is not null fast.next.next CANNOT be null because 
            // of the nature of cycle
            //while(fast, slow, fast.next)
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                // this node is the node where they meet
                // based on this we can find start of the cycle
                if (fast == slow) return slow;
            }
            return null;
        }

        public static ListNode FindStartOfLoop(ListNode meetPoint, ListNode head)
        {
            while(meetPoint != head)
            {
                meetPoint = meetPoint.next;
                head = head.next;
            }
            return meetPoint;
        }

        // determine if cycle and find start of it
        public ListNode DetectCycle(ListNode head)
        {
            if (head == null) return null;

            var fast = head;
            var slow = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (fast == slow)
                {
                    break;
                }
            }
            if (fast == null || fast.next == null) return null;

            slow = head;
            while (slow != fast)
            {

                slow = slow.next;
                fast = fast.next;
            }
            return fast;

        }
    }
}
