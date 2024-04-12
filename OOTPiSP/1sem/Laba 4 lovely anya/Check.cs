using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PaymentJournal
{
    internal class Check
    {
        static public int GetInt()
        {
            int n;
            string str;

            do
                str = Console.ReadLine();
            while (!int.TryParse(str, out n));

            n = Convert.ToInt16(str);

            return n;
        }

        static public int GetInt(int a, int b)
        {
            int n;
            string str;

            do
                str = Console.ReadLine();
            while (!int.TryParse(str, out n) || Convert.ToInt16(str) < a || Convert.ToInt16(str) > b);

            n = Convert.ToInt16(str);

            return n;
        }

        static public int GetInt(string text)
        {
            int n;
            string str;

            Console.WriteLine(text);

            do
                str = Console.ReadLine();
            while (!int.TryParse(str, out n));

            n = Convert.ToInt16(str);

            return n;
        }

        static public int GetInt(int a, int b, string text)
        {
            int n;
            string str;

            Console.WriteLine(text);

            do
                str = Console.ReadLine();
            while (!int.TryParse(str, out n));

            n = Convert.ToInt16(str);

            if (n < a || n > b) GetInt(a, b);

            return n;
        }

        static public string GetDate(string text)
        {
            Console.WriteLine(text);
            string date;

            do
            {
                date = Console.ReadLine();
                if (date == "")
                {
                    date = DateTime.Now.ToString("dd.MM.yyyy");
                    Console.Write(date + "\n");
                }
            } while (!DateTime.TryParse(date, out DateTime dt) || Convert.ToDateTime(date) > DateTime.Now || DateTime.Now.Year - Convert.ToDateTime(date).Year > 11);

            return date;
        }
        static public string GetCard(string text)
        {
            string card;
            Console.WriteLine(text);

            do
                card = Console.ReadLine();
            while (!card.All(char.IsDigit) || card.Length != 4);

            return card;
        }

        static public string GetName(string text)
        {
            string name;

            Console.WriteLine(text);

            do
                name = Console.ReadLine();
            while (name.Any(char.IsDigit) || name.Length < 2 || name.Length > 20);
            return name;
        }
        static public string GetAddress(string text)
        {
            string addr;

            Console.WriteLine(text);

            do
                addr = Console.ReadLine();
            while (addr.Length < 2 || addr.Length > 30);
            return addr;
        }
        static public string GetTime(string text)
        {
            string time;
            Regex regex = new Regex(@"^\d{1,2}:\d{2}$"); // ЧЧ:ММ

            Console.WriteLine(text);

            do
                time = Console.ReadLine();
            while (!regex.IsMatch(time));
            return time;
        }
        static public Journal? GetJournal(List<Journal> journals)
        {
            int op;
            int counter = 1;

            if (journals.Count == 0) // Проверка на пустоту
            {
                Console.Clear();
                Console.WriteLine("Журналы отсутствуют!");
                return null;
            }

            foreach (Journal j in journals)
            {
                Console.Write(counter++ + ". ");
                j.Print();
            }

            op = GetInt("Выберите журнал");

            Journal? journalReturn;
            journalReturn = op - 1 >= 0 && op - 1 < journals.Count
                    ? journals[op - 1]
                    : null;

            Console.Clear();
            if (journalReturn == null) Console.WriteLine("Такого журнала нет!");

            return journalReturn;
        }
        static public Payment? GetPayment(List<Payment> payments)
        {
            string op;
            int counter = 1;

            if (payments.Count == 0) // Проверка на пустоту
            {
                Console.Clear();
                Console.WriteLine("Платежей нет!");
                return null;
            }

            foreach (Payment p in payments)
            {
                Console.Write(counter++ + ". ");
                p.Print();
            }

            Console.WriteLine("Введите номер платежа");
            while (string.IsNullOrEmpty(op = Console.ReadLine().Trim())) ; // Ввод исключающий пустое значение

            Payment? paymentReturn;
            paymentReturn = Convert.ToInt16(op) - 1 >= 0 && Convert.ToInt16(op) - 1 < payments.Count
                    ? payments[Convert.ToInt16(op) - 1]
                    : null;

            Console.Clear();
            if (paymentReturn == null) Console.WriteLine("Такого платежа нет!");

            return paymentReturn;
        }
        static public int GetConstructorOption()
        {
            int op;
            Console.WriteLine(
                            "\nВыберите тип конструктора:\n" +
                            "1. Конструктор с параметрами\n" +
                            "2. Конструктор без параметров\n" +
                            "3. Конструктор копирования\n");
            op = Check.GetInt(1, 3);
            return op;
        }
        static public string GetCategory()
        {
            string[] category =
            {
                "Еда",
                "Дом",
                "Отдых",
                "Спорт",
                "Гигиена",
                "Жилье"
            };
            int op;
            Console.WriteLine(
                            "\nВыберите категорию платежа:\n" +
                            "1. Еда\n" +
                            "2. Дом\n" +
                            "3. Отдых\n" +
                            "4. Спорт\n" +
                            "5. Гигиена\n" +
                            "6. Жилье\n");
            op = Check.GetInt(1, 6);
            return category[op];
        }
        static public int GetPaymentType()
        {
            int op;
            Console.WriteLine(
                            "\nВыберите тип занятия:\n" +
                            "1. Доход\n" +
                            "2. Расход");
            op = Check.GetInt(1, 2);
            return op;
        }
        static public (int, string, string, string) GetIncomeData()
        {
            int  paymentAmount = Check.GetInt(1, 10000, "Введите сумму дохода (макс. 10000)");
            string  paymentDate = Check.GetDate("Введите дату");
            string  source = Check.GetName("Введите источник платежа");
            string  message = Check.GetName("Введите краткое сообщение к платежу");
            return (paymentAmount, paymentDate, source, message);
        }
        static public (int, string, string, string) GetExpenseData()
        {
            int paymentAmount = Check.GetInt(1, 10000, "Введите сумму расхода (макс. 10000)");
            string paymentDate = Check.GetDate("Введите дату");
            string category = Check.GetCategory();
            string recipient = Check.GetName("Введите получателя");
            return (paymentAmount, paymentDate, category, recipient);
        }
    }
}
