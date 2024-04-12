using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentJournal
{
    internal class Expense : Payment
    {
        private string category; // категория
        private string recipient; // получатель
        public Expense(int amount, string date, string category, string recipient) : base(amount, date)
        {
            Console.WriteLine("Конструктор Expense с параметрами");
            this.category = category;
            this.recipient = recipient;
        }
        public Expense() : base()
        {
            Console.WriteLine("Конструктор Expense без параметров");
            this.category = "Еда";
            this.recipient = "Магазин \"Маяк\"";
        }

        public Expense(Expense exp) : base(exp)
        {
            Console.WriteLine("Конструктор Expense копирования");
            this.category = exp.category;
            this.recipient = exp.recipient;
        }
        ~Expense() { Console.WriteLine("Деструктор Expense"); }
        public override void Print()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", "Расход", base.amount, base.date, category, recipient);
        }
    }
}