using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    abstract internal class Lesson
    {
        protected string name;
        protected string day;
        protected string time;
        public Lesson(string name, string day, string time) // с параметрами
        {
            Console.WriteLine("Конструктор Lesson с параметрами");
            this.name = name;
            this.day = day;
            this.time = time;
        }
        public Lesson() // без параметров
        {
            Console.WriteLine("Конструктор Lesson без параметров");
            this.name = "Lesson.name";
            this.day = "Lesson.day";
            this.time = "Lesson.time";
        }
        public Lesson(Lesson lesson) // копирования
        {
            Console.WriteLine("Конструктор Lesson копирования");
            this.name = lesson.name;
            this.day = lesson.day;
            this.time = lesson.time;
        }
        ~Lesson() { Console.WriteLine("Деструктор Lesson"); } // деструктор
        public abstract void Print(); // абстрактный метод
    }
}
