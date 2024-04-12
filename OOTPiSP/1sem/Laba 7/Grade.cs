using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    abstract internal class Grade
    {
        protected string name;
        protected string surname;
        protected string date;
        protected int grade;
        public int Mark { get { return grade; } set { grade = value; } }
        public Grade(string name, string surname, string date, int grade) // с параметрами
        {
            Console.WriteLine("Конструктор Grade с параметрами");
            this.name = name;
            this.surname = surname;
            this.date = date;
            this.grade = grade;
        }
        public Grade() // без параметров
        {
            Console.WriteLine("Конструктор Grade без параметров");
            this.name = "name";
            this.surname = "day";
            this.date = "date";
            this.grade = 10;
        }
        public Grade(Grade grade) // копирования
        {
            Console.WriteLine("Конструктор Grade копирования");
            this.name = grade.name;
            this.surname = grade.surname;
            this.date = grade.date;
            this.grade = grade.grade;
        }
        ~Grade() { Console.WriteLine("Деструктор Grade"); } // деструктор
        public abstract void Print(); // абстрактный метод
        public static bool operator <(Grade left, Grade right)
        {
            if (left == (object?)null || right == (object?)null) return false;
            return left.Mark < right.Mark;
        }
        public static bool operator >(Grade left, Grade right)
        {
            if (left == (object?)null || right == (object?)null) return false;
            return left.Mark > right.Mark;
        }
        public static bool operator ==(Grade left, Grade right)
        {
            return left.Mark == right.Mark;
        }
        public static bool operator !=(Grade left, Grade right)
        {
            if (left == (object)null || right == (object)null) return false;
            return left.Mark != right.Mark;
        }
    }
}
