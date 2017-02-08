using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // if
            Console.Write("Число 1: ");
            int a = int.Parse(Console.ReadLine().ToString());

            Console.Write("Число 2: ");
            int b = int.Parse(Console.ReadLine().ToString());


            if (a > b) Console.WriteLine("a > b");
            if (a < b) Console.WriteLine("a < b");
            if (a == b) Console.WriteLine("a = b");

            if (a % 3 == 0 && a % 7 == 0) Console.WriteLine("Число а кратно 3 и 7");
            if (b % 3 == 0 && b % 7 == 0) Console.WriteLine("Число b кратно 3 и 7");

            // cycle
            /*
            Задача 1.Вывести на экран 20 элементов последовательности 1, 4, 7, 10, 13…
            Задача 2.Напишите программу, которая будет «спрашивать» правильный пароль, до тех пор, пока он не будет введен. Правильный пароль пусть будет «root».
            Задача 3.Дано два массива одинаковой длины (по 10 элементов). Создайте третий массив, который будет отображать сумму первых двух массивов.Первый элемент третьего массива равен сумме первых элементов двух первых массивов и так далее.
            */

            
            int j = 1;
            for (int i = 0; i < 20; i++)
            {
                Console.Write(i + j + " ");
                j += 2;
            }


            while (true)
            {
                if (Console.ReadLine().ToString() == "root")
                { break; }
                else
                { Console.WriteLine("Enter correct password."); }
            }


            int[] a1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] a2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] a3 = new int[10];
            for (int i = 0; i < 10; i++)
            {
                a3[i] = a1[i] + a2[i];
            }

            foreach (int inti in a3)
            {
                Console.Write(inti+" ");
            }


            string s = "Arsenal,Milan,Real Madrid,Barcelona";
            string[] array = s.Split(','); // элементы массива – "Arsenal", "Milan", "Real Madrid", "Barcelona" 
            

            // try catch
            /*
             * Есть массив целых чисел размером 10. С клавиатуры вводится два числа - порядковые номера элементов массива, которые необходимо суммировать. Например, если ввели 3 и 5 - суммируются 3-й и 5-й элементы. Нужно предусмотреть случаи, когда были введены не числа, и когда одно из чисел, или оба больше размера массива.
             */
            int[] a5 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            try
            {
                Console.WriteLine("Введите два числа:");
                int num1 = Convert.ToInt32(Console.ReadLine().ToString());
                int num2 = Convert.ToInt32(Console.ReadLine().ToString());
                int res = a5[num1] + a5[num2];
                Console.WriteLine();
                Console.WriteLine("" + a5[num1] + " + " + a5[num2] + " = " + res);
            }
            catch (FormatException)
            {
                Console.WriteLine("Введите числа");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Массив так-то поменьше будет");
            }



            Console.ReadKey();

        }
    }
}
