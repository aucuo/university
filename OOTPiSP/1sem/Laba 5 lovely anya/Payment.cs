using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PaymentJournal
{
    abstract internal class Payment
    {
        protected int amount;
        protected string date;
        public int Amount { get { return amount; } }

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

        // Перегрузка операторов
        public static bool operator <(Payment left, Payment right)
        {
            if (left == (object)null || right == (object)null) return false;
            return left.Amount < right.Amount;
        }
        public static bool operator >(Payment left, Payment right)
        {
            if (left == (object)null || right == (object)null) return false;
            return left.Amount > right.Amount;
        }
        public static bool operator ==(Payment left, Payment right)
        {
            if (left == (object)null || right == (object)null) return false;
            return left.Amount == right.Amount;
        }
        public static bool operator !=(Payment left, Payment right)
        {
            if (left == (object)null || right == (object)null) return false;
            return left.Amount != right.Amount;
        }
    }
}
