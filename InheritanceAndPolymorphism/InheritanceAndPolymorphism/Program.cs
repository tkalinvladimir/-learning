using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
// наследование и полимофизм
//метод идентифицируется не только по имени, но и по его параметрам
// ref - передача и получение по реф - изменение по ссылке
// передать n параметров - ключевое слово params (последним аргументом)
// Запомните: массив параметров должен быть одномерным.
// C# рассматривает методы с массивом параметров последними

{
    class Program
    {
        static void Main(string[] args)
        {
            //Overload overload = new Overload();
            /*    overload.DisplayOverload(100);
                overload.DisplayOverload("method overloading");
                overload.DisplayOverload("method overloading", 100);
                */

            object[] objArray = { 100, "Vova", 200.300} ; // массив
            object obj = objArray; // массив как объект

            Overload.Display(objArray);
            Console.WriteLine();
            Overload.Display((object)objArray); // массив приведенный к объекту
            Console.WriteLine();
            Overload.Display(obj);
            Console.WriteLine();
            Overload.Display((object[])obj); // массив как объект приведенный к массиву 

            Console.ReadKey();

        }
    }
}
