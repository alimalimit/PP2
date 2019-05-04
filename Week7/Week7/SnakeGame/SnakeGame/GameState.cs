using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SnakeGame
{
    class GameState
    {
        Worm worm = new Worm('O');
        Food food = new Food('@');
        Wall wall = new Wall('#');

        Timer timer = new Timer();
        public GameState()
        {
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            /*Console.WriteLine("Enter your username");
            string username = Console.ReadLine();
            Console.Clear();*/
            Console.CursorVisible = false;
        }

        internal void Run()
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 500;
            timer.Start();

            food.Draw();
            wall.Draw();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            worm.Clear();
            worm.Movement();
            worm.Draw();
            CheckCollision();
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
                    worm.Dx = 0;
                    worm.Dy = -1;
                    break;
                case ConsoleKey.DownArrow:
                    worm.Dx = 0;
                    worm.Dy = 1;
                    break;
                case ConsoleKey.RightArrow:
                    worm.Dx = 1;
                    worm.Dy = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    worm.Dx = -1;
                    worm.Dy = 0;
                    break;

            }

            
        }

    


    }
}
