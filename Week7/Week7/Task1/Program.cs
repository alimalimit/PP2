using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] myThreads = new Thread[3];
            

            for (int i = 0; i < myThreads.Length; i++)
            {
                myThreads[i] = new Thread(Do);
                myThreads[i].Name = i.ToString();
                myThreads[i].Start();
            }

        }

        static void Do()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                Thread.Sleep(1000);
            }
        }
    }
}
