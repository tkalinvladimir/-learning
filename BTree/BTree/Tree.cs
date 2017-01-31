using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTree
{
    class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int initial)
        {
            value = initial;
            left = null;
            right = null;
        }
    }

    class Tree
    {
        Node top;

        public Tree()
        {
            top = null;
        }

        public Tree(int initial)
        {
            top = new Node(initial);
        }

        public void Add(int value)
        {
            // non recursive add
            if (top == null) // empty tree
            {
                Node NewNode = new Node(value);
                top = NewNode;
                return;
            }

            Node currentnode = top; // start from top
            bool added = false;

            do
            {
                // traverse tree
                if (value < currentnode.value)
                {
                    // go left
                    if (currentnode.left == null)
                    {
                        // add the item
                        Node NewNode = new Node(value);
                        currentnode.left = NewNode;
                        added = true;
                    }
                    else
                    {
                        currentnode = currentnode.left;
                    }
                }
                if (value >= currentnode.value)
                {
                    // go right
                    if (currentnode.right == null)
                    {
                        // add the item
                        Node NewNode = new Node(value);
                        currentnode.right = NewNode;
                        added = true;
                    }
                    else
                    {
                        currentnode = currentnode.right;
                    }
                }
            }
            while (!added);

        }

        public void AddRc(int value)
        {
            // recursive add
            AddR(ref top, value);

        }

        private void AddR(ref Node N, int value)
        {
            // private recursive search for where to add the new node
            if (N == null)
            {
                // Node doesn't exist here
                Node NewNode = new Node(value);
                N = NewNode;
                return;
            }
            if (value < N.value)
            {
                AddR(ref N.left, value);
                return;
            }
            if (value >= N.value)
            {
                AddR(ref N.right, value);
                return;
            }
        }

       /* private Node Find(int n)
        {


            //return Node;
        }*/

        public void Print(Node N, ref string s)
        {
            if (N == null) { N = top; }
            if (N.left != null)
            {
                Print(N.left, ref s);
                s = s + N.value.ToString().PadLeft(3);
            }
            else
            {
                s = s + N.value.ToString().PadLeft(3);
            }
            if (N.right != null)
            {
                Print(N.right, ref s);
            }
        }

        // прямой обход (CLR - center, left, right)
        public void CLR(Node node, ref string s, bool detailed)
        {
            /*
             Аргументы метода:
             1. TreeNode node - текущий "элемент дерева" (ref  передача по ссылке)       
             2. ref string s - строка, в которой накапливается результат (ref - передача по ссылке)
            */
            if (node == null) { node = top; }
            if (node != null)
            {
                if (detailed)
                    s += "    получили значение " + node.value.ToString().PadLeft(3) + Environment.NewLine;
                else
                    s += node.value.ToString().PadLeft(3) + " "; // запомнить текущее значение
                if (detailed) s += "    обходим левое поддерево" + Environment.NewLine;
                if (node.left != null)
                {
                    CLR(node.left, ref s, detailed); // обойти левое поддерево
                }
                if (detailed) s += "    обходим правое поддерево" + Environment.NewLine;
                if (node.right != null)
                {
                    CLR(node.right, ref s, detailed); // обойти правое поддерево
                }
            }
            else if (detailed) s += "    значение отсутствует - null" + Environment.NewLine;
        }

        // обратный обход (LCR - left, center, right) 
        public void LCR(Node node, ref string s, bool detailed)
        {
            /*
             Аргументы метода:
             1. TreeNode node - текущий "элемент дерева" (ref - передача по ссылке)       
             2. ref string s - строка, в которой накапливается результат (ref - передача по ссылке)
            */

            if (node == null) { node = top; }
            if (node != null)
            {
                if (detailed) s += "    обходим левое поддерево" + Environment.NewLine;
                if (node.left != null)
                {
                    LCR(node.left, ref s, detailed); // обойти левое поддерево
                }
                if (detailed)
                    s += "    получили значение " + node.value.ToString().PadLeft(3) + Environment.NewLine;
                else
                    s += node.value.ToString().PadLeft(3) + " "; // запомнить текущее значение
                if (detailed) s += "    обходим правое поддерево" + Environment.NewLine;
                if (node.right != null)
                {
                    LCR(node.right, ref s, detailed); // обойти правое поддерево
                }
            }
            else if (detailed) s += "    значение отсутствует - null" + Environment.NewLine;
        }

        // концевой обход (RCL -right, center, left)
        public void RCL(Node node, ref string s, bool detailed)
        {
            /*
             Аргументы метода:
             1. TreeNode node - текущий "элемент дерева" (ref  передача по ссылке)       
             2. ref string s - строка, в которой накапливается результат (ref - передача по ссылке)
            */
            if (node == null) { node = top; }
            if (node != null)
            {
                if (detailed) s += "    обходим правое поддерево" + Environment.NewLine;
                if (node.right != null)
                {
                    RCL(node.right, ref s, detailed); // обойти правое поддерево
                }
                if (detailed)
                    s += "    получили значение " + node.value.ToString().PadLeft(3) + Environment.NewLine;
                else
                    s += node.value.ToString().PadLeft(3) + " "; // запомнить текущее значение
                if (detailed) s += "    обходим левое поддерево" + Environment.NewLine;
                if (node.left != null)
                {
                    RCL(node.left, ref s, detailed); // обойти левое поддерево
                }
            }
            else if (detailed) s += "    значение отсутствует - null" + Environment.NewLine;
        }
    }
}
