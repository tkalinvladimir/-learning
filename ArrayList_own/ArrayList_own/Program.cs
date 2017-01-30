using System;
using System.Collections;
using System.Collections;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList_own
{
    class Program
    {
        static void Main(string[] args)
        {
           

            var lst = new LinkedList<string>();
            lst.AddFirst("123");
            lst.AddFirst("456");

            ArrayList list = new ArrayList();  // using collections 
            list.Add("666");
            list.AddRange(lst);
            list.Add(new string[] { "Hello", "world" });

            testmethods(list);
            Console.ReadKey();
            list.Reverse();
            testmethods(list);
            Console.ReadKey();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }



        }

        private static void testmethods(ArrayList list)
        {
            foreach (object o in list)
            {
                Console.WriteLine(o + " " + o.GetType());
                if (o is string[])
                {
                    foreach (string o2 in (string[])o)
                    {
                        Console.WriteLine(o2 + " " + o2.GetType());
                    }
                }
            }
        }
    }
}
