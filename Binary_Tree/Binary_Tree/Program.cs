using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var bTree = new BTree<int>();
            bTree.add(4);
            bTree.add(4);
            bTree.add(1);
            bTree.add(5);
            bTree.add(2);
            bTree.add(6);
            /*
                       4
                   /      \ 
                  1        4
                    \       \
                     2       5
                              \
                               6
             */
            bTree.print();
            bTree.remove(5);
            bTree.print();
            bTree.remove(4);
            bTree.print();
            bTree.remove(1);
            bTree.print();
            bTree.add(15);
            bTree.print();
            bTree.add(7);
            bTree.remove(2);
            bTree.add(8);

            bTree.print();
            /*
                       2
                   /      \ 
                  1        4
                            \
                             5
                              \
                               6
             */

            var tree2 = new BTree<int>();
            tree2.add(5, 1, 4, 7, 6, 2, 3, 8, 10);

            /**
             * 
             */

            tree2.remove(5);
            Console.ReadKey();
        }
    }
}
