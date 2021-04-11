using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    #region ****************************DYNAMIC DATA STRUCTURE****************************
    // Outer class
    class AvlTree
    {
        // Inner class
        class Node
        {
            public string data;
            public Node left;
            public Node right;

            public Node(string data)
            {
                this.data = data;
            }
        }

        Node RootNode;

        public AvlTree() { }

        #region To add a song.
        public void Add(string data)
        {
            data = data.Replace("\\\\", "\\");
            Node newNode = new Node(data);
            if (RootNode == null)
                RootNode = newNode;
            else
                RootNode = AddRecursive(RootNode, newNode);
        }

        private Node AddRecursive(Node currentNode, Node newNode)
        {
            if (currentNode == null)
            {
                currentNode = newNode;
                return currentNode;
            }
            else if (newNode.data.CompareTo(currentNode.data) < 0)
            {
                currentNode.left = AddRecursive(currentNode.left, newNode);
                currentNode = BalanceTree(currentNode);
            }
            else if (newNode.data.CompareTo(currentNode.data) > 0)
            {
                currentNode.right = AddRecursive(currentNode.right, newNode);
                currentNode = BalanceTree(currentNode);
            }
            return currentNode;
        }
        #endregion

        #region To balance the tree
        private Node BalanceTree(Node currentNode)
        {
            int bFactor = GetBalanceFactor(currentNode);
            if (bFactor > 1)
            {
                if (GetBalanceFactor(currentNode.left) > 0)
                    currentNode = RotateLL(currentNode);
                else
                    currentNode = RotateLR(currentNode);
            }
            else if (bFactor < -1)
            {
                if (GetBalanceFactor(currentNode.right) > 0)
                    currentNode = RotateRL(currentNode);
                else
                    currentNode = RotateRR(currentNode);
            }
            return currentNode;
        }

        private int GetMax(int l, int r)
        {
            return l > r ? l : r;
        }

        private int GetHeight(Node currentNode)
        {
            int height = 0;
            if (currentNode != null)
            {
                int l = GetHeight(currentNode.left);
                int r = GetHeight(currentNode.right);
                int m = GetMax(l, r);
                height = m + 1;
            }
            return height;
        }

        private int GetBalanceFactor(Node currentNode)
        {
            int l = GetHeight(currentNode.left);
            int r = GetHeight(currentNode.right);
            int bFactor = l - r;
            return bFactor;
        }

        private Node RotateRR(Node parentNode)
        {
            Node pivot = parentNode.right;
            parentNode.right = pivot.left;
            pivot.left = parentNode;
            return pivot;
        }

        private Node RotateLL(Node parentNode)
        {
            Node pivot = parentNode.left;
            parentNode.left = pivot.right;
            pivot.right = parentNode;
            return pivot;
        }

        private Node RotateLR(Node parentNode)
        {
            Node pivot = parentNode.left;
            parentNode.left = RotateRR(pivot);
            return RotateLL(parentNode);
        }

        private Node RotateRL(Node parentNode)
        {
            Node pivot = parentNode.right;
            parentNode.right = RotateLL(pivot);
            return RotateRR(parentNode);
        }

        #endregion

        public void DisplaySongs(ListBox lbSongs, TextBox tbInformation)
        {
            Display();

            void Display()
            {
                if (RootNode == null)
                {
                    tbInformation.Text = "Tree is empty";
                    return;
                }
                tbInformation.Text = "Root Node is: " + GetFileNameWithoutExtension(RootNode.data);
                DisplayInOrder(RootNode);
            }

            void DisplayInOrder(Node currentNode)
            {
                if (currentNode != null)
                {
                    DisplayInOrder(currentNode.left);
                    DisplayInOrder(currentNode.right);
                    string fileNameWithoutExtension = GetFileNameWithoutExtension(currentNode.data);
                    lbSongs.Items.Add(fileNameWithoutExtension);
                }
            }
        }

        #region ****************************SEARCH ALGORITHM****************************
        public string Find(string song)
        {
            if (RootNode != null)
            {
                if (FindRecursive(song, RootNode).data.Equals(song))
                    return song;
                    //Console.WriteLine("{0} was found!", song);
                    //lbSongs.SetSelected(0, true);
                else
                    return "not found";
                    //tbInformation.Text = song + " was not found";
            }
            else
            {
                return "empty";
                //tbInformation.Text = "The tree is empty";
                //Console.WriteLine("The tree is empty");
            }
        }

        private Node FindRecursive(string target, Node currentNode)
        {
            if (currentNode != null)
            {
                if (target.CompareTo(currentNode.data) < 0)
                {
                    if (target.Equals(currentNode.data))
                        return currentNode;
                    else
                        return FindRecursive(target, currentNode.left);
                }
                else
                {
                    if (target.Equals(currentNode.data))
                        return currentNode;
                    else
                        return FindRecursive(target, currentNode.right);
                }
            }
            return RootNode;
        }
        #endregion

        private string GetFileNameWithoutExtension(string fullPath)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullPath);
            return fileNameWithoutExtension;
        }
    }
    #endregion
}
