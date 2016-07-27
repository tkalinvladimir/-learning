using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static bool PlayerIsDead;
        static string PlayerName;
        static int Health;
        static int Age;

        static void Main(string[] args)
        {
            Initialize();

            Console.Clear();

            while (Health>0) 
                {
                UserInterface();
                GetDamage();
                }

            UserInterface();

            Console.ReadLine();
        }


        private static void Initialize()
        {
            PlayerIsDead = false;
            Health = 100;
            PlayerName = AskUser_string("Введите ваше имя:");
            Age = Convert.ToInt32(AskUser_string("Введите ваш возраст:"));
            Console.WriteLine("Добро пожаловать, {0} - {1}", PlayerName, Age);
            Console.ReadLine();

        }

        private static string AskUser_string(string message_to_user)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message_to_user);
            return Console.ReadLine();
        }



        private static void GetDamage()
        {
            int Damage = 0;
            Damage = Convert.ToInt32(AskUser_string("Введите урон:"));
            Health -= Damage;
            Console.Clear();
        }

        private static void UserInterface()
        {
            if (Health<=0)
            {
                PlayerName = "Dead user";
                Health = 0;
                PlayerIsDead = true;
            }
            Console.WriteLine("*********************************************************************************");
            Console.WriteLine("Player: " + PlayerName + "," + Age + " Health: " + Health + " Player is dead: " + PlayerIsDead);
            Console.WriteLine("*********************************************************************************");
        }

    }
}
