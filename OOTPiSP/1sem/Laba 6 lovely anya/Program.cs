using PaymentJournal;
using System;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace PaymentJournal
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<PaymentJournal.Journal> journals = new List<PaymentJournal.Journal>();
            PaymentJournal.Journal? journal;

            MyArray<int> intTemplate = new MyArray<int>(10);
            MyArray<char> charTemplate = new MyArray<char>(10);
            MyArray<Income> incomeTemplate = new MyArray<Income>(10);
            MyArray<Expense> expenseTemplate = new MyArray<Expense>(10);

            int n = 1;

            while (n != 0)
            {
                Console.WriteLine("\nВыберите опцию:");
                Console.WriteLine("1. Добавить журнал");
                Console.WriteLine("2. Просмотреть журналы");
                Console.WriteLine("3. Добавить платеж");
                Console.WriteLine("4. Редактировать платеж");
                Console.WriteLine("5. Удалить платеж");
                Console.WriteLine("6. Просмотреть платежи");
                Console.WriteLine("7. Перегрузка операторов");
                Console.WriteLine("8. Шаблон");
                Console.WriteLine("0. Выход");

                n = Check.GetInt(0, 8);

                Console.Clear();

                switch (n)
                {
                    case 1: // Добавить журнал
                        var name = Check.GetName("Введите название журнала");
                        
                        if (journals.Any(c => c.Name == name)) // Проверка журнала на уникальность
                        {
                            Console.Clear();
                            Console.WriteLine("Такой журнал уже есть!");
                            break;
                        }

                        var card = Check.GetCard("Введите последние 4 цифры карты");

                        journals.Add(new Journal(card, name));
                        break;

                    case 2: // Просмотр журналов
                        if (journals.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Журналы отсутствуют!");
                            break;
                        }

                        Console.WriteLine("Карта\tНазвание");
                        foreach (PaymentJournal.Journal j in journals)
                            j.Print();
                        break;

                    case 3: // Добавить платеж
                        journal = Check.GetJournal(journals);
                        journal?.Add();
                        break;

                    case 4: // Редактировать платеж
                        journal = Check.GetJournal(journals);
                        journal?.Edit();
                        break;

                    case 5: // Удалить платеж
                        journal = Check.GetJournal(journals);
                        journal?.Delete();
                        break;

                    case 6: // Просмотреть платежи
                        journal = Check.GetJournal(journals);
                        journal?.PrintPayments();
                        break;
                    case 7: // Перегрузка операторов
                        Console.Clear();
                        journal = Check.GetJournal(journals);
                        if (journal == (object?)null) break;

                        Console.WriteLine("\nВыберите опцию:");
                        Console.WriteLine("1. Оператор +");
                        Console.WriteLine("2. Оператор ++");
                        Console.WriteLine("3. Оператор []");
                        Console.WriteLine("4. Оператор <<");
                        Console.WriteLine("5. Сравнение (<, >, ==, !=");
                        Console.WriteLine("0. Выход");

                        n = Check.GetInt(0, 5);

                        switch (n)
                        {
                            case 1:
                                journal = journal + Check.OperatorP();
                                break;
                            case 2:
                                ++journal;
                                break;
                            case 3:
                                Console.Clear();
                                journal.PrintPayments();
                                var index = Check.GetInt(0, 40, "Введите порядковый номер платежа");

                                if (journal?[index] == (object?)null)
                                {
                                    Console.WriteLine("Платежа с таким номером нет!");
                                    break;
                                }

                                journal[index]?.Print();
                                break;
                            case 4:
                                Console.Clear();
                                journal.PrintPayments();
                                index = Check.GetInt(0, 40, "Введите порядковый номер платежа");

                                journal = journal << index;
                                break;
                            case 5:
                                Console.Clear();
                                journal.PrintPayments();
                                index = Check.GetInt(0, 40, "Введите первый платеж для сравнения");
                                var index2 = Check.GetInt(0, 40, "Введите второй платеж для сравнения");

                                if (journal?[index] == (object?)null || journal?[index2] == (object?)null) // не допустить сравнение null и null
                                {
                                    Console.WriteLine("Платежа с таким номером нет!");
                                    break;
                                }

                                if (journal[index] == journal[index2])
                                {
                                    Console.WriteLine("{0} == {1}", journal?[index].Amount, journal?[index2].Amount);
                                    break;
                                }

                                if (journal[index] < journal[index2]) Console.WriteLine("{0} < {1}", journal?[index].Amount, journal?[index2].Amount);
                                else Console.WriteLine("{0} > {1}", journal?[index].Amount, journal?[index2].Amount);
                                break;
                            case 0:
                                n = 1;
                                break;
                        }
                        break;
                    case 8: // Шаблон
                    Template:
                        Console.WriteLine("\nВыберите опцию:");
                        Console.WriteLine("1. Шаблон int");
                        Console.WriteLine("2. Шаблон char");
                        Console.WriteLine("3. Шаблон доходов");
                        Console.WriteLine("4. Шаблон расходов");
                        Console.WriteLine("0. Выход");

                        n = Check.GetInt(0, 7);
                        switch (n)
                        {
                            case 1:
                                intTemplate = Check.IntTemplate(intTemplate);
                                goto Template;
                            case 2:
                                charTemplate = Check.CharTemplate(charTemplate);
                                goto Template;
                            case 3:
                                incomeTemplate = Check.IncomeTemplate(incomeTemplate);
                                goto Template;
                                break;
                            case 4:
                                expenseTemplate = Check.ExpenseTemplate(expenseTemplate);
                                goto Template;
                            case 0:
                                n = 1;
                                break;
                        }
                        break;
                }
            }
        }
    }
}