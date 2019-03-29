using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{   
    class myThread
    {
        public Thread threadField;

        public myThread(string name)
        {
            threadField = new Thread(Print);
            threadField.Name = name;
        }

        public void startThread()
        {
            
            threadField.Start();
        }

        public void Print()
        {
            for (int i = 1; i <= 4; i++)
            {
                Console.Write(threadField.Name 
                    + " выводит ");
                
                Console.WriteLine(i);
            }

            Console.WriteLine(threadField.Name + " завершился");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            myThread t1 = new myThread("Thread 1");
            myThread t2 = new myThread("Thread 2");
            myThread t3 = new myThread("Thread 3");

            t1.startThread();
            t2.startThread();
            t3.startThread();
        }
    }


}
