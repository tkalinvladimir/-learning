using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0:c}", 5.50); // "5,50 грн."
            Console.WriteLine("{0:c1}", 5.50); // "5,5 грн."
            Console.WriteLine("{0:e}", 5.50); // "5,500000е+000"
            Console.WriteLine("{0:d}", 32); // "32"
            Console.WriteLine("{0:d4}", 32); // "0032"
            Console.WriteLine("{0:p}", 0.55); // "55,00%" 


            Console.WriteLine("{0:0000.00}", 1024.32); // "1024,32"
            Console.WriteLine("{0:00000.000}", 1024.32); // "01024,320"
            Console.WriteLine("{0:####.###}", 1024.32); // "1024,32"
            Console.WriteLine("{0:####.#}", 1024.32); // "1024,3"
            Console.WriteLine("{0:#,###.##}", 1024.32); // "1 024,32"
            Console.WriteLine("{0:##%}", 0.32); // "32%"
            Console.WriteLine("{0:<####.###>;[####.###];ноль}", 1024.32); // "<1024,32>"
            Console.WriteLine("{0:<####.###>;[####.###];ноль}", -1024.32); // "[1024,32]"
            Console.WriteLine("{0:<####.###>;[####.###];ноль}", 0); // "ноль"

            Console.WriteLine("{0:d}", DateTime.Now); // "30.06.2014"
            Console.WriteLine("{0:D}", DateTime.Now); // "30 июня 2014 р."
            Console.WriteLine("{0:t}", DateTime.Now); // "2:57"
            Console.WriteLine("{0:T}", DateTime.Now); // "2:57:53"
            Console.WriteLine("{0:U}", DateTime.Now); // "29 июня 2014 р. 23:57:53"
            Console.WriteLine("{0:Y}", DateTime.Now); // "Июнь 2014 р." 

            Console.WriteLine("{0:y yy yyy yyyy}", DateTime.Now); // "14 14 2014 2014"
            Console.WriteLine("{0:d dd ddd dddd}", DateTime.Now); // "30 30 Пн понедельник"
            Console.WriteLine("{0:M MM MMM}", DateTime.Now); // "6 06 Июн"
            Console.WriteLine("{0:HH.mm.ss dd-MMM-yyyy}", DateTime.Now); // "03.21.22 30-Июн-2014"
            Console.WriteLine("{0:z zz zzz}", DateTime.Now); // "+3 +03 +03:00" 

            Console.ReadKey();
            Console.Clear();
            /*
             * Есть массив дат (с временем) и массив температур, и они соответствуют друг другу. 
             * Температуры в массиве имеют вид в формате: «26.3 27.1 30 24.7 25». Необходимо вывести информацию таким образом:

Июн 30 (Пн) 09:31 > 26,3 °C
Июн 30 (Пн) 10:31 > 27,1 °C
Июн 30 (Пн) 11:31 > 30,0 °C
             */

            List<DateTime> dates = new List<DateTime>();
            dates.Add(new DateTime(2016, 02, 21, 12, 20, 59));
            dates.Add(new DateTime(2016, 02, 21, 12, 30, 59));
            dates.Add(new DateTime(2016, 02, 21, 12, 49, 59));

            double[] temps = new double[] {-11,-10,-9 };

            Console.WriteLine("{0:MMM dd (ddd) h:mm => }" + temps[0] + " °C", dates[0]);
            Console.WriteLine("{0:MMM dd (ddd) h:mm => }" + temps[1] + " °C", dates[1]);
            Console.WriteLine("{0:MMM dd (ddd) h:mm => }" + temps[2] + " °C", dates[2]);
            Console.ReadKey();
        }
    }
}
