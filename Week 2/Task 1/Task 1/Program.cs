using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        
        static bool Palindrome( string s)
        {
            bool f = true;
            for (int i = 0; i <= s.Length/2; i++)
            {
                if ( s[i] != s[s.Length - i - 1])
                {
                    f = false;
                    break;
                }
                
            }
            return f;
            
        }
        static void Main(string[] args)
        {
            string str = File.ReadAllText(@"C:\Users\Admin\Desktop\PP2\string.txt");

            if (Palindrome(str))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");

        }
    }
}
