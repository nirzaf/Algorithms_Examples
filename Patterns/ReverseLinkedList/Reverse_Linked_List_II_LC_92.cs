using Algorithm_A_Day.NodesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_A_Day.Patterns.ReverseLinkedList
{
    public class Reverse_Linked_List_II_LC_92
    {
        public static ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (head == null) return null;

            var current = head;
            ListNode prev = null;



            while (m > 1)
            {
                prev = current;
                current = current.next;
                m--;
                n--;
            }
            ListNode prevDummy = prev;
            ListNode tail = current;

            while (n > 0)
            {
                var next = current.next;
                current.next = prev;
                prev = current;
                current = next;
                n--;

            }

            if (prevDummy != null)
            {
                prevDummy.next = prev;
            }
            else
            {
                head = prev;
            }
            //we set next of 2 to 5 here and it is reflected in the list...
            tail.next = current;

            return head;
        }
    }
}