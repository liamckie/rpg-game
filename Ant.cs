using System;
using System.Collections.Generic;
using System.Text;

namespace rpg
{
    class Ant : Character
    {
        private double ChargeDistance;
        private Item CurrentItem;

        public Ant(string name, int health, ConsoleColor colour, double chargeDistance) : base(name, health, ArtAssets.Ant, colour)
        {
            ChargeDistance = chargeDistance;
        }

        public void PickUpItem(Item item)
        {
            CurrentItem = item;
        }

        public void Charge()
        {
            Console.BackgroundColor = Colour;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($" {Name} ");
            Console.ResetColor();
            Console.WriteLine($" has charged at the Player at a distance of {ChargeDistance} inches!");

            if (CurrentItem != null)
            {
                Console.WriteLine($"They are carrying a {CurrentItem.Name}.");

            }
        }

        public void Bite()
        {
            Console.BackgroundColor = Colour;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($" {Name} ");
            Console.ResetColor();
            Console.WriteLine(" has bitten the Player viciously!");
        }

        public override void Fight(Character opponent)
        {
            int randNum = Rand.Next(1, 101);
            Console.ForegroundColor = Colour;
            Console.Write($"\n{Name} the Ant bites at {opponent.Name} and ");
            if (randNum <= 50)
            {
                Console.WriteLine("hits for 3 damage!");
                opponent.TakeDamage(3);
            }
            else
            {
                Console.WriteLine("misses...");
            }
            Console.ResetColor();
        }
    }
}
