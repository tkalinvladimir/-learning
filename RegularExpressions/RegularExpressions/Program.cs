using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string data1 = "Петр, Андрей, Николай";
            string data2 = "Петр, Андрей, Александр";
            Regex myReg = new Regex("Николай"); // создание регулярного выражения
            Console.WriteLine(myReg.IsMatch(data1)); // True
            Console.WriteLine(myReg.IsMatch(data2)); // False
            Console.ReadKey();

            Match match = myReg.Match(data1);
            Console.WriteLine(match.Value); // "Николай"
            Console.WriteLine(match.Index); // 14
            Console.ReadKey();

            data1 = "Петр, Николай, Андрей, Николай";
            MatchCollection matches = myReg.Matches(data1);
            Console.WriteLine(matches.Count); // 2
            foreach (Match m in matches)
                Console.WriteLine(m.Value+" "+m.Index); //вывод всех подстрок "Николай"
            Console.ReadKey();

            data1 = "Петр, Николай, Андрей, Николай";
            data1 = myReg.Replace(data1, "Максим");
            Console.WriteLine(data1); //"Петр, Максим, Андрей, Максим"
            Console.ReadKey();

            data1 = "Петр,Николай,Андрей,Николай";
            myReg = new Regex(",");
            string[] names = myReg.Split(data1); // массив имен
            Console.ReadKey();
            */

            //то есть \d\d\d будет значит что там три цыфири?
            //[‎20.‎02.‎2017 16:03] Желудков Евгений Сергеевич:   да но проще написать \d{3}


            Regex myReg = new Regex(@"[A-Za-z]+[\.A-Za-z0-9_-]*[A-Za-z0-9]+@[A-Za-z0-9_]+\.[A-Za-z]+");
            Console.WriteLine(myReg.IsMatch("email@email.com")); // True
            Console.WriteLine(myReg.IsMatch("email@email")); // False
            Console.WriteLine(myReg.IsMatch("@email.com")); // False
            Console.WriteLine(myReg.IsMatch("email123@email.com")); // True
            Console.WriteLine(myReg.IsMatch("123email@email.com")); // True
            Console.WriteLine(myReg.IsMatch("email@email123.com")); // True
            Console.WriteLine(myReg.IsMatch("email@123email.com")); // True
            Console.WriteLine(myReg.IsMatch("em123ail@email.com")); // True
            Console.WriteLine(myReg.IsMatch("email@em123ail.com")); // True
            Console.WriteLine(myReg.IsMatch("email@email.co123m")); // True
            Console.ReadKey();
            Console.WriteLine("******************************"); // True
            Console.Clear();
            /*
             1. Создайте программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2-х до 10-ти символов, 
             содержащая только буквы и цифры, и при этом цифра не может быть первой. 
             */

            Regex login = new Regex(@"[A-Za-z][A-Za-z0-9]{1,9}$");
            Console.WriteLine(login.IsMatch("123abc"));
            Console.WriteLine(login.IsMatch("abc123"));
            Console.WriteLine(login.IsMatch("a1b2c3"));
            Console.WriteLine(login.IsMatch("abc"));
            Console.WriteLine(login.IsMatch("a"));
            Console.WriteLine(login.IsMatch("abcaaaaaaaaaaaaaa234aaaaaaaa"));
            string s = "abcaaaaaaaaaaaaaa234aaaaaaaa";
            Console.WriteLine(s.Length < 10);

            Console.ReadKey();
            Console.Clear();
            /*
              2. Создайте фильтр мата. Метод будет принимать исходную строку, и возвращать результат, где нехорошие слова будут заменены на «цензура». 
              Обработайте хотя бы одно такое слово, только предусмотрите множество его форм.
              */
            string[] badwords = new string[] { "хуй", "хуйня", "хуёвый"};
            string input = Console.ReadLine();
            string output = input;
            foreach (string badword in badwords)
            {
                Regex replace = new Regex("[А-Яа-я0-9_]*"+badword+"[А-Яа-я0-9_]*", RegexOptions.IgnoreCase );
                output = replace.Replace(output, "\"цензура\"");
            }
            Console.WriteLine(output);
            Console.ReadKey();

        }
    }
}
