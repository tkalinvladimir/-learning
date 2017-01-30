using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsComplexity
{
    class ClassLinkedList
    {
        public void LoadItems()
        {
            LinkedList<int> list = new LinkedList<int>();
            while (true)
            {
                int value = NextValue();
                if (value != 1)
                {
                    list.AddLast(value);
                }
                else
                {
                    break;
                }
            }

            ProcessItems(list);
        }

        static void ProcessItems(LinkedList<int> list)
        {
            foreach (int i in list)
            {
                Console.Write(i + " ");
            }
        }

        static int NextValue()
        {
            int i = Convert.ToInt32(Console.ReadLine());
            return i;
        }

    }

    //********************************************
    //********************************************
    //********************************************
    //********************************************


}
