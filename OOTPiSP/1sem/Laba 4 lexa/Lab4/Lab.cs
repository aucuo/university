using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Lab : Lesson
    {
        private int labNumber; // номер занятия
        private string supervisor; // преподаватель
        public Lab(string name, string day, string time, int labNumber, string supervisor) : base(name, day, time)
        {
            Console.WriteLine("Конструктор Lab с параметрами");
            this.labNumber = labNumber;
            this.supervisor = supervisor;
        }
        public Lab() : base()
        {
            Console.WriteLine("Конструктор Lab без параметров");
            this.labNumber = 1;
            this.supervisor = "supervisor";
        }

        public Lab(Lab lab) : base(lab)
        {
            Console.WriteLine("Конструктор Lab копирования");
            this.labNumber = lab.labNumber;
            this.supervisor = lab.supervisor;
        }
        ~Lab() { Console.WriteLine("Деструктор Lab"); }
        public override void Print()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", "Лаб.", base.name, base.day, base.time, labNumber, supervisor);
        }
    }
}