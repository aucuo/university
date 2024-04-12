using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentJournal
{
    internal class Income : Payment
    {
        private string source; // источник дохода
        private string message; // сообщение от отправителя
        public Income(int amount, string date, string source, string message) : base(amount, date)
        {
            Console.WriteLine("Конструктор Income с параметрами");
            this.source = source;
            this.message = message;
        }
        public Income() : base()
        {
            Console.WriteLine("Конструктор Income без параметров");
            this.source = "ООО \"МММ\"";
            this.message = "Карта";
        }

        public Income(Income inc) : base(inc)
        {
            Console.WriteLine("Конструктор Income копирования");
            this.source = inc.source;
            this.message = inc.message;
        }
        ~Income() { Console.WriteLine("Деструктор Income"); }
        public override void Print()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", "Доход", base.amount, base.date, source, message);
        }
    }
}