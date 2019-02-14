using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
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
            
            string str = File.ReadAllText(@"C:\Users\Admin\Desktop\PP2\input.txt");
            string[] s = str.Split();
            int[] a = new int[str.Length];

            for (int i = 0; i < s.Length; i++)
            {
                a[i] = int.Parse(s[i]);

            }

            int cnt = 0;
            int pr_i = 0;

            for (int i = 0; i < s.Length; i++)
            {

                if (Prime(a[i]))
                {
                    cnt++;
                }
            }

            string[] t = new string[cnt];


            for (int i = 0; i < s.Length; i++)
            {

                if (Prime(a[i]))
                {
                    t[pr_i] = a[i].ToString();
                    pr_i++;
                }
            }

            File.WriteAllText(@"C:\Users\Admin\Desktop\PP2\output.txt", string.Join(" ", t));
            
        }
    }
}
