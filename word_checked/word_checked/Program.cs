using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace word_checked
{
    class Program
    {
        static void Main(string[] args)

        {
            try
            {
                int a = 33;
                int b = 600;
                byte c = checked((byte)(a + b));
                Console.WriteLine(c);
            }
            catch (OverflowException ex)
            {
                Console.Beep(247,1600);
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
