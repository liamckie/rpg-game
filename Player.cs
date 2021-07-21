using System;
using System.Collections.Generic;
using System.Text;

namespace rpg
{
    class Player : Character
    {
        public Player(string name, int health, ConsoleColor colour) : base(name, health, ArtAssets.Player, colour)
        {

        }

        private void ThrowDirtAt(Character opponent)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("You throw at clump of dirt ");
            int randNum = Rand.Next(1, 101);
            if (randNum <= 90)
            {
                Console.WriteLine("and it hits!");
                opponent.TakeDamage(2);
            }
            else
            {
                Console.WriteLine("and it misses...");
            }
            Console.ResetColor();
        }

        private void SwingAt(Character opponent)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("You take a mighty swing ");
            int randNum = Rand.Next(1, 101);
            if (randNum <= 50)
            {
                Console.WriteLine("and it hits!");
                opponent.TakeDamage(4);
            }
            else
            {
                Console.WriteLine("and it misses...");
            }
            Console.ResetColor();
        }

        public override void Fight(Character opponent)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nYou are facing {opponent.Name}");
            Console.ResetColor();
            Console.Write($@"What would you like to do? :
 1. Pick up a clump of dirt and throw it (90% change to do 2 damage).
 2. Take a might swing with a twig (50% chance to do 4 damage).

 >>> ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            Console.ResetColor();
            if (keyInfo.Key == ConsoleKey.D1)
            {
                ThrowDirtAt(opponent);
            }
            else if (keyInfo.Key == ConsoleKey.D2)
            {
                SwingAt(opponent);
            }
            else
            {
                Console.WriteLine("Invalid Move. Please try again!");
                Fight(opponent);
                return;
            }
        }
    }
}
