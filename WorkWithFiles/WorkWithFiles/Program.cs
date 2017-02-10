using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WorkWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             * Задача 1. Создайте файл numbers.txt и запишите в него натуральные числа от 1 до 500 через запятую.

Задача 2. Дан массив строк: "red", "green", "black", "white", "blue". Запишите в файл элементы массива построчно (каждый элемент в новой строке).

Задача 3. Возьмите любой текстовый файл, и найдите в нем размер самой длинной строки.
             */

            if (File.Exists("E:\\numbers.txt"))
            {
                File.Delete("E:\\numbers.txt");
            }
            for (int i = 1; i < 501; i++)
            {
                File.AppendAllText("E:\\numbers.txt", i + ",");
            }


            if (File.Exists("E:\\colors.txt"))
            {
                File.Delete("E:\\colors.txt");
            }
            string s = "red,green5545454,black,white,blue";
            string[] sArr = s.Split(',');

            foreach (string inSArr in sArr)
            {
                File.AppendAllText("E:\\colors.txt", inSArr + "\r\n");
            }


            if (File.Exists("E:\\colors.txt"))
            {
                FileStream fs = new FileStream("E:\\colors.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                int maxLength = 0;
                string s1 = "";
                string findStr = "";
                while (!sr.EndOfStream)
                {
                    s1 = sr.ReadLine();
                    if (s1.Length > maxLength)
                    {
                        maxLength = s1.Length;
                        findStr = s1;
                    }
                }
                Console.WriteLine("самая длинная строка - " + findStr + ", ее длина - " + maxLength);
                Console.ReadKey();
            }

        }
    }
}
