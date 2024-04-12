using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3
{
    internal class Grade
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
            Console.WriteLine("Оценка удалена");
        }
        public void Print()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", this.name, this.surname, this.grade, this.date, this is Exam ? "Экзамен" : (this is Credit ? "Зачет" : ""));
        }
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
