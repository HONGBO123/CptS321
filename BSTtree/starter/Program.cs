using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTtree
{
    class Program
    {
        static void Main(string[] args)
        {
            // string to hold input from user
            string tempArray = null;
            // string to split input from user into
            string[] Array = null;
            // root node for BST
            BSTNode root = null;
            // tree variable to hold nodes and use functions
            BSTTree tree = new BSTTree();

            // Get User's input
            Console.WriteLine("Enter a collection of numbers in the range [0, 100], separated by spaces:");
            tempArray = Console.ReadLine();
            // Split user's input on every space, put into a string array
            Array = tempArray.Split(null);

            // Convert string array into array of ints, found on https://stackoverflow.com/questions/1297231/convert-string-to-int-in-one-line-of-code-using-linq 
            // by user Simon Fox
            int[] userInput = Array.Select(s => int.Parse(s)).ToArray();

            // To check for duplicates
            List<int> tempCheck = new List<int>();

            // Insert user input into BST, nested loop to check for duplicates and break if it is a duplicate, otherwise it inserts.
            for (int i = 0; i < Array.Length; i++)
            {
                if (tempCheck.Contains(userInput[i]) == false)
                {
                    root = tree.insert(root, userInput[i]);
                    tempCheck.Add(userInput[i]);
                }
            }

            // Outputs numbers in sorted order through an in-order traversal function
            Console.Write("Tree contents: ");
            tree.inOrderTraversal(root);
            Console.WriteLine("");

            Console.WriteLine("Tree statistics:");
            // calls count function and displays number of nodes given from that function
            int track = tree.count(root);
            Console.Write("Number of nodes: " + track);

            Console.WriteLine("");

            // calls treeDepth function to get depth of tree and reports it to user
            int depth = tree.treeDepth(root);
            Console.Write("Number of levels: " + depth);

            double minimumLevels = 0;

            // we learned minimum levels is n=log(base 2)x+1 in cpts 122, where n is minimum levels and x is number of nodes so using math functions we can determine that.
            minimumLevels = Math.Floor(Math.Log(track + 1, 2));

            Console.WriteLine("");
            Console.Write("Minimum number of levels that a tree with " + track + " nodes could have = " + minimumLevels);
            Console.WriteLine("");
        }
    }

    // Node for BST that holds data and variables to traverse left or right through tree
    class BSTNode
    {
        public int data;
        public BSTNode left;
        public BSTNode right;
    }

    class BSTTree
    {
        // Insert function for tree, pass in root of tree and data to be entered
        public BSTNode insert(BSTNode root, int newData)
        {
            // If root is empty, put data into root
            if (root == null)
            {
                root = new BSTNode();
                root.data = newData;
            }

            // Root is not empty, so if new data is less than the root, insert to the left of the root.
            else if (newData < root.data)
            {
                root.left = insert(root.left, newData);
            }

            // Root is not empty and the new data is not less than the root, so insert to the right of the root.
            else
            {
                root.right = insert(root.right, newData);
            }

            return root;
        }

        // Function to traverse through BST in order.
        public void inOrderTraversal(BSTNode root)
        {
            // Check if tree is empty
            if (root == null)
            {
                return;
            }

            // move left in tree
            inOrderTraversal(root.left);
            // output data in node
            Console.Write(root.data + " ");
            // move right in tree
            inOrderTraversal(root.right);
        }

        // Function to count nodes in BST
        public int count(BSTNode root)
        {
            // No nodes so return 0
            if (root == null)
            {
                return 0;
            }
            // Root node is present so start count at 1
            int temp = 1;
            // means there is a node to the left, so iterate count
            if (root.left != null)
            {
                temp += count(root.left);
            }

            // There is a node to the right so iterate count
            if (root.right != null)
            {
                temp += count(root.right);
            }
            // return count
            return temp;
        }

        // Function to get depth of tree
        public int treeDepth(BSTNode root)
        {
            // variables to count depth of all possibilities
            int left = 0;
            int right = 0;

            // Tree is empty so return 0
            if (root == null)
            {
                return 0;
            }

            // Traverse down left side and iterate left counter
            left = 1 + treeDepth(root.left);

            // Traverse down right side of every node and iterate counter
            right = 1 + treeDepth(root.right);

            // Compares the left and right value to find maximum depth and returns it
            if (left > right)
            {
                return left;
            }

            else
            {
                return right;
            }
        }
    }
}
