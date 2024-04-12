using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laba_3_temp
{
    abstract internal class Payment
    {
        private string date;
        private int amount;
        public string Date { get { return date; } }
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

            this.amount = 10;
            this.date = "28.03.2023";
        }
        public Payment(Payment payment) // копирования
        {
            Console.WriteLine("Конструктор Payment копирования");

            this.amount = payment.amount;
            this.date = payment.date;
        }
        ~Payment()
        {
            Console.WriteLine("Деструктор Payment вызван");
        }
        public abstract void Print();
    }
}
