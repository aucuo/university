using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PaymentJournal
{
    internal class Journal
    {
        private string card;
        private string name;
        List<Payment> payments = new List<Payment>();
        public string Name { get { return name; } }
        public Journal(string card, string name)
        {
            this.card = card;
            this.name = name;
        }
        public void Print() { Console.WriteLine("{0}\t{1}", card, name); } // Вывод информации о журнале
        public void PrintPayments() // Вывод информации о платежах
        { 
            for (int i = 0; i < payments.Count; i++)
            {
                Console.Write(i + ". ");
                payments[i].Print();
            }
        } 
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

            if (payment != (object)null)
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
            
            if (lesson != (object)null)
            {
                Console.Clear();
                Console.WriteLine("Платеж удален!");
            }
        }

        // Перегрузка операторов
        public static Journal? operator +(Journal journal, Payment payment) // a + b
        {
            journal.payments.Add(payment);
            return journal;
        }
        public static Journal? operator ++(Journal journal) // ++a
        {
            journal.payments.Insert(0, Check.OperatorPP()); // Добавляем новый объект в начало списка
            return journal;
        }
        public Payment? this[int index] // []
        {
            get
            {
                if (index >= payments.Count || index < 0) return null;
                return payments[index];
            }
            set
            {
                payments[index] = value;
            }
        }
        public static Journal? operator <<(Journal journal, int index)
        {
            if (journal?[index] == (object?)null)
                return null;

            journal[index]?.Print();
            return journal;
        }
    }
}
