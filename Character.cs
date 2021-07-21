using System;
using System.Collections.Generic;
using System.Text;

namespace rpg
{
    class Character
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int MaxHealth { get; protected set; }
        public string TextArt { get; protected set; }
        public ConsoleColor Colour { get; protected set; }
        public Random Rand { get; protected set; }
        public bool IsDead { get => Health <= 0; }
        public bool IsAlive { get => Health > 0; }

        public Character(string name, int health, string textArt, ConsoleColor colour)
        {
            Name = name;
            Health = health;
            MaxHealth = health;
            TextArt = textArt;
            Colour = colour;
            Rand = new Random();
        }

        public void DisplayInfo()
        {
            Console.WriteLine("\n +---+ Character Info +---+ ");
            Console.ForegroundColor = Colour;
            Console.WriteLine($"Name : {Name}" +
                              $"\nHealth : {Health}");
            Console.ResetColor();
            Console.WriteLine(TextArt);
            Console.WriteLine("+-------------------------+\n");
        }

        public virtual void Fight(Character opponent)
        {
            Rand.Next(1, 101);
            Console.WriteLine($"Character is fighting!");
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
            Console.ResetColor();
            Console.WriteLine($"\n{damage} health points has been taken, {Health} is remaining out of {MaxHealth}!");
        }

        public void DisplayHealthBar()
        {
            Console.ForegroundColor = Colour;
            Console.Write($"\n{Name}'s");
            Console.ResetColor();
            Console.Write(" Health : \n");
            Console.Write(" +-{");
            Console.BackgroundColor = ConsoleColor.Green;
            for (int i = 0; i < Health; i++)
            {
                Console.Write(" ");
            }
            Console.BackgroundColor = ConsoleColor.Red;
            for (int i = Health; i < MaxHealth; i++)
            {
                Console.Write(" ");
            }
            Console.ResetColor();
            Console.WriteLine($"}}-+ ({Health}/{MaxHealth})");
        }
    }
}
