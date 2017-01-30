using AlgoirthmsComplexity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsComplexity
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4 };
            Methods m = new Methods();
            Console.WriteLine(m.GetCount(a));
            Console.WriteLine(m.GetSum(a));



            ClassLinkedList lst = new ClassLinkedList();
            lst.LoadItems();
            Console.WriteLine("The end.");

            
            LinkedListv2<int> lst2 = new LinkedListv2<int>();


            while (true)
            {
                int value = lst2.NextValue();
                if (value != 1)
                {
                    lst2.AddLast(value);
                }
                else
                {
                    break;
                }
            }

            lst2.ProcessItems();


            Console.WriteLine("The end.");

            
        }
    }
}
