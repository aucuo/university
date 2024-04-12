using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4
{
    abstract internal class Grade
    {
        protected string name, surname, date;
        protected int grade;
        public Grade(string name, string surname, int grade, string date) // с параметрами
        {
            Console.WriteLine("Конструктор Grade с параметрами");
            this.name = name;
            this.surname = surname;
            this.grade = grade;
            this.date = date;
        }
        public Grade() // без параметров
        {
            Console.WriteLine("Конструктор Grade без параметров");
            
            this.name = "Иван";
            this.surname = "Иванов";
            this.grade = 9;
            this.date = "16.04.2023";
        }
        public Grade(Grade grade) // копирования
        {
            Console.WriteLine("Конструктор Grade копирования");
            this.name = grade.name;
            this.surname = grade.surname;
            this.grade = grade.grade;
            this.date = grade.date;

        }
        ~Grade()
        {
            Console.WriteLine("Деструктор Grade");
        }
        public abstract void Print();
        public bool IsExsist(string name, string surname, string date)
        {
            if (this.date == date && this.name == name && this.surname == surname)
                return true;
            return false;
        }
        public void EditGrade(int grade)
        {
            this.grade = grade;
        }
    }
}
