using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml.Linq;


namespace Laba_2_temp
{
    internal class Program
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
        static public string GetDate()
        {
            string date;
            do
                date = Console.ReadLine();
            while (!DateTime.TryParse(date, out DateTime dt));

            return date;
        }
        private static void Main(string[] args)
        {
            string name, type, date;
            int id, amount;

            List<Subscriber> subscribers = new List<Subscriber>();

            int n = 1;

            while (n != 0)
            {
                Console.WriteLine("\nВыберите опцию:");
                Console.WriteLine("1. Добавить абонента");
                Console.WriteLine("2. Просмотреть абонентов");
                Console.WriteLine("3. Добавить платеж");
                Console.WriteLine("4. Редактировать платеж");
                Console.WriteLine("5. Удалить платеж");
                Console.WriteLine("6. Просмотреть платежи");
                Console.WriteLine("0. Выход");

                do
                    n = GetInt();
                while (n < 0 || n > 6);

                Console.Clear();

                switch (n)
                {
                    case 1:
                        Console.WriteLine("Введите имя абонента");
                        do
                            name = Console.ReadLine();
                        while (!name.All(char.IsLetter));
                        foreach (Subscriber sub in subscribers)
                        {
                            if (sub.IsExsist(name))
                            {
                                Console.WriteLine("Такой абонент уже есть! Введите другое имя!");
                                name = Console.ReadLine();
                            }
                        }
                        subscribers.Add(new Subscriber(name));
                        Console.Clear();
                        break;
                    case 2:
                        foreach (Subscriber sub in subscribers)
                        {
                            sub.ShowSubscribers();
                        }
                        break;
                    case 3: // Добавление
                        Console.WriteLine("Введите имя абонента");
                        do
                            name = Console.ReadLine();
                        while (!name.All(char.IsLetter));

                        Console.WriteLine("1. Конструктор с параметрами");
                        Console.WriteLine("2. Конструктор без параметров");
                        Console.WriteLine("3. Конструктор копирования");

                        do
                            n = GetInt();
                        while (n < 0 || n > 3);
                        Console.Clear();

                        switch (n)
                        {
                            case 1:
                                foreach (Subscriber sub in subscribers)
                                {
                                    if (sub.IsExsist(name))
                                    {
                                        Console.WriteLine("Выберите тип платежа (1. картой; 2. наличными):");
                                        do
                                            n = GetInt();
                                        while (n < 1 || n > 2);
                                        if (n == 1)
                                            type = "Картой";
                                        else
                                            type = "Наличными";

                                        Console.WriteLine("Введите сумму платежа:");
                                        do
                                            amount = GetInt();
                                        while (amount > 1000 || amount < 1);
                                        Console.WriteLine("Введите дату:");
                                        do
                                            date = GetDate();
                                        while (Convert.ToDateTime(date) > DateTime.Now || DateTime.Now.Year - Convert.ToDateTime(date).Year > 11);

                                        sub.AddPayment(type, amount, date);
                                    }
                                }
                                break;
                            case 2:
                                foreach (Subscriber sub in subscribers)
                                {
                                    if (sub.IsExsist(name))
                                    {
                                        sub.AddPayment();
                                    }
                                }
                                break;
                            case 3:
                                foreach (Subscriber sub in subscribers)
                                {
                                    if (sub.IsExsist(name))
                                    {
                                        int count;
                                        Console.WriteLine("Сколько сделать копий? (макс. 10)");
                                        do
                                            count = GetInt();
                                        while (count < 1 || count > 10);

                                        Console.WriteLine("Выберите тип платежа (1. картой; 2. наличными):");
                                        do
                                            n = GetInt();
                                        while (n < 1 || n > 2);
                                        if (n == 1)
                                            type = "Картой";
                                        else
                                            type = "Наличными";
                                        while (type.Any(char.IsDigit));
                                        Console.WriteLine("Введите сумму платежа:");
                                        do
                                            amount = GetInt();
                                        while (amount > 1000 || amount < 1);

                                        sub.CopyPayments(new Payment(type, amount, "temporary"), count);
                                    }
                                }
                                break;
                        }
                        break;
                    case 4: // Редактирование
                        Console.WriteLine("Введите имя абонента");
                        do
                            name = Console.ReadLine();
                        while (!name.All(char.IsLetter));

                        foreach (Subscriber sub in subscribers)
                        {
                            if (sub.IsExsist(name))
                            {
                                sub.EditPayment();
                            }
                        }
                        break;
                    case 5: // Удаление
                        Console.WriteLine("Введите имя абонента");
                        do
                            name = Console.ReadLine();
                        while (!name.All(char.IsLetter));

                        foreach (Subscriber sub in subscribers)
                        {
                            if (sub.IsExsist(name))
                            {
                                sub.DeletePayment();
                            }
                        }
                        break;
                    case 6: // Просмотр
                        Console.WriteLine("Введите имя абонента (либо нажмите Enter для просмотра всех платежей):");
                        do
                        {
                            name = Console.ReadLine();
                            if (name == "")
                                break;
                        }
                        while (!name.All(char.IsLetter));

                        if (name != "")
                        {
                            foreach (Subscriber sub in subscribers)
                            {
                                sub.ShowPayments(name);
                            }
                        }
                        else
                        {
                            for (id = 0; id < subscribers.Count; id++)
                            {
                                subscribers[id].ShowSubscribers();
                                subscribers[id].ShowPayments();
                            }
                        }

                        break;
                }
            }
        }
    }
}