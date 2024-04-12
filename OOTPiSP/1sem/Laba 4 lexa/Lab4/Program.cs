using Lab4;
using System;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Laba_4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Schedule> schedules = new List<Schedule>();
            Schedule? schedule;
            int n = 1;

            while (n != 0)
            {
                Menu: // label для возврата
                Console.WriteLine("\nВыберите опцию:");
                Console.WriteLine("1. Добавить расписание");
                Console.WriteLine("2. Просмотреть расписания");
                Console.WriteLine("3. Добавить урок");
                Console.WriteLine("4. Редактировать урок");
                Console.WriteLine("5. Удалить урок");
                Console.WriteLine("6. Просмотреть уроки");
                Console.WriteLine("0. Выход");

                n = Check.GetInt(0, 6);

                Console.Clear();

                switch (n)
                {
                    case 1: // Добавить расписание
                        var addr = Check.GetAddress("Введите адрес (улица, здание)");
                        
                        if (schedules.Any(c => c.Adress == addr)) // Проверка адреса на уникальность
                        {
                            Console.Clear();
                            Console.WriteLine("Ошибка: Такой адрес уже есть");
                            break;
                        }

                        schedules.Add(new Schedule(schedules.Count() + 1, addr));
                        break;

                    case 2: // Просмотр расписания
                        if (schedules.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Ошибка: Вы не добавили учебные заведения!");
                            break;
                        }

                        Console.WriteLine("Номер\tАдрес");

                        foreach (Schedule sch in schedules)
                            sch.Print();
                        break;

                    case 3: // Добавить урок
                        schedule = Check.GetSchedule(schedules);
                        schedule?.Add();
                        break;

                    case 4: // Редактировать урок
                        schedule = Check.GetSchedule(schedules);
                        schedule?.Edit();
                        break;

                    case 5: // Удалить урок
                        schedule = Check.GetSchedule(schedules);
                        schedule?.Delete();
                        break;

                    case 6: // Просмотреть уроки
                        schedule = Check.GetSchedule(schedules);
                        schedule?.PrintLessons();
                        break;
                }
            }
        }
    }
}