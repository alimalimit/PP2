using System;
using System.IO;
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
            
            string oldPath = @"C:\Users\Admin\Desktop\физика\testing\Old";
            string newPath = @"C:\Users\Admin\Desktop\физика\testing\New";
            

            string fileName = "hello world";

            string sourcefile = Path.Combine(oldPath, fileName);
            string targetfile = Path.Combine(newPath, fileName);

            using (File.Create(sourcefile))
            {

            };

            File.Copy( sourcefile,targetfile , true);

            File.Delete(sourcefile);

        }
           
        }
    }

