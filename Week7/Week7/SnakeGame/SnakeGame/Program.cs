﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameState gameState = new GameState();

            gameState.Run();
            while(true)
            {
                

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                gameState.ProcessKey(keyInfo);
            }


           
        }
    }
}
