using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public static bool Prime(int a)//создаем функцию для проверки простых чисел
        {
            bool ch = true;
            if (a == 1) ch = false;
            for (int i = 2; i <= Math.Sqrt(a); i++)//если число простое,надо проверить не делится ли число
            //на числа до квадратного корня из этого числа
            {
                if (a % i == 0)
                {
                    ch = false;
                }
            }
            return ch;
        }
        static void Main(string[] args)
        {

            
            int nn = int.Parse(Console.ReadLine());//принимаем количество числе в массиве
            string s = Console.ReadLine();
            string[] arr = s.Split();//создаем массив и разибиваем строку s на элементы массива
            int cnt = 0;//создаем счетчик

            for (int i = 0; i < nn; i++)
            {
                int c = int.Parse(arr[i]);//преобразовываем элемент массива в число 
                if (Prime(c) == true)//увеличиваем счетчик, если число простое
                {
                    cnt++;
                }
            }
            Console.WriteLine(cnt);//выводим счетчик

            for (int i = 0; i < nn; i++)
            {
                int c = int.Parse(arr[i]);
                if (Prime(c) == true) //проверяем, является ли число простым
                {
                    Console.Write(c + " ");//выводим на экран простые числа через пробел в строке
                }
            }
            
        }
    }
}
