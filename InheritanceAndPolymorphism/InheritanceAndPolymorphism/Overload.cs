using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public class Overload
    {
        private string name = "Vova";

        /*
        public void Display()
        {
            Display2(ref name, ref name);
            Console.WriteLine(name);
            DisplayOverload(100, "Vova", "learns", "C#");
            DisplayOverload(200, "Hello");
            DisplayOverload(300);
        }
        */
        public static void Display(params object[] objectParamArray)
        {
            foreach (object obj in objectParamArray)
            {
                Console.Write(obj.GetType().FullName + "   ");
            }
        }



        public void Display2(ref string x, ref string y)
        {
            Console.WriteLine(name);
            x = "Vova 1";
            Console.WriteLine(name);
            y = "Vova 2";
            Console.WriteLine(name);
            name = "Vova 3";
            // изменять х и у = изменять name
        }


        //метод идентифицируется не только по имени, но и по его параметрам

        /*
        public void DisplayOverload(int a) {
            Console.WriteLine("DisplayOverload " + a);
        }

        public void DisplayOverload(string a)
        {
            Console.WriteLine("DisplayOverload " + a);
        }

        public void DisplayOverload(string a, int b)
        {
            Console.WriteLine("DisplayOverload " + a + b);
        }
        */
        public void DisplayOverload(int a, params string[] parameterArray)
        {
            foreach (string str in parameterArray)
                Console.WriteLine(str + " " + a);
        }
    }
}
