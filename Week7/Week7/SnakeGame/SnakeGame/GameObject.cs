using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    abstract class GameObject
    {
        public List<Point> body = new List<Point>();
        char sign;

        public GameObject(char sign)
        {
            this.sign = sign;

        }

        public void Draw()
        {
            foreach (var p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
            }
           
        }

        public void Clear()
        {
            foreach (var p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(' ');
            }

        }
    }
}
