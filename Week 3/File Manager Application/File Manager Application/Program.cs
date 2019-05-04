using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace File_Manager_Application
{
    
    class FarManager//создаю класс Farmanager 
    {
        int cursor;//создаю курсор
        int cnt;//  количество файлов(каждый раз считает в каждой папке кол-во файлов и папок)

        public FarManager()//пустой конструктор
        {
            cursor = 0;//кусор ставлю на первую верхнюю строку
        }

        public void Print(DirectoryInfo dire, int z)//метод в который мы передаем две данные: инф о папке и курсор
        {
            FileSystemInfo[] d = dire.GetFileSystemInfos();//создаю массив в который сохраняю все что есть(файлы и папки)
            for (int i = 0; i < d.Length; i++)//пробегаем по всем папкам и файлам в указанной папке
            {
                if (z == i)//если курсор стоит на чем-то
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine(i + 1 + ". " + d[i].Name);//выводим нумерацию и имя файла или папки
                }
                else if (d[i].GetType() == typeof(FileInfo))// если это файл
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(i + 1 + ". " + d[i].Name);
                }
                else if (d[i].GetType() == typeof(DirectoryInfo))//если это папка
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(i + 1 + ". " + d[i].Name);
                }
                
            }
        }

        public void Up()
        {
            cursor--;//курсор идет наверх
            if (cursor < 0)//если он достиг верхней строки
            {
                cursor = cnt - 1;// то переходит на последнюю строку
            }
        }

        public void Down()
        {
            cursor++;// курсор идет вниз
            if (cursor == cnt)//если достиг последней крайней строки
            {
                cursor = 0;// то переходит на верхнюю
            }
        }

        public void Start(string path)//функцию в которой распределяю кнопки 
        {
            ConsoleKeyInfo button = Console.ReadKey();//считываю кнопку
            while (button.Key != ConsoleKey.Escape)// это программа будет работать пока не нажать esc
            {
                DirectoryInfo dir = new DirectoryInfo(path);//сохраняет путь папки в dir
                FileSystemInfo[] d = dir.GetFileSystemInfos();//создаю массив в который сохраняю все что есть(файлы и папки)
                cnt = d.Length;//придаю cnt длину массива
                Print(dir, cursor);// вызываю метод print
                button = Console.ReadKey();//каждый раз сохраняем информацию о кнопке чтобы если нажать вниз каждый раз вниз не нажималось
                Console.BackgroundColor = ConsoleColor.Black;//чтобы все стерлось и оказался только черный фон
                Console.Clear();//стерлось
                if (button.Key == ConsoleKey.F2) //F2 нужна что бы переименовать имя 
                {
                    if (d[cursor].GetType() == typeof(FileInfo))//переименовать имя файла
                    {
                        string s = Console.ReadLine();//вводим имя
                        string s1 = Path.Combine(dir.FullName, s); // комбинируем это имя с путем
                        File.Move(d[cursor].FullName, s1); // переименуем
                        Console.BackgroundColor = ConsoleColor.Black; //нужно для того что бы мы сразу видели изменения
                        Console.Clear();
                    }
                    if (d[cursor].GetType() == typeof(DirectoryInfo))//для папки
                    {
                        string s = Console.ReadLine();
                        string s1 = Path.Combine(dir.FullName, s);
                        Directory.Move(d[cursor].FullName, s1);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                    }
                }
                if (button.Key == ConsoleKey.UpArrow)
                {
                    Up();//функция up
                }
                if (button.Key == ConsoleKey.DownArrow)
                {
                    Down();//функция down
                }
                if (button.Key == ConsoleKey.Enter)
                {
                    if (d[cursor].GetType() == typeof(FileInfo)) // для того что бы открыть текстовые файлы

                    {
                        StreamReader sr = File.OpenText(d[cursor].FullName);
                        string s = sr.ReadToEnd(); // сохраняем все что есть в текстовом файле в строку
                        sr.Close();//закрываем
                        Console.WriteLine(s);// и выводим на экран


                    }
                    if (d[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        path = d[cursor].FullName;// то он заходит в указанную папку где стоит курсор
                        cursor = 0;//когда заходим в паку то на нулевой строке
                    }
                }
                if (button.Key == ConsoleKey.Backspace)
                {
                    cursor = 0;//на нулевой
                    dir = dir.Parent;//обращается и переходит к предыдущую папку где находится изначальная папка
                    path = dir.FullName;//и меняем путь
                }
                if (button.Key == ConsoleKey.Delete)
                {
                    if (d[cursor].GetType() == typeof(DirectoryInfo))// если это папка и курсор на ней
                        Directory.Delete(d[cursor].FullName);//удаляем
                    else
                        File.Delete(d[cursor].FullName);// удаляем папку
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            FarManager far = new FarManager(); //даю Farmanager-у имя far
            far.Start(@"C:\Users\Admin\Desktop\FarMan"); //указываем путь в котором мы будем запускать FarManager
        }
    }
}