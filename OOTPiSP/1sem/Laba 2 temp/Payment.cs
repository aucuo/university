using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_2_temp
{
    internal class Payment
    {
        private string type, date;
        private int amount;
        public Payment(string type, int amount, string date) // с параметрами
        {
            Console.WriteLine("Конструктор с параметрами");
            this.type = type;
            this.amount = amount;
            this.date = date;
        }
        public Payment() // без параметров
        {
            Console.WriteLine("Конструктор без параметров");
            string type, date;
            int amount, n;

            Console.WriteLine("Выберите тип платежа (1. картой; 2. наличными):");
            do
                n = Program.GetInt();
            while (n < 1 || n > 2);
            if (n == 1)
                type = "Картой";
            else
                type = "Наличными";

            Console.WriteLine("Введите сумму:");
            do
                amount = Program.GetInt();
            while (amount > 1000 || amount < 1);
            Console.WriteLine("Введите дату:");
            do
                date = Program.GetDate();
            while (Convert.ToDateTime(date) > DateTime.Now || DateTime.Now.Year - Convert.ToDateTime(date).Year > 1);

            this.type = type;
            this.amount = amount;
            this.date = date;
        }
        public Payment(Payment payment) // копирования
        {
            Console.WriteLine("Конструктор копирования");
            this.type = payment.type;
            this.amount = payment.amount;

            Console.WriteLine("Введите дату:");
            do
                payment.date = Program.GetDate();
            while (Convert.ToDateTime(payment.date) > DateTime.Now || DateTime.Now.Year - Convert.ToDateTime(payment.date).Year > 1);
            this.date = payment.date;

        }
        ~Payment()
        {
            Console.WriteLine("Деструктор вызван");
        }
        public void ShowGrade()
        {
            Console.WriteLine("{0}\t{1}\t{2}", this.type, this.amount, this.date);
        }
        public bool IsExsist(string type, string date)
        {
            if (this.date == date && this.type == type)
                return true;
            return false;
        }
        public void EditPayment(int amount)
        {
            this.amount = amount;
        }
    }
}
