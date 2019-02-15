using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace File_Manager_Application
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string path = @"C:\Users\Admin\Desktop\FarMan"; //путь используемой нами папки
            FarManager fr = new FarManager(path);
            fr.F();
            
        }

        class FarManager
        {

            public string path; 
            //путь передаваемой нами папки

            public FileSystemInfo presentFSI ; 
            //папка, с которой мы работаем на данный момент

            public int selectedItemIndex;//курсор

            public DirectoryInfo dir; //используем класс Папки
            public int lngth; //длина папки

            public FarManager (string path)
            {
                this.path = path;
                selectedItemIndex = 0;
                dir = new DirectoryInfo(path);

                //количество папок и файлов в переданной папке
                lngth = dir.GetFileSystemInfos().Length;

            }

            public FarManager()
            {
                selectedItemIndex = 0;
            }

            public void Up()
            {
                //если мы курсором хойти навести на объект выше 1-го элемента, то курсор наведется
                //на последний элемент
                selectedItemIndex--;
                if ( selectedItemIndex < 0 )
                {
                    selectedItemIndex = lngth - 1;
                }

            }

            public void Down()
            {
                //если мы курсором хойти навести на объект ниже последнего элемента, то курсор 
                //наведется на 1-й элемент
                selectedItemIndex++;
                if( selectedItemIndex >= lngth)
                {
                    selectedItemIndex = 0;
                }
            }

            public void Color(FileSystemInfo fs, int ind)
            {
                //закрашиваем красным цветом файл или папку, наведеннную курсором
                if (ind == selectedItemIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    presentFSI = fs;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (fs.GetType() == typeof(DirectoryInfo))
                 //если наведенный курсором объект является папкой, то он закрашивается
                 //пурпурным цветом
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    
                }
                else
                //если наведенный курсором объект является файлом, то он закрашивается
                //желтым цветом
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                  
                }
            }
            public void Draw()
            {
                //нумерация содержимого в папке
                int index = 1;

                DirectoryInfo dir = new DirectoryInfo(path);
                var all = dir.GetFileSystemInfos();

                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();

                for (int i = 0; i < all.Length; i++)
                {
                    //выводим на консоль содержимое
                    Console.WriteLine(index + ". " + all[i]);
                    index++;

                    Color(all[i], i);
                }


            }

            //осуществляем все наши команды в следующей функции
            public void F()
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                //при нажатии на клавишу "esc" программа перестанет работать
                while( pressedKey.Key != ConsoleKey.Escape)
                {
                    Draw();
                    pressedKey = Console.ReadKey();
                    switch ( pressedKey.Key)
                    {
                        //управление курсором Вверх и Вниз
                        case ConsoleKey.UpArrow:
                            Up();
                            break;
                        case ConsoleKey.DownArrow:
                            Down();
                            break;
                        //зажимаем клавишу "Enter", если хотим посмотреть содержимое выбранной папки или файла
                        case ConsoleKey.Enter:
                            //если выбранный элемент - файл, то открываем его 
                            if ( presentFSI.GetType() == typeof(FileInfo))
                            {
                                selectedItemIndex = 0;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Black;
                                //открывае файл
                                using (StreamReader sr = new StreamReader(presentFSI.FullName)) 
                                {
                                    Console.WriteLine(sr.ReadToEnd());
                                    //выводим на консоль
                                }
                                Console.ReadKey();

                            }
                            //если выбранный элемент - папка, то проваливаемся в его содержимое

                            if( presentFSI.GetType() == typeof(DirectoryInfo))
                            {
                                //теперь мы используем путь выбранной нами папки
                                path = presentFSI.FullName;
                                selectedItemIndex = 0;
                            }
                            
                            break;

                        //нажимая на клавишу "Backspace",мы возвращаемся к предыдущей папке
                        case ConsoleKey.Backspace:
                            selectedItemIndex = 0;
                            path = dir.Parent.FullName;
                            break;

                        //нажимая на клавишу "R", мы можем переименовать нашу папку или файл
                        case ConsoleKey.R:
                            selectedItemIndex = 0;
                            //переименовать папку
                            if (presentFSI.GetType() == typeof(DirectoryInfo))
                            {
                                Console.Clear();
                                //считываем предлагаемое название
                                string str = Console.ReadLine();
                                string Name = presentFSI.Name; //название текущей папки
                                string f_name = presentFSI.FullName;//путь текущей папки
                                string newpath = "";//новый путь для нашей папки

                                //находим разницу между путем и именем текущей папки, 
                                //таким образом, изменяем название в пути папки
                                for (int i = 0; i < f_name.Length - Name.Length; i++)
                                {
                                    newpath += f_name[i];
                                }
                            
                                newpath = newpath + str;

                                //перемещаем папку в местоположение с новым название
                                Directory.Move(f_name, newpath);
                            }
                            //аналогично переименовываем файл
                            else
                            {
                                Console.Clear();
                                string str = Console.ReadLine();
                                string Name = presentFSI.Name;
                                string f_name = presentFSI.FullName;
                                string newpath = "";
                                for (int i = 0; i < f_name.Length - Name.Length; i++)
                                {
                                    newpath += f_name[i];
                                }
                                newpath = newpath + str;
                                File.Move(f_name, newpath);
                            }
                            break;

                            //зажимая клавишу "Del", мы удаляем папку 
                        case ConsoleKey.Delete:

                            selectedItemIndex = 0;
                            //допустим, что мы работаем с папкой
                            if (presentFSI.GetType() == typeof(DirectoryInfo))
                            {

                                if (new DirectoryInfo(presentFSI.FullName).GetFileSystemInfos().Length == 0)//если папка пустая, то она сразу удаляется
                                {
                                    Directory.Delete(presentFSI.FullName);
                                }
                                //однако если папка имеет содержимое, то появляется запрос подтверждения при удалении папки
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("are you sure you want to permanently delete this folder ?");
                                    //если да, то папка удаляется
                                    if (Console.ReadKey().Key == ConsoleKey.Y)
                                    {
                                       //при наличии соответствующей инструкции, папка удаляется
                                        Directory.Delete(presentFSI.FullName, true);
                                    }
                                    
                                }
                            }
                            //допустим, что мы работаем с файлом
                            else if (presentFSI.GetType() == typeof(FileInfo))//удаляем файл
                            {
                                File.Delete(presentFSI.FullName);
                            }
                            break;



                    }
                }

            }

            
        }

        

        
    }
}