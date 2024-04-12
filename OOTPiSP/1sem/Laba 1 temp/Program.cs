using System.Text.RegularExpressions;

internal class Program
{
    class Payment
    {
        private double amount;
        private string date, type;

        public Payment(double amount, string date, string type)
        {
            this.amount = amount;
            this.date = date;
            this.type = type;
        }

        public void ShowInfo(bool isCard)
        {
            if (isCard)
            {
                if (this.type == "Картой")
                    Console.WriteLine("{0}\t{1}\t{2}", this.amount, this.date, this.type);
            } 
            else
            {
                if (this.type == "Наличными")
                    Console.WriteLine("{0}\t{1}\t{2}", this.amount, this.date, this.type);
            }
        }

        public void ShowInfo() // Перегрузка
        {
            Console.WriteLine("{0}\t{1}\t{2}", this.amount, this.date, this.type);
        }
    }
    class Subscriber
    {
        private string name, surname, birthdate;
        private int id;

        private List<Payment> payments = new List<Payment> ();

        public Subscriber(string name, string surname, string birthdate, int id)
        {
            this.name = name;
            this.surname = surname;
            this.birthdate = birthdate;
            this.id = id;
        }
        public void EditSubscriber(string name, string surname, string birthdate)
        {
            this.name = name;
            this.surname = surname;
            this.birthdate = birthdate;
        }

        public void ShowInfo()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}", this.id, this.name, this.surname, this.birthdate);
        }

        public void AddPayment(Payment payment)
        {
            payments.Add(payment);
        }

        public void ShowPayments(string type)
        {
            Console.Clear();

            if (payments.Count == 0)
            {
                Console.WriteLine("Платежей нет!");
                return;
            }
            foreach (Payment payment in payments)
            {
                switch (type)
                {
                    case "Картой":
                        payment.ShowInfo(true);
                        break;
                    case "Наличными":
                        payment.ShowInfo(false);
                        break;
                    default:
                        payment.ShowInfo();
                        break;
                }
            }
        }
        public void ShowPayments() // Перегрузка
        {
            Console.Clear();

            if (payments.Count == 0)
            {
                Console.WriteLine("Платежей нет!");
                return;
            }
            foreach (Payment payment in payments)
            {
                payment.ShowInfo();
            }
        }
    }

    static public bool CheckInput(string name, string surname, string birthdate)
    {
        if (name.All(char.IsDigit) || surname.All(char.IsDigit)) // Проверка на цифры
            return false;

        if (!DateTime.TryParse(birthdate, out DateTime dt)) // проверка даты
            return false;

        return true;
    }

    static public bool CheckInput(string date)
    {
        if (!DateTime.TryParse(date, out DateTime dt)) // проверка даты
            return false;

        return true;
    }

    private static void Main(string[] args)
    {
        string name, surname, birthdate, date, type;
        double amount;
        int id;
        bool state = false;

        List<Subscriber> subscribers = new List<Subscriber> ();

        int n = 1;

        while (n != 0)
        {
            Console.WriteLine("Выберите опцию:");
            Console.WriteLine("1. Добавить абонента");
            Console.WriteLine("2. Редактировать абонента");
            Console.WriteLine("3. Удалить абонента");
            Console.WriteLine("4. Просмотр абонентов");
            Console.WriteLine("5. Добавить платежи");
            Console.WriteLine("6. Просмотреть платежи");
            Console.WriteLine("0. Выход");

            do
                n = Convert.ToInt16(Console.ReadLine());
            while (n < 0 || n > 6);

            switch (n)
            {
                case 1: // Добавление
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Введите имя:");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите фамилию:");
                        surname = Console.ReadLine();
                        Console.WriteLine("Введите дату рождения:");
                        birthdate = Console.ReadLine();
                        state = CheckInput(name, surname, birthdate);
                    } while (!state);

                    subscribers.Add(new Subscriber(name, surname, birthdate, subscribers.Count()));
                    Console.Clear();
                    Console.WriteLine("Абонент добавлен!");
                    break;
                case 2: // Редактирование
                    Console.Clear();

                    if (subscribers.Count == 0)
                    {
                        Console.WriteLine("Абоненты не найдены!");
                        break;
                    }

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Введите id абонента:");
                        id = Convert.ToInt16(Console.ReadLine());
                    } while (id < 0 || id > subscribers.Count - 1);

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Введите имя:");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите фамилию:");
                        surname = Console.ReadLine();
                        Console.WriteLine("Введите дату рождения:");
                        birthdate = Console.ReadLine();
                        state = CheckInput(name, surname, birthdate);
                    } while (!state);

                    Console.Clear();
                    subscribers[id].EditSubscriber(name, surname, birthdate);
                    Console.WriteLine("Данные абонента " + id + " редактированы!");
                    break;
                case 3: // Удаление
                    Console.Clear();

                    if (subscribers.Count == 0)
                    {
                        Console.WriteLine("Абоненты не найдены!");
                        break;
                    }

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Введите id абонента:");
                        id = Convert.ToInt16(Console.ReadLine());
                    } while (id < 0 || id > subscribers.Count - 1);

                    subscribers.RemoveAt(id);
                    Console.Clear();
                    Console.WriteLine("Абонент " + id + " удален!");
                    break;
                case 4: // Просмотр
                    Console.Clear();

                    if (subscribers.Count == 0)
                    {
                        Console.WriteLine("Абоненты не найдены!");
                        break;
                    }

                    Console.WriteLine("id\tname\tsurname\tbirthdate");
                    foreach (Subscriber sub in subscribers)
                    {
                        sub.ShowInfo();
                    }
                    break;
                case 5: // Доб. платежи
                    Console.Clear();

                    if (subscribers.Count == 0)
                    {
                        Console.WriteLine("Абоненты не найдены!");
                        break;
                    }

                    Console.WriteLine("1. Добавить платеж по карте");
                    Console.WriteLine("2. Добавить платеж наличными");

                    do
                        n = Convert.ToInt16(Console.ReadLine());
                    while (n < 1 || n > 2);

                    switch (n)
                    {
                        case 1:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Введите id абонента:");
                                id = Convert.ToInt16(Console.ReadLine());
                            } while (id < 0 || id > subscribers.Count - 1);

                            Console.WriteLine("Введите сумму платежа:");
                            amount = Convert.ToInt16(Console.ReadLine());
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Введите дату:");
                                date = Console.ReadLine();
                                state = CheckInput(date);
                            } while (!state);

                            subscribers[id].AddPayment(new Payment(amount, date, "Картой"));
                            Console.Clear();
                            Console.WriteLine("Платеж по карте добавлен!");

                            break;
                        case 2:
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Введите id абонента:");
                                id = Convert.ToInt16(Console.ReadLine());
                            } while (id < 0 || id > subscribers.Count - 1);

                            Console.WriteLine("Введите сумму платежа:");
                            amount = Convert.ToInt16(Console.ReadLine());
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Введите дату:");
                                date = Console.ReadLine();
                                state = CheckInput(date);
                            } while (!state);

                            subscribers[id].AddPayment(new Payment(amount, date, "Наличными"));
                            Console.Clear();
                            Console.WriteLine("Платеж по карте добавлен!");
                            break;
                    }

                    break;
                case 6: // Просм. платежи
                    Console.Clear();

                    if (subscribers.Count == 0)
                    {
                        Console.WriteLine("Абоненты не найдены!");
                        break;
                    }

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Введите id абонента:");
                        id = Convert.ToInt16(Console.ReadLine());
                    } while (id < 0 || id > subscribers.Count - 1);

                    Console.WriteLine("1. Платежи по карте");
                    Console.WriteLine("2. Платежи наличными");
                    Console.WriteLine("3. Все платежи");

                    do
                        n = Convert.ToInt16(Console.ReadLine());
                    while (n < 1 || n > 3);

                    switch (n)
                    {
                        case 1:
                            Console.Clear();
                            subscribers[id].ShowPayments("Картой");
                            break;
                        case 2:
                            Console.Clear();
                            subscribers[id].ShowPayments("Наличными");
                            break;
                        case 3:
                            Console.Clear();
                            subscribers[id].ShowPayments();
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}