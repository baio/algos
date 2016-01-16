using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class LinkedList
    {
        private LinkedList next;
        int data;

        LinkedList(int data) {
            this.data = data;
        }

        void appendToTail(int data) {
            LinkedList node = new LinkedList(data);
            this.next = node;
            LinkedList n = this;
            while (n.next != null) {
                n = n.next;
            }
            n.next = node;
        }

        static LinkedList delete(LinkedList head, int data) {
            if (head.data == data) {
                return head.next;
            }
            LinkedList n = head;
            while (n.next != null)
            {
                if (n.next.data == data) {
                    n.next = n.next.next;
                    return head;
                }

                n = n.next;
            }
            return head;
        }

        // 2.1 Write code to remove duplicates from an unsorted linked list.
        // How would you solve this problem if a temporary buffer is not allowed?

        static void removeDups(LinkedList head)
        {
            LinkedList prev = null;
            LinkedList n = head;
            var list = new List<int>();
            
            while (n != null){
                if (list.Exists(i => i == n.data))
                {
                    prev.next = n.next;
                }
                else {
                    prev = n;
                    list.Add(n.data);
                }
                n = n.next;
            }
        }

        static void removeDups2(LinkedList head) {
            LinkedList prev = null;
            LinkedList n = head;            
            var list = new List<int>();

            while (n != null)
            {
                LinkedList k = head;

                while (k != n) {

                    if (n.data == k.data) {

                        prev.next = n.next;

                        break;

                    }

                    k = k.next;
                }

                if (k == n) {
                    prev = n;
                }

                n = n.next;
            }
        }

        // 2.2 Implement an algorithm to find the nth to last element of a singly linked list.

        static LinkedList nthToLast(LinkedList root, int idx)
        {
            LinkedList n = root;
            for (int i = 0; i < idx; i++)
            {
                if (n.next == null) {
                    return null;
                }

                n = n.next;
            }

            return n;
        }

        /*
        2.3 Implement an algorithm to delete a node in the middle of a single linked list, given only access to that node.
        EXAMPLE
        Input: the node ‘c’ from the linked list a->b->c->d->e
        Result: nothing is returned, but the new linked list looks like a->b->d->e
        */

        static void deleteNode(LinkedList node)
        {
            if (node.next != null)
            {
                node.data = node.next.data;
                node.next = node.next.next;
            }
            else {
                throw new Exception("Can't remove last node");
            }

        }

        /*
            2.4 You have two numbers represented by a linked list, 
            where each node contains a single digit. 
            The digits are stored in reverse order, such that the 1’s digit is at the head of the list. Write a function that adds the two numbers and returns the sum as a linked list.
            EXAMPLE
            Input: (3 -> 1 -> 5) + (5 -> 9 -> 2)
            Output: 8 -> 0 -> 8
        */

        static LinkedList sum(LinkedList node1, LinkedList node2, int carry = 0)
        {
            if (node1 == null && node2 == null) {
                throw new ArgumentException("Nodes can't be null");
            }

            int value = carry;

            value += node1.data + node2.data;

            var res = new LinkedList(value % 10);

            res.next = sum(node1.next, node2.next, value >= 10 ? 1 : 0);

            return res;
        }


        /*
            2.5 Given a circular linked list, implement an algorithm which returns node at the beginning of the loop.
            DEFINITION
            Circular linked list: A (corrupt) linked list in which a node’s next pointer points to an earlier node, so as to make a loop in the linked list.
            EXAMPLE
            input: A -> B -> C -> D -> E -> C [the same C as earlier]
            output: C
        */

        static LinkedList findCirc(LinkedList head)
        {
            var n = head;

            while (n != null) {

                LinkedList k = n.next;

                while (k != null)
                {
                    if (k == n)
                    {
                        return k;
                    }

                    k = k.next;
                }

                n = n.next;
            }

            return null;
        }

    }



}
