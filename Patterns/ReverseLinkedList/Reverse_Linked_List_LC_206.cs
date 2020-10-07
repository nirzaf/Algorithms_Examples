using Algorithm_A_Day.NodesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.ReverseLinkedList
{
    public class Reverse_Linked_List_LC_206
    {
        //iteratively
        //TODO: why head is 1 at the end ?????
        public static ListNode ReverseList(ListNode head)
        {
            if (head == null) return head;

            var current = head;
            ListNode previous = null;
            
            while(current != null)
            {
                ListNode next = current.next;
                current.next = previous;
                previous = current;
                current = next;

            }
            return previous;
        }

        public static ListNode ReverseListRecur(ListNode head)
        {
            if (head == null)
                return null;

            var reversed = ReverseListRecur(head.next);
            if (reversed == null)
                return head;

            var curr = head.next;
            head.next = null;
            curr.next = head;

            return reversed;
        }
    }
}
