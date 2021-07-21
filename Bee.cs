using System;
using System.Collections.Generic;
using System.Text;

namespace rpg
{
    class Bee : Character
    {
        private bool HasPoisonSting;

        public Bee(string name, int health, ConsoleColor colour, bool hasPoisonSting) : base(name, health, ArtAssets.Bee, colour)
        {
            HasPoisonSting = hasPoisonSting;
        }

        public void Fly()
        {
            Console.BackgroundColor = Colour;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($" {Name} ");
            Console.ResetColor();
            Console.WriteLine(" takes to the air!");
        }


        public void Sting()
        {
            Console.BackgroundColor = Colour;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($" {Name} ");
            Console.ResetColor();
            Console.Write(" lunges with the their ");
            if (HasPoisonSting) Console.WriteLine("poison stinger!");
            else Console.WriteLine("sharp stinger!");
        }

        public override void Fight(Character opponent)
        {
            Console.ForegroundColor = Colour;
            Console.WriteLine($"Bee {Name} is fighting {opponent.Name}!");
            Console.ResetColor();
        }
    }
}
