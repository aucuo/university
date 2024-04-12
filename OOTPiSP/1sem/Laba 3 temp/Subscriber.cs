using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3_temp
{
    internal class Subscriber
    {
        private string name;
        List<Payment> payments = new List<Payment>();

        public string Name { get { return name; } }

        public Subscriber(string name)
        {
            this.name = name;
        }
        public void AddPayment(string type, int amount, string date)
        {
            if (type == "Картой")
            {
                payments.Add(new Card(amount, date));
            }
            else if (type == "Наличными")
            {
                payments.Add(new Cash(amount, date));
            }
        }
        public void AddPayment()
        {
            int n;
            Console.WriteLine("Выберите тип платежа (1. картой; 2. наличными):");
            n = Check.ReadInt(1, 2);

            if (n == 1) // Картой
            {
                payments.Add(new Card());
            }
            else if (n == 2) // Наличными
            {
                payments.Add(new Cash());
            }
        }
        public void CopyPayments(int count)
        {
            int n, amount;
            string date;

            Console.WriteLine("Введите сумму платежа:");
            amount = Check.ReadInt(1, 1000);

            Console.WriteLine("Введите дату:");
            date = Check.ReadDate();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Выберите тип платежа (1. картой; 2. наличными):");
                n = Check.ReadInt(1, 2);

                if (n == 1) // Картой
                {
                    payments.Add(new Card(new Card(amount, date)));
                }
                else if (n == 2) // Наличными
                {
                    payments.Add(new Cash(new Cash(amount, date)));
                }
            }
        }
        public void EditPayment()
        {
            string date, type;
            int n, amount;

            Console.WriteLine("Выберите тип платежа (1. картой; 2. наличными):");
            n = Check.ReadInt(1, 2);

            Console.WriteLine("Введите дату:");
            date = Check.ReadDate();

            Console.WriteLine("Введите сумму платежа:");
            amount = Check.ReadInt(1, 1000);

            switch (n)
            {
                case 1: // Карта
                    string cardNum;
                    Console.WriteLine("Введите последние 4 цифры номера карты:");
                    do
                        cardNum = Console.ReadLine();
                    while (!cardNum.All(char.IsDigit) || cardNum.Length != 4);
                    for (int i = 0; i < payments.Count; i++)
                    {
                        if (payments[i].GetType() == typeof(Card))
                        {
                            if ((payments[i] as Card).CardNum == cardNum && payments[i].Amount == amount && payments[i].Date == date)
                            {
                                payments.RemoveAt(i);
                                Console.WriteLine("Ввод новых данных для платежа...");
                                type = Check.GetPaymentType();

                                Console.WriteLine("Введите сумму платежа:");
                                amount = Check.ReadInt(1, 1000);

                                Console.WriteLine("Введите дату:");
                                date = Check.ReadDate();

                                this.AddPayment(type, amount, date);
                                return;
                            }
                        }
                    }
                    break;
                case 2: // Наличными
                    string issuer;

                    Console.WriteLine("Введите имя того, кто выдал наличные:");
                    issuer = Check.ReadName();

                    for (int i = 0; i < payments.Count; i++)
                    {
                        if (payments[i].GetType() == typeof(Cash))
                        {
                            if ((payments[i] as Cash).Issuer == issuer && payments[i].Amount == amount && payments[i].Date == date)
                            {
                                payments.RemoveAt(i);
                                Console.WriteLine("Ввод новых данных для платежа...");
                                type = Check.GetPaymentType();


                                Console.WriteLine("Введите сумму платежа:");
                                amount = Check.ReadInt(1, 1000);

                                Console.WriteLine("Введите дату:");
                                date = Check.ReadDate();

                                this.AddPayment(type, amount, date);
                                return;
                            }
                        }
                    }
                    break;
            }
            Console.WriteLine("Платеж не найден");
        }
        public void DeletePayment()
        {
            string date;
            int amount;
            int n;

            Console.WriteLine("Выберите тип платежа (1. картой; 2. наличными):");
            n = Check.ReadInt(1, 2);

            Console.WriteLine("Введите дату:");
            date = Check.ReadDate();

            Console.WriteLine("Введите сумму платежа:");
            amount = Check.ReadInt(1, 1000);

            switch (n)
            {
                case 1: // Карта
                    string cardNum;
                    Console.WriteLine("Введите последние 4 цифры номера карты:");
                    cardNum = Check.ReadCardNum();

                    for (int i = 0; i < payments.Count; i++)
                    {
                        if (payments[i].GetType() == typeof(Card))
                        {
                            if ((payments[i] as Card).CardNum == cardNum && payments[i].Amount == amount && payments[i].Date == date)
                            {
                                payments.RemoveAt(i);
                                Console.WriteLine("Платеж удален");
                                return;
                            }
                        }
                    }
                    break;
                case 2: // Наличными
                    string issuer;

                    Console.WriteLine("Введите имя того, кто выдал наличные:");
                    do
                        issuer = Console.ReadLine();
                    while (!issuer.All(char.IsLetter) || issuer.Length > 20);

                    for (int i = 0; i < payments.Count; i++)
                    {
                        if (payments[i].GetType() == typeof(Cash))
                        {
                            if ((payments[i] as Cash).Issuer == issuer && payments[i].Amount == amount && payments[i].Date == date)
                            {
                                payments.RemoveAt(i);
                                Console.WriteLine("Платеж удален");
                                return;
                            }
                        }
                    }
                    break;
            }
            Console.WriteLine("Платеж не найден");
        }
        public void ShowPayments(int n) // Перегрузка
        {

            switch (n)
            {
                case 1: // Карта
                    Console.WriteLine("Платежи по карте (" + this.Name +")");

                    foreach (Payment payment in payments)
                    {
                        if (payment.GetType() == typeof(Card))
                        {
                            payment.Print();
                        }
                    }
                    break;
                case 2: // Наличными
                    Console.WriteLine("Платежи наличными (" + this.Name + ")");

                    foreach (Payment payment in payments)
                    {
                        if (payment.GetType() == typeof(Cash))
                        {
                            payment.Print();
                        }
                    }
                    break;
                case 3: // Все платежи
                    Console.WriteLine("Все платежи (" + this.Name + ")");

                    foreach (Payment payment in payments)
                    {
                        payment.Print();
                    }
                    break;
            }
        }
    }
}
