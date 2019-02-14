using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //принимаем значение размера массива
            int n = int.Parse(Console.ReadLine());
            //создаем двумерный массив
            string[,] star = new string[n,n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //используем условие, чтобы главная диагональ и все, что ниже ее, стал равен звездочке 
                    if (i >= j)
                        star[i, j] = "[*]";
                        

                }
              

            }
            //выводим массив
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(star[i, j]);
                }
                Console.WriteLine();

            }
        }
    }
}
