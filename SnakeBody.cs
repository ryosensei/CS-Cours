using System;
namespace Snake2
{
    public class SnakeBody : Snake
    {
        public SnakeBody(string bodyPart, int x, int y, string direction) : base(x, y)
        {
            this.direction = direction;
        }
    }
}
