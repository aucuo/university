using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Laba_3_temp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string name;
            string type;
            string date;
            int amount;

            List<Subscriber> subscribers = new List<Subscriber>();

            int n = 1;

            while (n != 0)
            {
            Menu: // Label для возврата
                Console.WriteLine(
                    "\nВыберите опцию:\n" +
                    "1. Добавить абонента\n" +
                    "2. Просмотреть абонентов\n" +
                    "3. Добавить платеж\n" +
                    "4. Редактировать платеж\n" +
                    "5. Удалить платеж\n" +
                    "6. Просмотреть платежи\n" +
                    "0. Выход\n");

                n = Check.ReadInt(0, 6);

                Console.Clear();

                switch (n)
                {
                    case 1:
                        Console.WriteLine("Введите имя абонента");
                        name = Check.ReadName();

                        Console.Clear();

                        if (Check.GetSub(subscribers, name) != null)
                        {
                            Console.WriteLine("Такой абонент уже есть!");
                            break;
                        }
                        subscribers.Add(new Subscriber(name));
                        break;
                    case 2:
                        if (subscribers.Count == 0)
                        {
                            Console.WriteLine("Вы еще не добавили абонентов!");
                            goto Menu;
                        }

                        foreach (Subscriber sub in subscribers)
                        {
                            Console.WriteLine(sub.Name);
                        }
                        break;
                    case 3: // Добавление
                        if (subscribers.Count == 0)
                        {
                            Console.WriteLine("Вы еще не добавили абонентов!");
                            goto Menu;
                        }

                        Console.WriteLine("Введите имя абонента");
                        name = Check.ReadName();

                        Console.WriteLine(
                            "\nВыберите тип конструктора:\n" +
                            "1. Конструктор с параметрами\n" +
                            "2. Конструктор без параметров\n" +
                            "3. Конструктор копирования\n");

                        n = Check.ReadInt(1, 3);
                        Console.Clear();

                        switch (n)
                        {
                            case 1:
                                foreach (Subscriber sub in subscribers)
                                {
                                    if (sub.Name == name)
                                    {
                                        type = Check.GetPaymentType();

                                        Console.WriteLine("Введите сумму платежа:");
                                        amount = Check.ReadInt(1, 1000);

                                        Console.WriteLine("Введите дату:");
                                        date = Check.ReadDate();

                                        sub.AddPayment(type, amount, date);
                                        goto Menu;
                                    }
                                }
                                break;
                            case 2:
                                foreach (Subscriber sub in subscribers)
                                {
                                    if (sub.Name == name)
                                    {
                                        sub.AddPayment();
                                        goto Menu;
                                    }
                                }
                                break;
                            case 3:
                                foreach (Subscriber sub in subscribers)
                                {
                                    if (sub.Name == name)
                                    {
                                        int count;
                                        Console.WriteLine("Сколько сделать копий? (макс. 10)");
                                        count = Check.ReadInt(1, 10);

                                        sub.CopyPayments(count);
                                        goto Menu;
                                    }
                                }
                                break;
                        }
                        Console.WriteLine("Абонент не найден");
                        break;
                    case 4: // Редактирование
                        if (subscribers.Count == 0)
                        {
                            Console.WriteLine("Вы еще не добавили абонентов!");
                            goto Menu;
                        }

                        Console.WriteLine("Введите имя абонента для редактирования:");
                        name = Check.ReadName();

                        foreach (Subscriber sub in subscribers)
                        {
                            if (sub.Name == name)
                            {
                                sub.EditPayment();
                                goto Menu;
                            }
                        }
                        Console.WriteLine("Абонент не найден");
                        break;
                    case 5: // Удаление
                        if (subscribers.Count == 0)
                        {
                            Console.WriteLine("Вы еще не добавили абонентов!");
                            goto Menu;
                        }

                        Console.WriteLine("Введите имя абонента для удаления:");
                        name = Check.ReadName();

                        foreach (Subscriber sub in subscribers)
                        {
                            if (sub.Name == name)
                            {
                                sub.DeletePayment();
                                goto Menu;
                            }
                        }
                        Console.WriteLine("Абонент не найден");
                        break;
                    case 6: // Просмотр
                        if (subscribers.Count == 0)
                        {
                            Console.WriteLine("Вы еще не добавили абонентов!");
                            goto Menu;
                        }

                        Console.WriteLine("Введите имя абонента:");
                        int n1;

                        name = Check.ReadName();

                        Console.WriteLine(
                                "\nВыберите опцию:\n" +
                                "1. Для просмотра платежей по карте\n" +
                                "2. Для просмотра платежей наличными\n" +
                                "3. Для просмотра всех платежей\n");

                        n1 = Check.ReadInt(1, 3);
                        Console.Clear();

                        foreach (Subscriber sub in subscribers)
                        {
                            if (sub.Name == name || name == "")
                            {
                                sub.ShowPayments(n1);
                                goto Menu;
                            }
                        }
                        Console.WriteLine("Абонент не найден");
                        break;
                }
            }
        }
    }
}