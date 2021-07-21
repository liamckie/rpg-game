using System;
using System.Collections.Generic;
using System.Text;

namespace rpg
{
    class Game
    {
        private Player player;
        private Character enemy;
        private List<Character> Characters;

        private string Title = @"  __  __ _                ___ ___  ___ 
 |  \/  (_)__ _ _ ___ ___| _ \ _ \/ __|
 | |\/| | / _| '_/ _ \___|   /  _/ (_ |
 |_|  |_|_\__|_| \___/   |_|_\_|  \___|
";

        public Game()
        {
            Ant Ant = new Ant("Ant", 10, ConsoleColor.Red, 2.4);

            Item LeafNinjaStar = new Item("Leaf Ninja Star", 10);
            Ant HadesAnt = new Ant("Hades", 20, ConsoleColor.Magenta, 4.2);
            HadesAnt.PickUpItem(LeafNinjaStar);

            Bee Bee = new Bee("Buzz", 15, ConsoleColor.Yellow, false);

            Characters = new List<Character>() { Ant, HadesAnt, Bee };
        }

        public void Run()
        {
            Intro();

            for (int i = 0; i < Characters.Count; i++)
            {
                enemy = Characters[i];
                IntroCurrentEnemy();
                BattleCurrentEnemy();

                if (player.IsDead)
                {
                    Console.WriteLine($"{player.Name} has died! You Lose! :(");
                    WaitForKey();
                    break;
                }
                else
                {
                    Console.WriteLine($"{enemy.Name} has died! You Win! :)");
                    WaitForKey();
                }
            }

            RunGameOver();
        }

        private void RunGameOver()
        {
            if (player.IsAlive)
            {
                Console.Clear();
                Console.WriteLine(@"Congratulations, you have Won the game and defeated all of your enemies!
You also make it back your lab in order to reverse your experiment and return to your original size!
");
                WaitForKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(@"Unfortunately, you have been defeated in micro-combat!
You were not able to make it to your lab to reverse your experiment!
");
                TryAgain();
                WaitForKey();
            }
        }

        private void TryAgain()
        {

            Console.Write("Would you like to try again? (yes/no) : ");
            string answer = Console.ReadLine().Trim().ToLower();
            bool tryAgain;

            if (answer == "yes" || answer == "y")
            {
                Console.Clear();
                Run();
            }
            else 
            {
                tryAgain = false;
            }
        }

        private void IntroCurrentEnemy()
        {
            Console.Clear();
            Console.Write("You are about to face ");
            Console.ForegroundColor = enemy.Colour;
            Console.WriteLine(enemy.Name);
            Console.ResetColor();
            enemy.DisplayInfo();
            WaitForKey();
        }

        private void BattleCurrentEnemy()
        {
            while (player.IsAlive && enemy.IsAlive)
            {
                Console.Clear();
                player.DisplayHealthBar();
                enemy.DisplayHealthBar();

                player.Fight(enemy);

                WaitForKey();

                if (player.IsDead || enemy.IsDead)
                {
                    break;
                }

                Console.Clear();
                player.DisplayHealthBar();
                enemy.DisplayHealthBar();
                enemy.Fight(player);

                WaitForKey();
            }
        }

        public void Intro()
        {
            Console.Title = "Micro-RPG";
            Console.WriteLine(Title);
            Console.WriteLine("Welcome to this Micro-RPG!");
            Console.Write("\nEnter your name : ");
            string nameInput = Console.ReadLine().Trim();

            if (nameInput == "")
            {
                nameInput = "Player";
            }
            Console.Clear();
            player = new Player(nameInput, 20, ConsoleColor.Cyan);

            Console.WriteLine("You wake up outside and look around to find yourself in a field filled with blades of grass\ntowering over you...");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"

     /  /          \
/   /   \          /   \
\   \   /          \   /  /
/   /  /     o   \  \  \  \
\  /  /  /  /|\  /  /  /  /
 \ \  \ /   / \  \ /   \ / 
");
            Console.ResetColor();
            WaitForKey();
            Console.Clear();
            Console.WriteLine($@"Your memory is hazy, but you remember flashes of your science experiment. You accidentally shrank
yourself down to the size of a penny. As you look around, you spot a colony of Ants which have taken
an intrest in you. Looks like your going to have to fight your way back to safety in your lab and
return to your original size

Are you ready? You have {Characters.Count} enemies incoming be prepared!");
            player.DisplayHealthBar();
            player.DisplayInfo();
            WaitForKey();
        }

        private void WaitForKey()
        {
            Console.WriteLine("Press any key...\n");
            Console.ReadKey(true);
        }
    }
}
