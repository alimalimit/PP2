using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class GameState
    {
        Worm worm = new Worm('O');
        Food food = new Food('@');
        Wall wall = new Wall('#');
        public GameState()
        {
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            /*Console.WriteLine("Enter your username");
            string username = Console.ReadLine();
            Console.Clear();*/
            Console.CursorVisible = false;
        }

        public void Draw()
        {
            worm.Draw();
            food.Draw();
            wall.Draw();
        }

        public void CheckCollision()
        {
            if (worm.CheckIntersection( food.body[0]) )
            {
                worm.Eat(food.body[0]);
                food.Generate();


            }

        }

        public void ProcessKey(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    worm.Movement(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    worm.Movement(0, 1);
                    break;
                case ConsoleKey.RightArrow:
                    worm.Movement(1, 0);
                    break;
                case ConsoleKey.LeftArrow:
                    worm.Movement(-1, 0);
                    break;

            }

            CheckCollision();
        }

    


    }
}
