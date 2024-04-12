using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentJournal
{
    abstract internal class Payment
    {
        protected int amount;
        protected string date;
        public Payment(int amount, string date) // с параметрами
        {
            Console.WriteLine("Конструктор Payment с параметрами");
            this.amount = amount;
            this.date = date;
        }
        public Payment() // без параметров
        {
            Console.WriteLine("Конструктор Payment без параметров");
            this.amount = 100;
            this.date = DateTime.Now.ToString("dd.MM.yyyy"); ;
        }
        public Payment(Payment payment) // копирования
        {
            Console.WriteLine("Конструктор Payment копирования");
            this.amount = payment.amount;
            this.date = payment.date;
        }
        ~Payment() { Console.WriteLine("Деструктор Payment"); } // деструктор
        public abstract void Print(); // абстрактный метод
    }
}
