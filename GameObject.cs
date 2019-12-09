using System;
namespace Snake2
{
    public class GameObject
    {
        protected int x, y;
        protected string bodyPart;

        public GameObject(string body, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.bodyPart = body;
        }
        public GameObject(string body)
        {
            this.bodyPart = body;
            this.move();
        }
        public int getX()
        {
            return this.x;
        }
        public int getY()
        {
            return this.y;
        }
        public void move(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public virtual void move()
        {
            Random rnd = new Random();
            int x = rnd.Next(1, Console.WindowWidth);
            int y = rnd.Next(1, Console.WindowHeight);

            this.x = x;
            this.y = y;
        }
        public virtual void render()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.Write(this.bodyPart);
        }
    }
}
