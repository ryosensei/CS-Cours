using System;
using System.Threading;
using System.Threading.Tasks;

namespace Snake2
{
    public class Game
    {
        protected int width, height;
        protected Food food;
        protected Snake snake;
        protected const int refreshTime = 100;
        private static DateTime nextUpdate = DateTime.MinValue;
        public static int framesSinceLastDirectionChange = 0;

        public Game(int width, int height)
        {
            try
            {
                Console.SetBufferSize(width, height);
                Console.SetWindowSize(width, height);
                this.width = width;
                this.height = height;
            }
            catch (Exception e)
            {
                this.width = Console.WindowWidth;
                this.height = Console.WindowHeight;
            }
            Console.CursorVisible = false;
            Console.Clear();

            Food food = new Food();
            int x = this.getMidX();
            int y = this.getMidY();
            Snake sn = new Snake(x, y);

            this.snake = sn;
            this.food = food;

        }

        protected int getMidX()
        {
            return (this.width / 2);
        }
        protected int getMidY()
        {
            return (this.height / 2);
        }
        public bool gameOver()
        {
            return false;
        }
        public void render()
        {
            if (updateGame())
            {
                Task task = new Task(handleUserChoice);
                task.Start();
                Console.Clear();
                snake.move();
                snake.render();
                food.render();
                this.detectEat();
                framesSinceLastDirectionChange++;

            }
        }
        protected void updateBodyDirection()
        {
            for (int i = 0; i < Game.framesSinceLastDirectionChange && this.snake.getBody().Count > i; i++)
            {
                this.snake.getBody()[i].updateDirection(this.snake.getDirection());
            }
        }
        private static bool updateGame()
        {
            if (DateTime.Now < nextUpdate)
            {
                return false;
            }
            nextUpdate = DateTime.Now.AddMilliseconds(Game.refreshTime);
            return true;
        }
        protected void handleUserChoice()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    this.snake.updateDirection("left");
                    break;
                case ConsoleKey.RightArrow:
                    this.snake.updateDirection("right");
                    break;
                case ConsoleKey.UpArrow:
                    this.snake.updateDirection("up");
                    break;
                case ConsoleKey.DownArrow:
                    this.snake.updateDirection("down");
                    break;
            }
        }
        protected void detectEat()
        {
            if (this.snake.getX() == this.food.getX() && this.snake.getY() == this.food.getY())
            {
                Console.Beep();
                this.food.move();
                this.snake.eat();
            }
        }
        void showDebug()
        {
            Console.SetCursorPosition(1, 1);
            Console.WriteLine(framesSinceLastDirectionChange);
        }
    }
}