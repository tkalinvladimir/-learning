using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstraction
    // абстрактные классы
    // нельзя создать с помощью new
    // унаследовать обычный класс от абстрактного - можно. и создать его с помощью new
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //ClassA a = new ClassA(); // - так не скомпилируется
            ClassB b = new ClassB();
            Console.ReadKey();
            */
            ClassA a = new ClassC();
            ClassB b = new ClassC();
            a.XXX();
            b.XXX();
            Console.ReadKey();
        }
    }
}
