using Laba_3._2_temp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;


namespace Laba_3._2_temp
{
    internal class Program
    {
        private static List<Subscriber> _subscribers = new List<Subscriber>();

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine(
                    "\nВыберите опцию:\n" +
                    "1. Добавить абонента\n" +
                    "2. Просмотреть абонентов\n" +
                    "3. Добавить платеж\n" +
                    "4. Редактировать платеж\n" +
                    "5. Удалить платеж\n" +
                    "6. Просмотреть платежи\n" +
                    "0. Выход\n");

                var n = Checks.ReadInt(0, 6);

                Console.Clear();

                switch (n)
                {
                    case 1:
                        AddSubscriber();
                        break;
                    case 2:
                        ShowSubscriber();
                        break;
                    case 3: // Добавление
                        AddPayment();
                        break;
                    case 4: // Редактирование
                        EditPayment();
                        break;
                    case 5: // Удаление
                        DeletePayment();
                        GC.Collect();
                        Console.ReadKey();
                        break;
                    case 6: // Просмотр
                        Show();
                        break;
                    case 0:
                        return;
                }
            }
        }

        private static Subscriber FindSubscriber(string name)
        {
            foreach (var subscriber in _subscribers)
            {
                if (subscriber.IsExsist(name))
                    return subscriber;
            }

            return null;
        }

        private static void AddSubscriber()
        {
            Console.WriteLine("Введите имя абонента");
            var name = Checks.ReadName();

            if (FindSubscriber(name) != null)
            {
                Console.WriteLine("Такой абонент уже есть! Введите другое имя!");
                AddSubscriber();
                return;
            }

            _subscribers.Add(new Subscriber(name));
        }

        private static void ShowSubscriber()
        {
            foreach (Subscriber sub in _subscribers)
            {
                sub.ShowSubscribers();
            }

            Console.ReadKey();
        }

        private static void AddPayment()
        {
            string type;
            int amount;
            DateTime date;

            Console.WriteLine("Введите имя абонента");
            var name = Checks.ReadName();
            var subscriber = FindSubscriber(name);

            Console.WriteLine(
                "1. Конструктор с параметрами\n" +
                "2. Конструктор без параметров\n" +
                "3. Конструктор копирования\n");

            var n = Checks.ReadInt(1, 3);

            Console.Clear();

            switch (n)
            {
                case 1:
                    type = Checks.TypeChoise();

                    Console.WriteLine("Введите сумму платежа:");
                    amount = Checks.ReadInt();

                    Console.WriteLine("Введите дату:");
                    date = Checks.ReadDate();

                    subscriber.AddPayment(type, amount, date);
                    break;
                case 2:
                    subscriber.AddPayment();
                    break;
                case 3:
                    Console.WriteLine("Сколько сделать копий? (макс. 10)");
                    var count = Checks.ReadInt(1, 10);

                    type = Checks.TypeChoise();

                    Console.WriteLine("Введите сумму платежа:");
                    amount = Checks.ReadInt();

                    Console.WriteLine("Введите дату:");
                    date = Checks.ReadDate();

                    var newCopy = new Payment(type, amount, date);
                    subscriber.CopyPayments(newCopy, count);
                    break;
            }
        }

        private static void EditPayment()
        {
            Console.WriteLine("Введите имя абонента");
            var name = Checks.ReadName();
            var subscriber = FindSubscriber(name);

            subscriber.EditPayment();
        }

        private static void DeletePayment()
        {
            Console.WriteLine("Введите имя абонента");
            var name = Checks.ReadName();
            var subscriber = FindSubscriber(name);

            subscriber.DeletePayment();
        }

        private static void Show()
        {
            Console.WriteLine(
                "1. Вывести платежи всех абонентов\n" +
                "2. Вывести платижи одного конкретного абонента\n");
            var n = Checks.ReadInt(1, 2);
            switch (n)
            {
                case 1:
                    foreach (var subscriber in _subscribers)
                    {
                        subscriber.ShowSubscribers();
                        subscriber.ShowPayments();
                    }
                    break;
                case 2:
                    Console.WriteLine("Введите имя абонента");
                    var name = Checks.ReadName();

                    FindSubscriber(name)?.ShowPayments();

                    break;
            }

            Console.ReadKey();
        }
    }
}