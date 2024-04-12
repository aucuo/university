﻿using Lab5;
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
            List<Lab5.Group> groups = new List<Lab5.Group>();
            Lab5.Group? group;
            int n = 1;

            while (n != 0)
            {
                Menu: // label для возврата
                Console.WriteLine("\nВыберите опцию:");
                Console.WriteLine("1. Добавить класс");
                Console.WriteLine("2. Просмотреть классы");
                Console.WriteLine("3. Добавить оценку");
                Console.WriteLine("4. Редактировать оценку");
                Console.WriteLine("5. Удалить оценку");
                Console.WriteLine("6. Просмотреть оценки");
                Console.WriteLine("7. Перегрузка операторов");
                Console.WriteLine("0. Выход");

                n = Check.GetInt(0, 7);

                Console.Clear();

                switch (n)
                {
                    case 1: // Добавить расписание ***
                        var name = Check.GetGroupName("Введите название класса (напр. \"11А\")");
                        
                        if (groups.Any(c => c.Name == name)) // Проверка на уникальность
                        {
                            Console.Clear();
                            Console.WriteLine("Ошибка: Такой класс уже есть");
                            break;
                        }

                        groups.Add(new Lab5.Group(groups.Count() + 1, name));
                        break;

                    case 2: // Просмотр классов
                        if (groups.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Ошибка: Вы не добавляли классы!");
                            break;
                        }

                        Console.WriteLine("ID\tКласс");

                        foreach (Lab5.Group g in groups)
                            g.Print();
                        break;

                    case 3: // Добавить оценку
                        group = Check.GetGroup(groups);
                        group?.Add();
                        break;

                    case 4: // Редактировать оценку
                        group = Check.GetGroup(groups);
                        group?.Edit();
                        break;

                    case 5: // Удалить оценку
                        group = Check.GetGroup(groups);
                        group?.Delete();
                        break;

                    case 6: // Просмотреть оценки
                        group = Check.GetGroup(groups);
                        group?.PrintGrades();
                        break;
                    case 7: // Перегрузка операторов
                        Console.Clear();
                        group = Check.GetGroup(groups);
                        if (group == (object?)null) break;

                        Console.WriteLine("\nВыберите опцию:");
                        Console.WriteLine("1. Оператор +");
                        Console.WriteLine("2. Оператор ++");
                        Console.WriteLine("3. Оператор []");
                        Console.WriteLine("4. Оператор <<");
                        Console.WriteLine("5. Сравнение (<, >, ==, !=");
                        Console.WriteLine("0. Выход");

                        n = Check.GetInt(0, 7);

                        switch (n)
                        {
                            case 1:
                                group = group + Check.OperatorP();
                                break;
                            case 2:
                                ++group;
                                break;
                            case 3:
                                var index = Check.GetInt(0, 40, "Введите порядковый номер оценки");

                                if (group?[index] == (object?)null)
                                { 
                                    Console.WriteLine("Ошибка: Оценки с таким номером нет!");
                                    break;
                                }
 
                                group[index]?.Print();
                                break;
                            case 4:
                                index = Check.GetInt(0, 40, "Введите порядковый номер оценки");

                                group = group << index;
                                break;
                            case 5:
                                index = Check.GetInt(0, 40, "Введите первую оценку для сравнения");
                                var index2 = Check.GetInt(0, 40, "Введите вторую оценку для сравнения");

                                if (group?[index] == (object?)null || group?[index2] == (object?)null) // не допустить сравнение null и null
                                {
                                    Console.WriteLine("Ошибка: Оценки с таким номером нет!");
                                    break;
                                }

                                if (group[index] == group[index2])
                                {
                                    Console.WriteLine("{0} == {1}", group?[index].Mark, group?[index2].Mark);
                                    break;
                                }

                                if (group[index] < group[index2]) Console.WriteLine("{0} < {1}", group?[index].Mark, group?[index2].Mark);
                                else Console.WriteLine("{0} > {1}", group?[index].Mark, group?[index2].Mark);
                                break;
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