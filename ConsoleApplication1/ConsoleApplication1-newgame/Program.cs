using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniRPG
{
    class Program
    {
        static int HeroHP = 100;
        static string HeroName;
        static int Money = 0;
        static int Armor = 0;
        static string ArmorName = "Нет брони";
        static int Gun = 0;
        static string GunName = "Нет оружия";
        static bool theHeroIsAlive = true;
        static void Main(string[] args)
        {
            Console.WriteLine("Меню");
            Console.WriteLine("1-Начать игру");
            Console.WriteLine("2-Выход");
            Console.WriteLine("P.S. В игре пока нет брони, но вы держитесь");

            int a = Convert.ToInt32(Console.ReadLine());
            if (a == 1)
            {
                Console.Clear();
                Game();
            }
            Console.ReadLine();
        }
        static void Game()
        {
            StartGame();
            Console.Clear();
            int map = Convert.ToInt32(MapGenerator());
            for (int i = 0; i < 8; i++)
            {
                switch (map % 10)
                {
                    case 1:
                        FirstEnemy();
                        break;
                    case 2:
                        SecondEnemy();
                        break;
                    case 3:
                        dealer();
                        break;

                    case 4:
                        forest();
                        break;

                }
                map = map / 10;
                if (theHeroIsAlive == false)
                {
                    Console.Clear();
                    Console.WriteLine("Вы проиграли");
                    break;

                }
            }
            if (theHeroIsAlive == true)
            {
                EndGame();
            }
            Console.ReadLine();
        }
        static void StartGame()
        {
            string Name = "Незнакомец:";
            Console.WriteLine(Name + " Короче, Меченый, я тебя спас и в благородство играть не буду.");
            Console.WriteLine(Name + " Ой, это не из этой игры.");
            Console.WriteLine(Name + " Как ты уже догадался меня зовут Сидорович.");
            Name = "Сидорович:";
            Console.WriteLine(Name + " А ты у нас Меч..., нет ты не Меченый, так как тебя зовут?");
            HeroName = Console.ReadLine();
            Console.WriteLine(HeroName + ": " + HeroName);
            Console.WriteLine(Name + " Короче, " + HeroName + ", я тебя спас и в благородство играть не буду.");
            Console.WriteLine(Name + " Отнеси этот свёрток моему другу в город, и мы в расчете");
            Console.WriteLine(Name + " Город не далеко, километров 8 на север");
            Console.WriteLine(Name + " У нас тут места дикие, так что держи винтовку");
            Console.WriteLine(Name + " И ещё, у тебя в кaрмане были деньги, вот они");
            Console.WriteLine("Получено: <Сверток>, <Винтовка>, <1000₽>");
            Money += 1000;
            Gun = 10;
            GunName = "Винтовка";
            Console.ReadLine();
        }
        static void EndGame()
        {
            Console.Clear();
            GameInterface();

            Console.WriteLine("Ты прибыли в город");
            Console.WriteLine("Взглянув на часы, ты увидели время 14:35");
            Console.WriteLine("Но улицы были пусты");
            Console.WriteLine("Ты 2 часа шли к точке, где вас должен был ждать друг Сидоровича");
            Console.WriteLine("За это время, ты не увидел ни одного человека");
            Console.WriteLine("Добравшись до точки, вы оглянулись");
            Console.WriteLine("Со спины к вам подходил человек");
            Console.WriteLine("Он протянул вам руку, вы пожали её");
            Console.WriteLine("Анатолий: Меня зовут Анатолий, а вас как?");
            Console.WriteLine(HeroName + ": " + HeroName);
            Console.WriteLine("Анатолий: Очень приятно, но я вынужден попросить у вас прощения");
            Console.WriteLine(HeroName + ": За что?");
            Console.WriteLine("Анатолий: За это");
            Console.WriteLine("Мгновенно из-за спины Анатолий достал пистолет и не недолго думая выстрелил в вас");
            Console.WriteLine("Но промазал");

            Console.ReadLine();
            Console.Clear();
            GameInterface();

            if (CombatSystem("Анатолий", 100, 5, 0) == false)
            {
                Console.WriteLine("Вы убили Анатолия, но у него был пояс шахида");
                Console.WriteLine("После его смерти произошел взрыв, вы погибли");
            }
            else
            {
                Console.WriteLine("Анатолий убил вас");
                Console.WriteLine("Но вы держитесь");
                Console.WriteLine("Всего хорошего");
            }


        }
        static void GameInterface()
        {
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.Write("■ ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(HeroName.PadLeft(17).PadRight(25));
            Console.ResetColor();
            Console.WriteLine(" ■ ");

            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.Write("■ ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("   " + Convert.ToString(HeroHP).PadLeft(3) + "%" + "    ");
            Console.ResetColor();
            Console.Write(" ■ ");

            Console.ForegroundColor = ConsoleColor.Red;

            if (HeroHP < 0)
            {
                HeroHP = 0;
            }
            string xpline = XpLine(HeroHP / 10);
            xpline = xpline.PadRight(11);
            Console.Write(xpline);
            Console.ResetColor();
            Console.WriteLine(" ■");

            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("■ " + GunName.PadRight(19) + " ■ " + Convert.ToString(Gun).PadRight(3) + " ■");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");

            Console.WriteLine("■ " + ArmorName.PadRight(19) + " ■ " + Convert.ToString(Armor).PadRight(3) + " ■");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");

            Console.WriteLine("■ " + "Деньги".PadRight(10) + " ■ " + Convert.ToString(Money).PadRight(12) + " ■");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine();
        }
        static string XpLine(int length)
        {
            string t = "";
            for (int i = 0; i <= length; i++)
            {
                t = t + "x";
            }
            return t;
        }
        static string MapGenerator()
        {
            string t = "";
            Random rand = new Random();
            for (int i = 0; i < 8; i++)
            {

                t += Convert.ToString(rand.Next(1, 5));
            }
            return t;
        }
        static bool CombatSystem(string Name, int HP, int Damage, int WinMoney)
        {
            EnemyInterface(Name, HP);
            Random rand = new Random();

            string Selection;
            while ((HeroHP > 0) && (HP > 0))
            {
                if (rand.Next(2) == 0)
                {
                    Console.WriteLine(HeroName + " ходит");
                    Console.WriteLine("1-" + GunName + ": Выстрел");
                    Console.WriteLine("2-" + HeroName + ": Подлечиться");

                    Selection = Console.ReadLine();
                    if (Selection == "1")
                    {
                        Console.WriteLine(HeroName + ": Стреляет в " + Name + " и наносит " + Gun + " урона");
                        HP -= Gun;
                    }
                    else
                    {
                        Console.WriteLine(HeroName + ": Лечится и восстанавливает 5% HP");
                        HeroHP = HeroHP + 5;
                        if (HeroHP > 100)
                        {
                            HeroHP = 100;
                        }
                    }
                }
                else
                {
                    Console.WriteLine(Name + " ходит");
                    Console.WriteLine(Name + ": Наносит " + Damage + " урона");
                    HeroHP -= Damage;
                }
                Console.ReadLine();
                Console.Clear();
                GameInterface();
                if (Name == "Собака")
                {
                    PicDog();
                }
                if (Name == "Псевдо-овца")
                {
                    PicSheep();
                }
                EnemyInterface(Name, HP);

            }
            if (HP <= 0)
            {
                Console.WriteLine(Name + " умирает от выстрела");
                Console.WriteLine("Вы получили " + WinMoney + "Р");
                Money += WinMoney;
                Console.ReadLine();
                Console.Clear();
                return false;
            }
            else
            {
                Console.WriteLine(HeroName + " умирает от укуса");
                theHeroIsAlive = false;
                return true;
            }





        }
        static void EnemyInterface(string Name, int HP)
        {
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Name.PadLeft(10).PadRight(15));
            Console.ResetColor();
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Convert.ToString(HP).PadLeft(3).PadRight(11));
            Console.ResetColor();
            Console.WriteLine("■");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        }
        static void FirstEnemy()
        {
            Console.Clear();
            GameInterface();
            Console.WriteLine("По дороге в город ты встечаешь собаку");
            Console.WriteLine("Она бежит к тебе злобно рыча");
            PicDog();

            string Name = "Собака";
            int HP = 30;
            int Damage = 3;
            bool IsEnemyLive = true;
            int MoneyEnemy = 300;
            IsEnemyLive = CombatSystem(Name, HP, Damage, MoneyEnemy);

        }
        static void PicDog()
        {
            Console.WriteLine("▀██────██▀───────────█▀▀");
            Console.WriteLine("──█▀█▀██────────────█───");
            Console.WriteLine("──█▄█▄███████████████───");
            Console.WriteLine("───███──▐████████████───");
            Console.WriteLine("────▀───▄██─▄██───▄██───");
            Console.WriteLine("════════════════════════");

        }
        static void SecondEnemy()
        {
            Console.Clear();
            GameInterface();
            Console.WriteLine("По дороге в город в далеке ты видишь овцу");
            PicSheep();
            Console.WriteLine("Убить(1) или пощадить(2)?");
            string Select = Console.ReadLine();

            string Name = "Псевдо-овца";
            int HP = 15;
            int Damage = 75;
            int MoneyEnemy = 20000;
            if (Select == "1")
            {
                Console.WriteLine("Приближаясь к овечке, ты замечаешь у животного клыки");
                Console.WriteLine(HeroName + ": Это не овца");
                Console.WriteLine("'Овца' замечает вас. Бежать уже поздно");
                bool IsEnemyLive = true;
                IsEnemyLive = CombatSystem(Name, HP, Damage, MoneyEnemy);

            }
            else
            {
                Console.WriteLine("Вы проходите мимо");
                Console.ReadLine();
                Console.Clear();
                GameInterface();
            }

        }
        static void PicSheep()
        {
            Console.WriteLine("──▄███▄▀▀▄▀▀▄▀▀▄▄────");
            Console.WriteLine("███▄█▐█░░░░░░░░░░█▄──");
            Console.WriteLine("▀▀▀█▀░▀░░░░░░░░░░▐─▀─");
            Console.WriteLine("────▀▄▄▀▄▄▀▄▄▄▀▄▄▌───");
            Console.WriteLine("────▄█─▄█───▄█─▄█────");
        }
        static void dealer()
        {
            Console.Clear();
            GameInterface();
            Console.WriteLine("Вы видите здание с надписью <Торговец>");
            Console.WriteLine("Вы решили зайти");
            PicDealer();
            Console.ReadLine();
            Console.Clear();
            GameInterface();
            Console.WriteLine("Вы встречаете торговца");
            Console.WriteLine("(-_-)");
            Console.WriteLine("Торговец: Куда путь держишь?");
            Console.WriteLine(HeroName + ": В город");
            Console.WriteLine("Торговец: Оружие купить хочешь?");
            Console.WriteLine("Торговец: Выбирай любое ");
            Console.WriteLine("1-M4A4   33 УР  3100Р");
            Console.WriteLine("2-P90  26 УР  2350Р");
            Console.WriteLine("3-AWP  115 УР 4750Р");
            Console.WriteLine("4-Танк Т-14  50000 УР  200000Р");
            Console.WriteLine("5-Денег нет");
            Console.WriteLine("Торговец: Сначала товар, потом деньги");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    if (Money >= 3100)
                    {
                        Gun = 33;
                        GunName = "M4A4";
                        Money -= 3100;
                        Console.WriteLine("Торговец: С вами приятно иметь дело");
                    }
                    else
                    {
                        Console.WriteLine("Торговец: Без денег не продам");

                    }
                    break;
                case 2:
                    if (Money >= 2350)
                    {
                        Gun = 26;
                        GunName = "P90";
                        Money -= 2350;
                        Console.WriteLine("Торговец: С вами приятно иметь дело");
                    }
                    else
                    {
                        Console.WriteLine("Торговец: Без денег не продам");

                    }
                    break;
                case 3:
                    if (Money >= 4750)
                    {
                        Gun = 115;
                        GunName = "AWP";
                        Money -= 4750;
                        Console.WriteLine("Торговец: С вами приятно иметь дело");
                    }
                    else
                    {
                        Console.WriteLine("Торговец: Без денег не продам");

                    }
                    break;
                case 4:
                    if (Money >= 200000)
                    {
                        Gun = 50000;
                        GunName = "Танк Т-14";
                        Money -= 200000;
                        Console.WriteLine("Торговец: С вами приятно иметь дело");
                    }
                    else
                    {
                        Console.WriteLine("Торговец: Без денег не продам");

                    }
                    break;
                case 5:
                    Console.WriteLine("Торговец: Не задерживай очередь");
                    break;

            }
            Console.ReadLine();
            Console.Clear();
            GameInterface();
            Console.WriteLine("Вы попращались с торговцем и продолжили свой путь");
            Console.ReadLine();
            Console.Clear();
        }
        static void PicDealer()
        {
            Console.WriteLine("──█──────────────");
            Console.WriteLine("▄███▄ ███████────");
            Console.WriteLine("█┼███▐┼██┼██┼▌█▄█");
            Console.WriteLine("███┼█▐███████▌███");
            Console.WriteLine("█┼███▐┼█████┼▌█┼█");
            Console.WriteLine("███┼█▐███┼███▌███");
            Console.WriteLine("█████▐███████▌█▀█");
            Console.WriteLine("█─███▐███─███▌█─█");
        }

        static void forest()
        {
            Console.Clear();
            GameInterface();
            Console.WriteLine("Вы зашли в лес");
            PicLec();
            Console.WriteLine("Под одним из деревьев вы видите ящик");
            Console.WriteLine("Вы заглядываете в него ");
            Console.WriteLine("Там Деньги");
            Console.WriteLine("Получено 7000Р");
            Money += 7000;
            Console.ReadLine();

        }
        static void PicLec()
        {
            Console.WriteLine("     Л");
            Console.WriteLine("     Е");
            Console.WriteLine("     С");

        }

    }
}