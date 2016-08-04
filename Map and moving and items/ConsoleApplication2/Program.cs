using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication2
{
    class Program
    {

        static int playerPosX=10, playerPosY=10;
        static char playerSymb = '@';
        static char[,] map;
        static char[] stopSymb = { '#' , 'X' };
        static char[] pickedSymb = { 'K', '*' };
        static List<char> inventory = new List<char>();
        static Dictionary<char, ConsoleColor> symbolColors = new Dictionary<char, ConsoleColor>();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            symbolColors = SetColors();
            map = GenerateMap(50, 25);

            while (true)
            {
                PlayerController();
                showMap(map);
                renderInterface(52,0);

                Thread.Sleep(50);
            }
            Console.ReadLine();

        }

        

        private static void PlayerController()
        {
            MoveController();
        }

        private static void MoveController()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    MovePlayer(-1,0);
                    break;
                case ConsoleKey.RightArrow:
                    MovePlayer(1, 0);
                    break;
                case ConsoleKey.UpArrow:
                    MovePlayer(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    MovePlayer(0, 1);
                    break;
            }

        }

        private static void MovePlayer(int x, int y)
        {
            int targetX = playerPosX + x,
                targetY = playerPosY + y;
           

            if (CheckCollision(targetX, targetY))
            {
                playerPosX += x;
                playerPosY += y;
            }
        }


        static bool CheckCollision(int x, int y)
        {
            bool canMove = true;
            char targetSymbol = map[x, y];

            foreach (char s in stopSymb)
            {
                if (targetSymbol == s)
                {
                    canMove = false;
                }
            }

            foreach (char s in pickedSymb)
            {
                if (targetSymbol == s)
                {
                    inventory.Add(map[x, y]);
                    map[x,y]= ' ';
                }
            }

            return canMove;
        }

        static void renderInterface(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x,y);
            Console.Write("Инвентарь:");
            y++;
            for (int i = 0; i < inventory.Count; i++ )
            {
                Console.SetCursorPosition(x, y+i);
                Console.Write("   - {0}", inventory[i]);
                
            }
        }

        static Dictionary<char, ConsoleColor> SetColors()
        {
            Dictionary<char, ConsoleColor> result = new Dictionary<char, ConsoleColor>();
            result.Add('K', ConsoleColor.Yellow);
            result.Add('#', ConsoleColor.Red);
            result.Add('X', ConsoleColor.Red);
            result.Add('*', ConsoleColor.Green);

            return result;
        }

        static void showMap(char[,] map)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (symbolColors.ContainsKey(map[x, y]))
                    {
                        Console.ForegroundColor = symbolColors[map[x, y]];
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                        Console.SetCursorPosition(x, y);
                        Console.Write(map[x,y]);
                }
            }
            Console.SetCursorPosition(playerPosX, playerPosY);
            Console.Write(playerSymb);
        }

        static char[,] GenerateMap(int widht, int height)
        {
            char[,] result = new char[widht, height];
            Random r = new Random();

            for (int x = 0; x < result.GetLength(0); x++)
            {
                for (int y = 0; y < result.GetLength(1); y++)
                {
                    if ((x == 0 || y == 0) || (x == widht - 1 || y == height - 1))
                    {
                        result[x, y] = '#';
                    }
                    else
                    {
                        int rr = r.Next(0, 100);
                        if (rr > 70)
                        {
                            result[x, y] = pickedSymb[r.Next(0, pickedSymb.Length)];
                        }
                    }

                }
            }

            return result;   
        }
    }
}
