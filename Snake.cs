using System;
using System.Collections.Generic;
namespace Snake2
{
    public class Snake : GameObject
    {
        protected List<SnakeBody> body;
        protected string direction = "right";
        public string lastDirection = "right";
        public new string bodyPart;

        public Snake(int x, int y) : base("+", x, y)
        {
            this.body = new List<SnakeBody>();
            this.bodyPart = "+";
        }
        public void updateDirection(String direction)
        {
            this.lastDirection = this.direction;
            this.direction = direction;      
        }
        public List<SnakeBody> getBody()
        {
            return this.body;
        }
        public override void move()
        {
            switch (this.direction)
            {
                case "right":
                    if (this.x + 1 >= Console.WindowWidth)
                    {
                        this.x = 0;
                    }
                    else
                    {
                        this.x++;
                    }
                    break;
                case "left":
                    if (this.x - 1 <= 0)
                    {
                        this.x = Console.WindowWidth - 1;
                    }
                    else
                    {
                        this.x--;
                    }
                    break;
                case "up":
                    if (this.y - 1 <= 0)
                    {
                        this.y = Console.WindowHeight - 1;
                    }
                    else
                    {
                        this.y--;
                    }
                    break;
                case "down":
                    if (this.y + 1 >= Console.WindowHeight)
                    {
                        this.y = 0;
                    }
                    else
                    {
                        this.y++;
                    }
                    break;
            }
            if (this.body.Count > 0)
            {
                for (int i = this.body.Count - 1; i >= 1 ; i--)
                {
                    this.body[i].move(this.body[i - 1].getX(), this.body[i - 1].getY());
                }
                this.body[0].move(this.getX(), this.getY());
            }
        }
        public void eat()
        {
            SnakeBody newBody = new SnakeBody(this.bodyPart, this.getLastX(), this.getLastY(), this.getLastDirection());
            this.body.Add(newBody);
        }
        public string getDirection()
        {
            return this.direction;
        }
        public string getLastDirection()
        {
            string LastDirection;
            if (this.body.Count == 0)
            {
                LastDirection = this.direction;
            }
            else
            {
                SnakeBody lastElem = this.body[this.body.Count - 1];
                LastDirection = lastElem.direction;
            }
            return LastDirection;
        }
        protected int getLastX()
        {
            string LastDirection = this.getLastDirection();
            int returnValue;
            switch (LastDirection)
            {
                case "left":
                    returnValue = this.x - 1;
                    break;
                case "right":
                    returnValue = this.x + 1;
                    break;
                case "up":
                case "down":
                default:
                    returnValue = this.x;
                    break;
            }
            return returnValue;
        }
        protected int getLastY()
        {
            string LastDirection = this.getLastDirection();

            switch (LastDirection)
            {
                case "up":
                    return this.y + 1;
                    break;
                case "down":
                    return this.y - 1;
                    break;
                case "left":
                case "right":
                default:
                    return this.y;
                    break;
            }
        }
        public override void render()
        {
            base.render();
            foreach (SnakeBody bodyElem in this.body)
            {
                bodyElem.render();
            }
        }
    }
}
