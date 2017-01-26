using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polymorphism
// практические аспекты
//мы можем записать в переменную класса-родителя объект наследника, но не наоборот
 // virtuel - методы родительского класса можно переопределять
 // override - в дочернем, новая версия и будет использоваться он, а new - будет вызван родительского класса (по умолчанию так)

{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ClassA x = new ClassA();
            ClassB y = new ClassB();
            ClassA z = new ClassB();

            x.AAA(); x.BBB(); x.CCC();
            Console.WriteLine();
            y.AAA(); y.BBB(); y.CCC();
            Console.WriteLine();
            z.AAA(); z.BBB(); z.CCC();
            Console.WriteLine();
            Console.ReadKey();
            */

            /* 
             ClassA a = new ClassB();
             a.XXX();
             Console.WriteLine();
             ClassB b = new ClassC();
             b.XXX();
             Console.ReadKey();

             //В первом случае выполняется метод ClassB, который через base вызывает метод из ClassA. Во втором — XXX() из ClassC, который обращается к ClassB, а тот, в свою очередь, к ClassA.
             */


            ClassA a = new ClassB();
            a.ZZZ();
            Console.ReadKey();
        }
    }
}
