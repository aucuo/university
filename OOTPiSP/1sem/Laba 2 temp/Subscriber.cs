using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_2_temp
{
    internal class Subscriber
    {
        private string name;

        public Subscriber(string name)
        {
            this.name = name;
        }

        List<Payment> payments = new List<Payment>();

        public void ShowSubscribers()
        {
            Console.WriteLine(name);
        }
        public void AddPayment(string type, int amount, string date)
        {
            payments.Add(new Payment(type, amount, date));
        }
        public void AddPayment()
        {
            payments.Add(new Payment());
        }
        public void CopyPayments(Payment payment, int count)
        {
            for (int i = 0; i < count; i++)
            {
                payments.Add(new Payment(payment));
            }
        }
        public bool IsExsist(string name)
        {
            if (this.name == name)
                return true;
            return false;
        }
        public void ShowPayments(string name)
        {
            if (this.name != name)
                return;
            foreach (Payment payment in payments)
            {
                payment.ShowGrade();
            }
        }
        public void ShowPayments() // Перегрузка
        {
            foreach (Payment payment in payments)
            {
                payment.ShowGrade();
            }
        }
        public int GetPaymentsCount()
        {
            return payments.Count;
        }
        public void EditPayment()
        {
            string type, date;
            int amount, i = 0, n;

            Console.WriteLine("Выберите тип платежа (1. картой; 2. наличными):");
            do
                n = Program.GetInt();
            while (n < 1 || n > 2);
            if (n == 1)
                type = "Картой";
            else
                type = "Наличными";
            Console.WriteLine("Введите дату:");
            date = Program.GetDate();

            foreach (Payment payment in payments)
            {
                if (payment.IsExsist(type, date))
                {
                    Console.WriteLine("Введите новую сумму платежа для " + this.name + ":");
                    do
                        amount = Program.GetInt();
                    while (amount > 1000 || amount < 1);

                    payments[i].EditPayment(amount);
                    Console.WriteLine("Платеж изменен");
                    return;
                }
                i++;
            }
            Console.WriteLine("Платеж не найден");
        }
        public void DeletePayment()
        {
            string type, date;
            int i = 0, n;

            Console.WriteLine("Выберите тип платежа (1. картой; 2. наличными):");
            do
                n = Program.GetInt();
            while (n < 1 || n > 2);
            if (n == 1)
                type = "Картой";
            else
                type = "Наличными";
            Console.WriteLine("Введите дату:");
            date = Program.GetDate();

            foreach (Payment payment in payments)
            {
                if (payment.IsExsist(type, date))
                {
                    GC.Collect();
                    payments.RemoveAt(i);
                    Console.WriteLine("Платеж удален!");
                    return;
                }
                i++;
            }
            Console.WriteLine("Платеж не найден!");
        }
    }
}
