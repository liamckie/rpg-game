using System;

namespace rpg
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 100;

            Game game = new Game();
            game.Run();
        }
    }
}
