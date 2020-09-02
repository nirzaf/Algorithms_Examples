using Algorithm_A_Day.NodesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.FastAndSlowPointers
{

    /// <summary>
    /// Move slow pointer by one and fast pointer by two every time.
    /// If slow pointer and faster poiner can meet, then there is cycle. Otherwise, there is no cycle.
    /// https://leetcode.com/problems/linked-list-cycle/discuss/710326/C-Floyd's-cycle-detection-(slow-fast-pointer)
    /// </summary>
    public class Link_List_Cycle_LC_141
    {
        public bool HasCycle(ListNode head)
        {
            if (head == null) return false;

            var fast = head;
            var slow = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if (fast == slow) return true;
            }


            return false;
        }
    }
}
