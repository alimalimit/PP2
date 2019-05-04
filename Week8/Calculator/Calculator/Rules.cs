using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Rules
    {
        public static bool IsDigit(string msg)
        {
            string[] arr = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            return arr.Contains(msg);
        }

        public static bool IsNonZeroDigit(string msg)
        {
            string[] arr = new string[] {"1", "2", "3", "4", "5", "6", "7", "8", "9" };
            return arr.Contains(msg);
        }

        public static bool IsZeroDigit(string msg)
        {
            string[] arr = new string[] { "0"};
            return arr.Contains(msg);
        }

        public static bool IsOperation(string msg)
        {
            string[] arr = new string[] { "+", "-", "*", "/", "^", "CC", "cl", "pp" };
            return arr.Contains(msg);
        }

        public static bool IsResult(string msg)
        {
            string[] arr = new string[] { "="};
            return arr.Contains(msg);
        }
        public static bool IsQuickOperation(string c)
        {
            string[] arr = new string[] { "x^2", "√", "←", "C", "±", "1/x", "!", "f", "p", "B", "cos", "Dig" };
            return arr.Contains(c);
        }
        public static bool IsPoint(string c)
        {
            string[] arr = new string[] { "," };
            return arr.Contains(c);
        }
    }
}
