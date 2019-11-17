using System;
using static System.Console;

namespace BinarySearchTreeRecursive
{
    public class BinarySearchTree
    {
        internal class Node
        {
            public string Key;
            public string Value;
            public Node Left;
            public Node Right;           
        }

        internal Node Root;

        public BinarySearchTree()
        {
            Root = null;
        }

        //Recursive Insert routine.  Public part starts at root and starts
        //the recursion to find the node after which to put the new node.


        public void Insert(string key, string value)
        {
            Root = Insert(Root, key, value);
        }
        private Node Insert(Node node, string key, string value)
        {
            if (node == null)           //We've gone past the end (or the tree is empty).
                                        //Now we can add a leaf!
            {
                node = new Node();
                node.Key = key;
                node.Value = value;                
            }    
            else if (string.Compare(key, node.Key) == -1)    //This new node belongs somewhere left of where we are
            {
                node.Left = Insert(node.Left, key, value);
            }
            else                         //Otherwise, it's gottta be somewhere right of where we are
            {
                node.Right = Insert(node.Right, key, value);
            }
            return node;
        }

        private Node BalancedTree(Node node)
        {
            throw new NotImplementedException();
        }

        //Traversal in order is like magic.  Can you work out what's happening?
        public void Traverse()
        {
            Traverse(Root);
        }
        private void Traverse(Node node)
        {
            if (node == null) return;            
            Traverse(node.Left);
            WriteLine("- " + string.Format("{0,-14}", node.Key) + "(" + node.Value + ")");
            Traverse(node.Right);
        }

        public void Delete(string key)
        {
            Root = Delete(Root, key);
        }

        private Node Delete(Node node, string key)
        {
            if (node == null)
            {
                return node;
            }
            if (string.Compare(key, node.Key) == -1)
            {
                node.Left = Delete(node.Left, key);
            }
            else if (string.Compare(key, node.Key) == 1)
            {
                node.Right = Delete(node.Right, key);
            }
            else
            {
                //Case where node has zero or one child.  Just delete it.
                if (node.Right == null)
                {
                    return node.Left;
                }
                else if (node.Left == null)
                {
                    return node.Right;
                }

                //For a node with two children, you replace the node being deleted with 
                //the largest node in its smaller (left) subtree.

                node.Key = MaxLeftChildValue(node.Left);

                node.Left = Delete(node.Left, node.Key);                
            }
            
            return node;
        }

        private string MaxLeftChildValue(Node node)
        {
            string maxVal = node.Key;
            while (node.Right != null)
            {
                maxVal = node.Right.Key;
                node = node.Right;
            }

            return maxVal;
        }

        public string Find(string key)
        {
            return Find(Root, key);
        }

        private string Find(Node node, string key)
        {
            if (node == null) return null;

            if (key == node.Key) return node.Value;

            if (string.Compare(key, node.Key) == 1)
            {
                node = node.Right;
                return Find(node, key);                
            }
            else
            {
                node = node.Left;
                return Find(node, key);
            }
        }        
    }
}
