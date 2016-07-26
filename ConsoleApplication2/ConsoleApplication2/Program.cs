using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {

        static bool DoorIsOpen = false;
        static bool UserHasHands = false;
        static bool HaveKey = false;

        static void Main(string[] args)
        {


            Initialize();
            Game1();
            Console.Clear();
            Game2();
            Console.Clear();
            Game3();
            Console.Clear();
            Game4();
            Console.Clear();


        }

        private static int askInteger()
        {
            bool work = true;
            string result = "0";
            int simbs = 0;
            do
            {
                ConsoleKeyInfo ki = Console.ReadKey(true);
                if (ki.Key == ConsoleKey.Backspace && simbs != 0)
                {
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(" ");
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    // хренова функция. бекспейс не отрабатывает. надо из резалта отнимать символ стёртый справа
                    //result = ki.KeyChar.ToString();

                    simbs--;
                }
                else if (ki.Key == ConsoleKey.Enter)
                    work = false;
                else if (char.IsDigit(ki.KeyChar) || ki.KeyChar==',')
                {
                    simbs++;
                    Console.Write(ki.KeyChar.ToString());
                    result += ki.KeyChar.ToString();
                }
            }
            while (work);
            Console.WriteLine();
            return Convert.ToInt32(result.Replace(" ", ""));
        }

        private static void Game4()
        {
            bool Eternity = true;
            while (Eternity)
            {
                Console.WriteLine("Введите число \"150\":");
                int i = askInteger();
               
                    if (i == 150)
                    {
                        Console.WriteLine("Здорово! Вы ввели {0}!!!", i);
                        break;
                    }
                
            }
            Console.ReadLine();
        }

        private static void Game3()
        {
            bool Eternity = true;
            int count = 0;
            string Answer;

            Console.WriteLine("Я не закончусь пока ты не введешь \"exit\" или скажи \"say\"");
            while (Eternity)
            {
                Answer = Console.ReadLine();
                if (Answer.ToLower() == "exit")
                {
                    Console.WriteLine("Быстро ты! :(");
                    Eternity = false;
                }
                else if (Answer.ToLower() == "say")
                {
                    Console.WriteLine("Сколько раз повторить?");
                    count = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine("Я не повторяю по {0} раз", i);
                    }
                }
                else
                {
                    Console.WriteLine("Я не закончусь пока ты не введешь \"exit\" или скажи \"say\"");

                }
                


            }
                Console.ReadLine();

           
        }

        private static void Game2()
        {
            Console.WriteLine("Введите слово: ");
            string Answer = Console.ReadLine();
            Console.WriteLine("Сколько раз повторить?");
            int j = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < j; i++)
            {
                Console.WriteLine(Answer);
            }
            Console.ReadLine();
        }

        private static void Game1()
        {
            if (DoorIsOpen || (UserHasHands && HaveKey))
            {
                Console.WriteLine("Вы смогли пройти в следующую комнату.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Вы НЕ смогли пройти в следующую комнату.");
                Console.ReadLine();
            }
        }

        private static void Initialize()
        {

            char Answer;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Дверь открыта? y|n");
            Answer = Console.ReadKey().KeyChar;
            if (Answer == 'y')
            {
                DoorIsOpen = true;
            }
            else
            {
                DoorIsOpen = false;
            }

            Console.Clear();

            Console.WriteLine("У пользователя есть руки? y|n");
            Answer = Console.ReadKey().KeyChar;
            if (Answer == 'y')
            {
                UserHasHands = true;
            }
            else
            {
                UserHasHands = false;
            }

            Console.Clear();

            Console.WriteLine("Есть ключ? y|n");
            Answer = Console.ReadKey().KeyChar;
            if (Answer == 'y')
            {
                HaveKey = true;
            }
            else
            {
                HaveKey = false;
            }

            Console.Clear();

            Console.WriteLine("Let's go!");
            Console.ReadLine();
            Console.ResetColor();
            Console.Clear();


        }
    }
}
