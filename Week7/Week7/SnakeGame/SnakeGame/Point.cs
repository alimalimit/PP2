using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Point
    {
        int x;
        int y;

        int Filter(int a)
        {
            if( a >= 40)
            {
                a = 0;
            }
            else if ( a < 0)
            {
                a = 39;
            }
            return a;
        } 
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = Filter(value);
            }
        }
   
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = Filter(value);
            }
        }

    }
}
