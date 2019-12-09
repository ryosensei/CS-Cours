using System;

namespace Snake2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Game game = new Game(50, 50);
            while (!game.gameOver())
            {
                game.render();
            }
        }
    }
}
