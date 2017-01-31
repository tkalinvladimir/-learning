using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree
{
    public class BTree<T> where T : IComparable<T>
    {
        private Node<T> root;

        public void add(params T[] datas)
        {
            foreach (T data in datas)
            {
                add(data);
            }
        }

        public void print()
        {
            Console.WriteLine("----/ START /---");
            print(root);
            Console.WriteLine("\n----/ END /---");
        }

        private void print(Node<T> node)
        {
            if (node.left != null) print(node.left);
            Console.Write($"{node.data} ");
            if (node.right != null) print(node.right);
        }

        public void add(T data) =>
         root = root == null ? new Node<T> { data = data } : add(data, root);

        private Node<T> findMedian(Node<T> node) =>
        (node.left == null) ? findMedianRec(node?.right) : findMedianRec(node?.left);

        private Node<T> findMedianRec(Node<T> node) =>
        node?.left == null ? (node?.right == null ? node : findMedianRec(node.right)) : findMedianRec(node.left);

        private Node<T> add(T data, Node<T> root)
        {
            if (root == null) return new Node<T> { data = data };
            else if (root.data.CompareTo(data) <= 0) root.right = add(data, root.right);
            else if (root.data.CompareTo(data) > 0) root.left = add(data, root.left);
            return root;
        }

        public Node<T> remove(T data)
        {

            /* Three case for removing an item from a tree
             * 1. the root 
             *  - find the median node
             * 2. a leaf node with childrens
             *  - find the median node in it's subtree            
             * 3. a leaf node with no children
             *  - remove it 
             */
            if (root.data.CompareTo(data) == 0)
            {
                // we need to remove root
                Node<T> newRootNode = findMedian(root);
                remove(newRootNode.data);
                root.data = newRootNode.data;
                return root;
            }

            return remove(data, root);
        }

        private Node<T> remove(T data, Node<T> node)
        {
            if (node.data.CompareTo(data) == 0)
            {
                if (node.left == null && node.right == null)
                    return null;
                else
                {
                    Node<T> newTree = findMedian(node);
                    remove(newTree.data, node);
                    node.data = newTree.data;
                    return node;
                }

            }
            else if (node.data.CompareTo(data) < 0) // go right
            {
                node.right = remove(data, node.right);
            }
            else if (node.data.CompareTo(data) > 0) // go left 
            {
                node.left = remove(data, node.left);
            }
            return node;
        }
        private Node<T> swap(ref Node<T> src, ref Node<T> dest)
        {
            T temp = dest.data;
            dest.data = src.data;
            src.data = temp;
            return dest;
        }

    }
}
