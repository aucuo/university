using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3
{
    internal class Exam : Grade
    {
        private string examName, examDifficulty, examDuration; // examDifficulty - сложность, examDuration - длительность

        public Exam(string name, string surname, int grade, string date, string examName, string examDifficulty, string examDuration) : base(name, surname, grade, date)
        {
            Console.WriteLine("Конструктор Exam с параметрами");
            this.examName = examName;
            this.examDifficulty = examDifficulty;
            this.examDuration = examDuration;
        }

        public Exam() : base()
        {
            Console.WriteLine("Конструктор Exam без параметров");
            this.examName = "РПИ";
            this.examDifficulty = "Легкий";
            this.examDuration = "120 мин.";
        }

        public Exam(Exam exam) : base(exam)
        {
            Console.WriteLine("Конструктор Exam копирования");
            this.examName = exam.examName;
            this.examDifficulty = exam.examDifficulty;
            this.examDuration = exam.examDuration;
        }

        ~Exam()
        {
            Console.WriteLine("Деструктор Exam");
        }

        public void Print()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", base.name, base.surname, base.grade, this.examName, this.examDuration, this.examDifficulty, base.date);
        }
    }
}
