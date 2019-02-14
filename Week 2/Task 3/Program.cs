using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        //создадим рекурсивную функцию, которая поможет визуально изобразить
        //местоположение файлов или папок, используя отступы
        static void PrintInfo(FileSystemInfo d, int n)
        {
            string stair = new string(' ', n); // создаем строку состоящая из пробела, повторяющегося n раз
            stair = stair + d.Name; // пусть наш файл или папка будут иметь отступ, чтобы 
            //показать раположение папки или файла
            Console.WriteLine(stair);


            //если мы работаем с папкой, то тогда приводим нашу переменную FileSystemInfo d к типу DirectoryInfo
            //а затем извлекаем из нее содержимое
            if (d.GetType() == typeof(DirectoryInfo)) 
            {
                var folders = (d as DirectoryInfo).GetFileSystemInfos();
                //для содержимого папки создаем еще больший отступ, заново вызывая функцию
                foreach ( var t in folders)
                {
                    PrintInfo(t, n + 5);
                }

            }

        }
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Admin\Desktop\Alima Eldes\study");
            PrintInfo(dir, 0);//передаем в функцию нужную папку и пусть начальные папки и файлы будут без отступа
        }

        
    }
}
