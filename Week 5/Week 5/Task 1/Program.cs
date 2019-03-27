using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task_1
{
    public class ComplexNumber
    {
        public double a;
        public double b;
        
       

        public ComplexNumber()
        {
            a = 5;
            b = 2;
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            F2();
        }

        private static void F2()
        {
            FileStream fs = new FileStream("complexnum.txt", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(ComplexNumber));

            ComplexNumber com = xs.Deserialize(fs) as ComplexNumber;

            fs.Close();
        }

        private static void F1()
        {
            ComplexNumber num = new ComplexNumber();

            FileStream fs = new FileStream("complexnum.txt", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(ComplexNumber));

            xs.Serialize(fs, num);

            fs.Close();

        }
    }
}
