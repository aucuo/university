using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (paymentReturn == (object)null) Console.WriteLine("Такого платежа нет!");

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
        static public char GetChar()
        {
            string @char;

            do
            {
                @char = Console.ReadLine();
                if (@char == "") return (char)0;
            }
            while (@char.Any(char.IsDigit) || @char.Length != 1);
            return Convert.ToChar(@char);
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

        // Для перегрузки операторов
        public static Payment? OperatorP()
        {
            Payment? payment = null;
            (int, string, string, string) data;

            switch (Check.GetPaymentType())
            {
                case 1: // Доход
                    data = Check.GetIncomeData();
                    payment = new Income(data.Item1, data.Item2, data.Item3, data.Item4);
                    break;
                case 2: // Расход
                    data = Check.GetExpenseData();
                    payment = new Expense(data.Item1, data.Item2, data.Item3, data.Item4);
                    break;
            }
            return payment;
        }
        public static Payment? OperatorPP()
        {
            Payment? payment = null;

            switch (Check.GetPaymentType())
            {
                case 1: // Доход
                    payment = new Income();
                    break;
                case 2: // Расход
                    payment = new Expense();
                    break;
            }
            return payment;
        }
        // Для шаблона

        public static Blueprint<Expense> ExpenseTemplate(Blueprint<Expense> expenseTemplate)
        {
            Console.Clear();
            Console.WriteLine("\nШаблон для расхода (expense)");
            Console.WriteLine("1. Добавление");
            Console.WriteLine("2. Просмотр");
            Console.WriteLine("3. Сортировка");
            Console.WriteLine("4. Найти элемент");
            Console.WriteLine("5. Min");
            Console.WriteLine("6. Max");
            Console.WriteLine("0. Выход");

            int n = Check.GetInt(0, 6);
            Console.Clear();

            switch (n)
            {
                case 1: // Добавление
                    (int, string, string, string) data;

                    do
                    {
                        data = Check.GetExpenseData();
                        expenseTemplate.AddElement(expenseTemplate.Length, new Expense(data.Item1, data.Item2, data.Item3, data.Item4));
                        Console.WriteLine("В шаблоне сейчас {0} элемента(-ов)", expenseTemplate.Length);
                        n = Check.GetInt(1, 2, "Добавить еще один расход? (1. да; 2. нет)");
                    } while (n != 2);
                    break;
                case 2: // Просмотр
                    for (int i = 0; i < expenseTemplate.Length; i++)
                    {
                        expenseTemplate.GetElement(i)?.Print();
                    }
                    Console.WriteLine();
                    break;
                case 3: // Сортировка
                    expenseTemplate.Sort();
                    break;
                case 4: // Найти элемент
                    int payment = Check.GetInt(1, 10000, "Введите сумму для нахождения (1-10000)");
                    var temp = new Expense();
                    temp.Amount = payment;

                    var index = expenseTemplate.FindItem(temp);
                    Console.Clear();

                    if (index != -1) Console.WriteLine("Найден элемент с индексом: [{0}]", index);
                    else Console.WriteLine("Элемент не найден");
                    break;
                case 5: // Min
                    Console.WriteLine("Наименьший платеж:" + expenseTemplate.Min().Amount);
                    break;
                case 6: // Max
                    Console.WriteLine("Наибольший платеж:" + expenseTemplate.Max().Amount);
                    break;
                case 0:
                    return expenseTemplate;
            }
            return expenseTemplate;
        }
        public static Blueprint<Income> IncomeTemplate(Blueprint<Income> incomeTemplate)
        {
            Console.Clear();
            Console.WriteLine("\nШаблон для дохода (income)");
            Console.WriteLine("1. Добавление");
            Console.WriteLine("2. Просмотр");
            Console.WriteLine("3. Сортировка");
            Console.WriteLine("4. Найти элемент");
            Console.WriteLine("5. Min");
            Console.WriteLine("6. Max");
            Console.WriteLine("0. Выход");

            int n = Check.GetInt(0, 6);
            Console.Clear();

            switch (n)
            {
                case 1: // Добавление
                    (int, string, string, string) data;

                    do
                    {
                        data = Check.GetIncomeData();
                        incomeTemplate.AddElement(incomeTemplate.Length, new Income(data.Item1, data.Item2, data.Item3, data.Item4));
                        Console.WriteLine("В шаблоне сейчас {0} элемента(-ов)", incomeTemplate.Length);
                        n = Check.GetInt(1, 2, "Добавить еще один расход? (1. да; 2. нет)");
                    } while (n != 2);
                    break;
                case 2: // Просмотр
                    for (int i = 0; i < incomeTemplate.Length; i++)
                    {
                        incomeTemplate.GetElement(i)?.Print();
                    }
                    Console.WriteLine();
                    break;
                case 3: // Сортировка
                    incomeTemplate.Sort();
                    break;
                case 4: // Найти элемент
                    int payment = Check.GetInt(1, 10000, "Введите сумму для нахождения (1-10000)");
                    var temp = new Income();
                    temp.Amount = payment;

                    var index = incomeTemplate.FindItem(temp);
                    Console.Clear();

                    if (index != -1) Console.WriteLine("Найден элемент с индексом: [{0}]", index);
                    else Console.WriteLine("Элемент не найден");
                    break;
                case 5: // Min
                    Console.WriteLine("Наименьший платеж:" + incomeTemplate.Min().Amount);
                    break;
                case 6: // Max
                    Console.WriteLine("Наибольший платеж:" + incomeTemplate.Max().Amount);
                    break;
                case 0:
                    return incomeTemplate;
            }
            return incomeTemplate;
        }
        public static Blueprint<char> CharTemplate(Blueprint<char> charTemplate)
        {
            Console.Clear();
            Console.WriteLine("\nШаблон для char");
            Console.WriteLine("1. Добавление");
            Console.WriteLine("2. Просмотр");
            Console.WriteLine("3. Сортировка");
            Console.WriteLine("4. Найти элемент");
            Console.WriteLine("5. Min");
            Console.WriteLine("6. Max");
            Console.WriteLine("0. Выход");

            int n = Check.GetInt(0, 6);
            Console.Clear();

            switch (n)
            {
                case 1: // Добавление
                    char charVal;

                    Console.WriteLine("Вводите значения для элементов массива (enter для выхода):");
                    do
                    {
                        charVal = Check.GetChar();
                        if (charVal >= 0)
                            charTemplate.AddElement(charTemplate.Length, charVal);
                    } while (charVal != 0);
                    break;
                case 2: // Просмотр
                    for (int i = 0; i < charTemplate.Length; i++)
                    {
                        Console.Write(charTemplate.GetElement(i) + " ");
                    }
                    Console.WriteLine();
                    break;
                case 3: // Сортировка
                    charTemplate.Sort();
                    break;
                case 4: // Найти элемент
                    Console.WriteLine("Введите значение элемента");
                    charVal = Check.GetChar();
                    var index = charTemplate.FindItem(charVal);
                    if (index != -1) Console.WriteLine("Найден элемент с индексом: [{0}]", index);
                    else Console.WriteLine("Элемент не найден");
                    break;
                case 5: // Min
                    Console.WriteLine(charTemplate.Min());
                    break;
                case 6: // Max
                    Console.WriteLine(charTemplate.Max());
                    break;
                case 0:
                    return charTemplate;
            }
            return charTemplate;
        }
        public static Blueprint<int> IntTemplate(Blueprint<int> intTemplate)
        {
            Console.Clear();
            Console.WriteLine("\nШаблон для int");
            Console.WriteLine("1. Добавление");
            Console.WriteLine("2. Просмотр");
            Console.WriteLine("3. Сортировка");
            Console.WriteLine("4. Найти элемент");
            Console.WriteLine("5. Min");
            Console.WriteLine("6. Max");
            Console.WriteLine("0. Выход");

            int n = Check.GetInt(0, 6);
            Console.Clear();

            switch (n)
            {
                case 1: // Добавление
                    int intVal;

                    Console.WriteLine("Вводите значения для элементов массива (-1 для выхода):");
                    do
                    {
                        intVal = Check.GetInt();
                        if (intVal >= 0)
                            intTemplate.AddElement(intTemplate.Length, intVal);
                    } while (intVal != -1);
                    break;
                case 2: // Просмотр
                    for (int i = 0; i < intTemplate.Length; i++)
                    {
                        Console.Write(intTemplate.GetElement(i) + " ");
                    }
                    Console.WriteLine();
                    break;
                case 3: // Сортировка
                    intTemplate.Sort();
                    break;
                case 4: // Найти элемент
                    Console.WriteLine("Введите значение элемента");
                    intVal = Check.GetInt();
                    var index = intTemplate.FindItem(intVal);
                    if (index != -1) Console.WriteLine("Найден элемент с индексом: [{0}]", index);
                    else Console.WriteLine("Элемент не найден");
                    break;
                case 5: // Min
                    Console.WriteLine(intTemplate.Min());
                    break;
                case 6: // Max
                    Console.WriteLine(intTemplate.Max());
                    break;
                case 0:
                    return intTemplate;
            }
            return intTemplate;
        }
    }
}
