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
            bool exit_menu = false;
            while (!exit_menu)
            {
                Console.Clear();
                Console.ResetColor();
				// menu 123
				// 222
				// menu 321
                Console.WriteLine("Тут 5 игр. Для выбора игры введите цифры от 1 до 5.\nДля выхода нажмите 0");
                string answer = Convert.ToString(askInteger(""));
                switch (answer)
                {
                    case "0":
                        exit_menu = true;
                        break;
                    case "1":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Initialize();
                        Game1();
                        break;
                    case "2":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Game2();
                        break;
                    case "3":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Game3();
                        break;
                    case "4":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Game4();
                        break;
                    case "5":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Game5();
                        break;
                } 
            }
            Console.WriteLine("Good bye! :(");
            Console.ReadLine();
        }

        private static void Game5()
        {
            int x = 0, y = 0;
            ConsoleKeyInfo k;
            Console.CursorVisible = false;
            while (true)
            {
                k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.RightArrow)
                {
                    x += 1;
                    if (x > Console.WindowWidth - 1)
                    {
                        x = Console.WindowWidth - 1;
                    }
                }
                if (k.Key == ConsoleKey.LeftArrow)
                {
                    x -= 1;
                    if (x < 0)
                    {
                        x = 0;
                    }
                }
                if (k.Key == ConsoleKey.UpArrow)
                {
                    y -= 1;
                    if (y < 0)
                    {
                        y = 0;
                    }
                }
                if (k.Key == ConsoleKey.DownArrow)
                {
                    y += 1;
                    if (y > Console.WindowHeight - 1)
                    {
                        y = Console.WindowHeight - 1;
                    }
                }
                if (k.Key == ConsoleKey.Z)
                {
                    break;
                }
                Console.Clear();
                Console.SetCursorPosition(x, y);
                Console.Write("$");
            }
        }

        private static int askInteger(string message)
        {
            Console.WriteLine(message);
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
                    result = result.Remove(result.Length-1); // но можно и через саб стрингс
                    simbs--;
                }
                else if (ki.Key == ConsoleKey.Enter)
                    work = false;
                else if (char.IsDigit(ki.KeyChar))
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
                int i = askInteger("Введите число \"150\":");
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
                    count = askInteger("Сколько раз повторить ?");

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
            string Answer = AskUser_string("Введите слово: ");
            int j = Convert.ToInt32(AskUser_string("Сколько раз повторить?"));
            for (int i = 0; i < j; i++)
            {
                Console.WriteLine(Answer);
            }
            Console.ReadLine();
        }

        private static void Game1()
        {
            if (DoorIsOpen || UserHasHands && HaveKey)
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

        private static char AskUser_char(string message_to_user)
        {
            Console.WriteLine(message_to_user);
            return Console.ReadKey().KeyChar;
        }

        private static string AskUser_string(string message_to_user)
        {
            Console.WriteLine(message_to_user);
            return Console.ReadLine();
        }

        private static void Initialize()
        {
            char Answer;
            Answer = AskUser_char("Дверь открыта? y|n");
            if (Answer == 'y')
            {
                DoorIsOpen = true;
            }
            else
            {
                DoorIsOpen = false;
            }

            Console.Clear();

            Answer = AskUser_char("У пользователя есть руки? y|n");
            if (Answer == 'y')
            {
                UserHasHands = true;
            }
            else
            {
                UserHasHands = false;
            }

            Console.Clear();

            Answer = AskUser_char("Есть ключ? y|n");
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
        }
    }
}
