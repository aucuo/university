using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4
{
    class Credit : Grade
    {
        private string creditName, creditStatus, creditType; // creditStatus - зачет/незачет, creditType - диф/обычный

        public Credit(string name, string surname, int grade, string date, string creditName, string creditStatus, string creditType) 
            : base(name, surname, grade, date)
        {
            Console.WriteLine("Конструктор Credit с параметрами");
            this.creditName = creditName;
            this.creditStatus = creditStatus;
            this.creditType = creditType;
        }

        public Credit() : base()
        {
            Console.WriteLine("Конструктор Exam без параметров");
            this.creditName = "Английский";
            this.creditStatus = "Зачтено";
            this.creditType = "Обычный зачет";
        }

        public Credit(Credit credit) : base(credit)
        {
            Console.WriteLine("Конструктор Exam копирования");
            this.creditName = credit.creditName;
            this.creditStatus = credit.creditStatus;
            this.creditType = credit.creditType;
        }

        ~Credit()
        {
            Console.WriteLine("Деструктор Exam");
        }

        public override void Print()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", base.name, base.surname, base.grade, this.creditName, this.creditStatus, this.creditType, base.date);
        }
    }
}
