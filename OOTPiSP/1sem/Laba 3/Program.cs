using System;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Laba_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string name, surname, date;
            int id, grade;

            List<Group> groups = new List<Group>();

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
                Console.WriteLine("0. Выход");

                n = Check.GetInt(0, 6);

                Console.Clear();

                switch (n)
                {
                    case 1:
                        Console.WriteLine("Введите название класса (напр. \"11А\")");
                        name = Check.GetGroup();
                        foreach (Group group in groups)
                        {
                            if (group.IsExsist(name))
                            {
                                Console.WriteLine("Такой класс уже есть! Введите другое название!");
                                goto case 1;
                            }
                        }
                        groups.Add(new Group(name));
                        Console.Clear();
                        break;
                    case 2:
                        foreach (Group group in groups)
                        {
                            group.ShowGroup();
                        }
                        break;
                    case 3: // Добавление
                        Console.WriteLine("Введите название класса:");
                        name = Check.GetGroup();

                        Console.WriteLine(
                            "\nВыберите тип конструктора:\n" +
                            "1. Конструктор с параметрами\n" +
                            "2. Конструктор без параметров\n" +
                            "3. Конструктор копирования\n");

                        n = Check.GetInt(0, 6);

                        Console.Clear();

                        switch (n)
                        {
                            case 1:
                                foreach (Group group in groups)
                                {
                                    if (group.IsExsist(name))
                                    {
                                        Console.WriteLine(
                                            "\nВыберите тип оценки:\n" +
                                            "1. Обычная\n" +
                                            "2. Экзамен\n" +
                                            "3. Зачет\n");
                                        n = Check.GetInt(1, 3);

                                        Console.WriteLine("Введите имя:");
                                        name = Check.GetName();

                                        Console.WriteLine("Введите фамилию:");
                                        surname = Check.GetName();

                                        Console.WriteLine("Введите оценку:");
                                        grade = Check.GetInt(0, 10);

                                        Console.WriteLine("Введите дату:");
                                        do
                                            date = Check.GetDate();
                                        while (Convert.ToDateTime(date) > DateTime.Now || DateTime.Now.Year - Convert.ToDateTime(date).Year > 11);

                                        switch(n)
                                        {
                                            case 1:
                                                group.AddGrade(name, surname, grade, date, "");
                                                break;
                                            case 2:
                                                group.AddGrade(name, surname, grade, date, "Экзамен");
                                                break;
                                            case 3:
                                                group.AddGrade(name, surname, grade, date, "Зачет");
                                                break;
                                        }

                                        goto Menu;
                                    }
                                }
                                break;
                            case 2:
                                foreach (Group group in groups)
                                {
                                    if (group.IsExsist(name))
                                    {
                                        Console.WriteLine(
                                            "\nВыберите тип оценки:\n" +
                                            "1. Обычная\n" +
                                            "2. Экзамен\n" +
                                            "3. Зачет\n");
                                        n = Check.GetInt(1, 3);

                                        switch (n)
                                        {
                                            case 1:
                                                group.AddGrade("");
                                                break;
                                            case 2:
                                                group.AddGrade("Экзамен");
                                                break;
                                            case 3:
                                                group.AddGrade("Зачет");
                                                break;
                                        }
                                        goto Menu;
                                    }
                                }
                                break;
                            case 3:
                                foreach (Group group in groups)
                                {
                                    if (group.IsExsist(name))
                                    {
                                        int count;

                                        Console.WriteLine(
                                            "\nВыберите тип оценки:\n" +
                                            "1. Обычная\n" +
                                            "2. Экзамен\n" +
                                            "3. Зачет\n");
                                        n = Check.GetInt(1, 3);

                                        Console.WriteLine("Сколько сделать копий? (макс. 10)");
                                        count = Check.GetInt(1, 10);

                                        
                                        switch (n)
                                        {
                                            case 1:
                                                group.CopyGrades(count, n);
                                                break;
                                            case 2:
                                                group.CopyGrades(count, n);
                                                break;
                                            case 3:
                                                group.CopyGrades(count, n);
                                                break;
                                        }

                                        goto Menu;
                                    }
                                }
                                break;
                        }
                        break;
                    case 4: // Редактирование
                        Console.WriteLine("Введите название класса:");
                        name = Check.GetGroup();

                        foreach (Group group in groups)
                        {
                            if (group.IsExsist(name))
                            {
                                if (group.DeleteGrade())
                                {
                                    Console.WriteLine(
                                    "\nВыберите тип оценки:\n" +
                                    "1. Обычная\n" +
                                    "2. Экзамен\n" +
                                    "3. Зачет\n");
                                    n = Check.GetInt(1, 3);

                                    Console.WriteLine("Введите имя:");
                                    name = Check.GetName();

                                    Console.WriteLine("Введите фамилию:");
                                    surname = Check.GetName();

                                    Console.WriteLine("Введите оценку:");
                                    grade = Check.GetInt(0, 10);

                                    Console.WriteLine("Введите дату:");
                                    do
                                        date = Check.GetDate();
                                    while (Convert.ToDateTime(date) > DateTime.Now || DateTime.Now.Year - Convert.ToDateTime(date).Year > 11);

                                    switch (n)
                                    {
                                        case 1:
                                            group.AddGrade(name, surname, grade, date, "");
                                            break;
                                        case 2:
                                            group.AddGrade(name, surname, grade, date, "Экзамен");
                                            break;
                                        case 3:
                                            group.AddGrade(name, surname, grade, date, "Зачет");
                                            break;
                                    }

                                    goto Menu;
                                }
                            }
                        }
                        break;
                    case 5: // Удаление
                        Console.WriteLine("Введите название класса:");
                        name = Check.GetGroup();

                        foreach (Group group in groups)
                        {
                            if (group.IsExsist(name))
                            {
                                group.DeleteGrade();
                                goto Menu;
                            }
                        }
                        break;
                    case 6: // Просмотр
                        Console.WriteLine("Введите название класса:");
                        name = Check.GetGroup();

                        if (name != "")
                        {
                            Console.WriteLine(
                                "\nВыберите опцию:\n" +
                                "1. Для просмотра всех оценок\n" +
                                "2. Для просмотра экзаменационных оценок\n" +
                                "3. Для просмотра зачетных оценок\n");

                            n = Check.GetInt(1, 3);

                            foreach (Group group in groups)
                            {
                                group.ShowGrades(name, n);
                            }
                        }
                        break;
                }
            }
        }
    }
}