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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите имя:");
            PlayerName = Console.ReadLine();
            Console.WriteLine("Введите возраст:");
            Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Добро пожаловать, " + PlayerName + " " + Age);
            Console.ReadLine();

        }

        private static void GetDamage()
        {
            int Damage = 0;
            Console.WriteLine("Введите урон: ");
            Damage = Convert.ToInt32(Console.ReadLine());
            Health = Health - Damage;
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
