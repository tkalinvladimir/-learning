using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lambda
{
    class Program
    {
        delegate int Z(int a, int b); // это обяз
        static void Main(string[] args)
        {
            int x = 5;
            int y = 10;
            Z res = (a,b) =>  a * b; // объявляем
            Console.WriteLine(res(x,y)); // выодим вызывая
            Console.ReadKey();
        }
    }
}
