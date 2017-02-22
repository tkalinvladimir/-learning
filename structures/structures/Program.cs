using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace structures
{
    /*
    Создайте программу, которая будет находить окружность (структура) у которой радиус максимально близкий к среднему значению радиусов окружностей из списка.
    */

    class Program
    {
        static void Main(string[] args)
        {

            double[] radius = new double[] { 2.3, 2.1, 2,7, 2.9, 1.8 };
            double averageBYlinq = (from ord in radius select ord).Average();
            Console.WriteLine("The average is " + averageBYlinq);
            Circle c;
            c.calcradiuses(radius);
            Console.ReadKey();

        }
     }

    struct Circle
    {
        public void calcradiuses(double[] radiuses)
        {
            double averageRad = radiuses.Average();
            double nearest = 0;
            double find = radiuses.Max();

            foreach (double rad in radiuses)
            {
                if (Math.Abs(averageRad - rad) < find)
                {
                    nearest = rad;
                    find = Math.Abs(averageRad - nearest);
                }
            }
            // пробегаем массив и находим элемент с минимальным значением |ai-ac|, где ai - i-й элемент массива, ac - среднее значение. 

            Console.WriteLine("The nearest member of the array to the average array is " + nearest);
            double circumference = nearest * 2 * Math.PI;
            Console.WriteLine("The circumference (C=2*R*Pi) is " + circumference);

        }

    }
}
