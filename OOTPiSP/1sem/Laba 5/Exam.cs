using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Exam : Grade
    {
        private string examName;
        private string examDifficulty;
        private string examDuration;
        public Exam(string name, string surname, string date, int grade, string examName, string examDifficulty, string examDuration) : base(name, surname, date, grade)
        {
            Console.WriteLine("Конструктор Exam с параметрами");
            this.examName = examName;
            this.examDifficulty = examDifficulty;
            this.examDuration = examDuration;
        }
        public Exam() : base()
        {
            Console.WriteLine("Конструктор Exam без параметров");
            this.examName = "examName";
            this.examDifficulty = "examDifficulty";
            this.examDuration = "examDuration";
        }
        public Exam(Exam exam) : base(exam)
        {
            Console.WriteLine("Конструктор Exam копирования");
            this.examName = exam.examName;
            this.examDifficulty = exam.examDifficulty;
            this.examDuration = exam.examDuration;
        }

        ~Exam() { Console.WriteLine("Деструктор Exam"); }
        public override void Print()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", base.name, base.surname, base.grade, this.examName, this.examDuration, this.examDifficulty, base.date);
        }
    }
}