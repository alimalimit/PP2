using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        //создаем функцию, которая будет создавать новый массив с повторяющимися элементами
        static int[] Repeat( int[] a, int n)
        {
            int[] b = new int[n * 2]; //новый массив будет иметь удвоенный размер, так как элементы будут повторяться
            for( int i = 0; i < n; i++)
            {
                b[i * 2] = a[i]; //при создании повторяющегося элемента у нас будет работать следующее правило
                b[i * 2 + 1] = a[i];
            }

            return b;
        }
        static void Main(string[] args)
        {
            //принимаем количество переменных через строку и переводим в тип данных int
                int n = int.Parse(Console.ReadLine());
            //принимаем строку состоящую из массива, и разделяем каждый элемент по пробелу
                string[] orig = Console.ReadLine().Split();
            //создаем массив из целых чисел
                int[] a = new int[n];
                for (int i = 0; i < n; i++)
                {
                //элемент целочисленного массива равен переведенному в целочисленный тип элементу массива из строк
                    a[i] = int.Parse(orig[i]);
                }
                //вызываем функцию, которая удваивает каждый элмент массива
                int[] doubled = Repeat(a, n);
            //выводим получившийся массив
                for (int i = 0; i < doubled.Length; i++)
                {
                    Console.Write(doubled[i] + " ");
                }
   
        }
    }
}

