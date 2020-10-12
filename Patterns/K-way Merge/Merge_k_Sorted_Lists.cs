using Algorithm_A_Day.NodesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace Algorithm_A_Day.Patterns.K_way_Merge
{
    /// <summary>
    /// We need to keep track of the heads of all lists at all times and be able to do the following operations efficiently:
    ///1- Get/Remove Min
    ///2- Add(once you remove the head of one list, you need to add the next from that list)

    ///A min heap(or a priority queue) is obviously the data structure we need here, where the key of the dictionary is the value of the ListNode, and the value of the dictionary is a queue of ListNodes having that value. (we need to queue the ones with the same value since Dictionary cannot have dupes)
    ///I implemented mine using a SortedDictionary of queues.
    ///SortedDictionary is internally implemented using a binary tree, and provides O(logn) for Add() and O(1) for PopMin(), so it's as efficient as it gets.
    /// </summary>
    public class MinHeap
    {
        public SortedDictionary<int, Queue<ListNode>> map =
            new SortedDictionary<int, Queue<ListNode>>();

        public void Add(int val, ListNode node)
        {
            if (!map.ContainsKey(val))
            {
                map.Add(val, new Queue<ListNode>());
            }

            map[val].Enqueue(node);
        }

        public ListNode PopMin()
        {
            int minKey = map.First().Key;
            ListNode node = map[minKey].Dequeue();

            if (map[minKey].Count == 0)
                map.Remove(minKey);

            return node;
        }
    }
    public class Merge_k_Sorted_Lists
    {
        public static ListNode MergeKLists(ListNode[] lists)
        {
            MinHeap heap = new MinHeap();
            foreach (var node in lists)
            {
                if (node == null)
                    continue;

                heap.Add(node.val, node);
            }
            ListNode curr = null, newHead = null;
            while (heap.map.Count > 0)
            {
                ListNode node = heap.PopMin();

                if (node.next != null)
                {
                    heap.Add(node.next.val, node.next);
                }

                if (curr == null)
                {
                    curr = node;
                    newHead = curr;
                }
                else
                {
                    curr.next = node;
                    curr = curr.next;
                }
            }
            return newHead;
        }

        /// <summary>
        /// naive solution with extra aux space :
        /// traverse each list and put all the values in the array
        /// sort the arrat
        /// create new ListNode and put vaues from array into it
        /// </summary>

        public static ListNode MergeKLists2(ListNode[] lists)
        {
            var allValues = new List<int>();
            foreach (ListNode list in lists)
            {
                if (list != null)
                {
                    var current = list;
                    while (current != null)
                    {
                        allValues.Add(current.val);
                        current = current.next;
                    }
                }
            }
            allValues.Sort();

            var dummy = new ListNode(0);
            var result = dummy;
            foreach (int number in allValues)
            {
                dummy.next = new ListNode(number);
                dummy = dummy.next;
            }

            return result.next;

        }

        /// <summary>
        /// This is similar to merge sort we sort to ListNodes
        /// and then merge this one with the rest
        /// todo: understand better
        /// </summary>


        public static ListNode MergeKLists3(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }

            return Merge(lists, 0, lists.Length - 1);
        }

        private static ListNode Merge(ListNode[] lists, int start, int end)
        {
            if (start == end)
            {
                return lists[start];
            }
            else
            {
                int mid = start + (end - start) / 2;

                ListNode left = Merge(lists, start, mid);
                ListNode right = Merge(lists, mid + 1, end);

                return merge(left, right);
            }
        }

        private static ListNode merge(ListNode first, ListNode second)
        {
            ListNode dummy = new ListNode(0);
            ListNode current = dummy;
            while (first != null && second != null)
            {
                if (first.val < second.val)
                {
                    current.next = first;
                    first = first.next;
                }
                else
                {
                    current.next = second;
                    second = second.next;
                }

                current = current.next;
            }

            if (first != null)
            {
                current.next = first;
            }
            else
            {
                current.next = second;
            }

            return dummy.next;
        }

    }
}
