using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Credit : Grade
    {
        private string creditName;
        private string creditStatus;
        private string creditType;
        public string CreditName { get { return creditName; } }
        public Credit(string name, string surname, string date, int grade, string examName, string examDifficulty, string examDuration) : base(name, surname, date, grade)
        {
            Console.WriteLine("Конструктор Credit с параметрами");
            this.creditName = examName;
            this.creditStatus = examDifficulty;
            this.creditType = examDuration;
        }
        public Credit() : base()
        {
            Console.WriteLine("Конструктор Credit без параметров");
            this.creditName = "creditName";
            this.creditStatus = "creditStatus";
            this.creditType = "creditType";
        }
        public Credit(Credit credit) : base(credit)
        {
            Console.WriteLine("Конструктор Credit копирования");
            this.creditName = credit.creditName;
            this.creditStatus = credit.creditStatus;
            this.creditType = credit.creditType;
        }
        ~Credit() { Console.WriteLine("Деструктор Credit"); }
        public override void Print()
        {
            Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\n", base.name, base.surname, base.grade, this.creditName, this.creditType, this.creditStatus, base.date);
        }
    }
}