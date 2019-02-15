using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    //создаем класс студент
    class Student
    {
        //присваиваем и считываем значения свойств с помощью аксессоров
        public string Name { get; set; } 
        public string Id { get; set; }
        public int Year { get; set; }
        
        //создаем конструктор с двумя параметрами, принимающий значение имени и айди студента
        public Student ( string Name, string Id)
        {
            this.Name = Name;
            this.Id = Id;
        }

        //увеличиваем год обучения студента
        public void NextYear()
        {
            Year++;
            
        }

       
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter your year of study: ");
            //принимаем имя, айди и год студента
            Student student1 = new Student("Alima", "18BD11050")
            {
                Year = int.Parse(Console.ReadLine())
            };

            //выводим все данные
            Console.WriteLine("Student: " + student1.Name);
            Console.WriteLine("ID: " + student1.Id);
            Console.WriteLine("Year of sudy: " + student1.Year);
            //увеличиваем год студента, вызывая функцию
            student1.NextYear();
            //выводим измененные данные
            Console.WriteLine();
            Console.WriteLine("Student has progressed to the next year of study.");
            Console.WriteLine("Student: " + student1.Name);
            Console.WriteLine("ID: " + student1.Id);
            Console.WriteLine("Year of sudy: " + student1.Year);



        }
    }
}
