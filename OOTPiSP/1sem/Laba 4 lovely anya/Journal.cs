using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentJournal
{
    internal class Journal
    {
        private string card;
        private string name;
        public string Name { get { return name; } }
        List<Payment> payments = new List<Payment>();
        public Journal(string card, string name)
        {
            this.card = card;
            this.name = name;
        }
        public void Print() { Console.WriteLine("{0}\t{1}", card, name); } // Вывод информации о журнале
        public void PrintPayments() { foreach (Payment p in payments) p.Print(); } // Вывод информации о платежах
        public void Add()
        {
            (int, string, string, string) data;
            switch (Check.GetPaymentType())
            {
                case 1: // Доход
                    switch (Check.GetConstructorOption())
                    {
                        case 1: // Конструктор с параметрами
                            data = Check.GetIncomeData();
                            payments.Add(new Income(data.Item1, data.Item2, data.Item3, data.Item4));
                            break;
                        case 2: // Конструктор без параметров
                            payments.Add(new Income());
                            break;
                        case 3: // Конструктор копирования
                            data = Check.GetIncomeData();
                            int copies = Check.GetInt(1, 4, "Сколько делать копий? (1-4)");
                            for (int i = 0; i < copies; i++)
                                payments.Add(new Income(new Income(data.Item1, data.Item2, data.Item3, data.Item4)));
                            break;
                    }
                    break;
                case 2: // Расход
                    switch (Check.GetConstructorOption())
                    {
                        case 1: // Конструктор с параметрами
                            data = Check.GetExpenseData();
                            payments.Add(new Expense(data.Item1, data.Item2, data.Item3, data.Item4));
                            break;
                        case 2: // Конструктор без параметров
                            payments.Add(new Expense());
                            break;
                        case 3: // Конструктор копирования
                            data = Check.GetExpenseData();
                            int copies = Check.GetInt(1, 4, "Сколько делать копий? (1-4)");
                            for (int i = 0; i < copies; i++)
                                payments.Add(new Expense(new Expense(data.Item1, data.Item2, data.Item3, data.Item4)));
                            break;
                    }
                    break;
            }
        }
        public void Edit()
        {
            var payment = Check.GetPayment(payments);
            payments.RemoveAll(c => c == payment);

            if (payment != null)
            {
                (int, string, string, string) data;
                switch (Check.GetPaymentType())
                {
                    case 1: // Доход
                        data = Check.GetIncomeData();
                        payments.Add(new Income(data.Item1, data.Item2, data.Item3, data.Item4));
                        break;
                    case 2: // Расход
                        data = Check.GetExpenseData();
                        payments.Add(new Expense(data.Item1, data.Item2, data.Item3, data.Item4));
                        break;
                }
            }
        }
        public void Delete()
        {
            var lesson = Check.GetPayment(payments);
            payments.RemoveAll(c => c == lesson);
            
            if (lesson != null)
            {
                Console.Clear();
                Console.WriteLine("Платеж удален!");
            }
        }
    }
}
