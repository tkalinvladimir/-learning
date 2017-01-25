using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recursion_factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            a = fact(a);
            Console.WriteLine(a);
            Console.ReadKey();
        }

        public static int fact(int n)
        {
            return (n == 0) ? 1 : n * fact(n - 1);
        }
    }
}
