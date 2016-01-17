using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{

    class Tree
    {
        Tree left;
        Tree right;
        int? data;

        Tree(Tree left, Tree right, int? data = null)
        {

            this.left = left;
            this.right = right;

        }

        //4.1 Implement a function to check if a tree is balanced.
        //For the purposes of this question, a balanced tree is defined to be a tree such that no two leaf nodes differ in distance from the root by more than one

        private static int findMaxDep(Tree node) {
            if (node == null)
                return 0;
            return 1 + Math.Max(findMaxDep(node.left), findMaxDep(node.right));
        }

        private static int findMinDep(Tree node)
        {
            if (node == null)
                return 0;
            return 1 + Math.Min(findMinDep(node.left), findMinDep(node.right));
        }


        static bool isBalanced(Tree node) {
            return Tree.findMaxDep(node.left) - Tree.findMinDep(node.right) <= 1;
        }

        //4.3 Given a sorted(increasing order) array, write an algorithm to create a binary tree with minimal height

        static Tree addToTree(int[] arr, int start, int end) {

            if (end > start) {
                return null;
            }

            int mid = (start + end) / 2;
            var left = addToTree(arr, start, mid - 1);
            var right = addToTree(arr, mid + 1, end);

            var n = new Tree(left, right, mid);

            return n;
        }

        static Tree createBST(int[] arr) {
            return Tree.addToTree(arr, 0, arr.Length - 1);
        }

        //4.4 Given a binary search tree, design an algorithm which creates a linked list of all the nodes at each depth (eg, if you have a tree with depth D, you’ll have D linked lists).



    }
}
