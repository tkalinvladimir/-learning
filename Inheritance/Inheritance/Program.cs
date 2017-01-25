using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
// base - для обращения к методам родительского класса
// такойже метод как в родительском - перегрузка
// наследование не работает от младшего к старшему
// Если класс С, будет унаследован от класса B, который, в свою очередь, будет унаследован от класса A, 
//то класс C унаследует члены как от класса B, так и от класса A. Это транзитивное свойство наследования.
// множественное наследование не поддерживается и циклически тоже
// констуркторы и деструкторы не наследуются

{
    class Program
    {
        static void Main(string[] args)
        {
            Class_A a = new Class_A();
            a.Display1();
            Console.ReadKey();
        }
    }


    class Class_A:Class_B
    {

        public void Display1()
        {
            Console.WriteLine("Class A - Display1");
            base.Display1();
        }

    }

    class Class_B
    {
        public int x = 100;

        public void Display1()
        {
            Console.WriteLine("Class B - Display1");
        }

        public void Display2()
        {
            Console.WriteLine("Class B - Display2");
        }
    }

}
