using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml.Linq;

internal class Program
{
    class Grade
    {
        private string name, surname, date;
        private int grade;
        public Grade(string name, string surname, int grade, string date) // с параметрами
        {
            Console.WriteLine("Конструктор с параметрами");
            this.name = name;
            this.surname = surname;
            this.grade = grade;
            this.date = date;
        }
        public Grade() // без параметров
        {
            Console.WriteLine("Конструктор без параметров");
            string name1, surname1, date1;
            int grade1;
            Console.WriteLine("Введите имя:");
            do
                name1 = Console.ReadLine();
            while (name1.Any(char.IsDigit));
            Console.WriteLine("Введите фамилию:");
            do
                surname1 = Console.ReadLine();
            while (surname1.Any(char.IsDigit));
            Console.WriteLine("Введите оценку:");
            do
                grade1 = GetInt();
            while (grade1 > 10 || grade1 < 0);
            Console.WriteLine("Введите дату:");
            do
                date1 = GetDate();
            while (Convert.ToDateTime(date1) > DateTime.Now || DateTime.Now.Year - Convert.ToDateTime(date1).Year > 11);

            this.name = name1;
            this.surname = surname1;
            this.grade = grade1;
            this.date = date1;
        }
        public Grade(Grade grade) // копирования
        {
            Console.WriteLine("Конструктор копирования");
            this.name = grade.name;
            this.surname = grade.surname;
            this.grade = grade.grade;
            Console.WriteLine("Введите дату:");
            do
                grade.date = GetDate();
            while (Convert.ToDateTime(grade.date) > DateTime.Now || DateTime.Now.Year - Convert.ToDateTime(grade.date).Year > 11);
            this.date = grade.date;

        }
        ~Grade()
        {
            Console.WriteLine("Оценка удалена");
        }
        public void ShowGrade()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}", this.name, this.surname, this.grade, this.date);
        }
        public bool IsExsist(string name, string surname, string date)
        {
            if (this.date == date && this.name == name && this.surname == surname)
                return true;
            return false;
        }
        public void EditGrade(int grade)
        {
            this.grade = grade;
        }
    }
    class Group
    {
        private string name;

        public Group(string name)
        {
            this.name = name;
        }

        List<Grade> grades = new List<Grade>();

        public void ShowGroup()
        {
            Console.WriteLine(name);
        }
        public void AddGrade(string name, string surname, int grade, string date)
        {
            grades.Add(new Grade(name, surname, grade, date));
        }
        public void AddGrade()
        {
            grades.Add(new Grade());
        }
        public void CopyGrades(Grade grade, int count)
        {
            for (int i = 0; i < count; i++)
            {
                grades.Add(new Grade(grade));
            }
        }
        public bool IsExsist(string name)
        {
            if (this.name == name)
                return true;
            return false;
        }
        public void ShowGrades(string name)
        {
            if (this.name != name)
                return;
            foreach (Grade grade in grades)
            {
                grade.ShowGrade();
            }
        }
        public void ShowGrades() // Перегрузка
        {
            foreach (Grade grade in grades)
            {
                grade.ShowGrade();
            }
        }
        public int GetGradesCount()
        {
            return grades.Count;
        }
        public void EditGrade()
        {
            string name, surname, date;
            int grade1, i = 0;

            Console.WriteLine("Введите имя:");
            name = Console.ReadLine();
            Console.WriteLine("Введите фамилию:");
            surname = Console.ReadLine();
            Console.WriteLine("Введите дату:");
            date = GetDate();

            foreach (Grade grade in grades)
            {
                if (grade.IsExsist(name, surname, date))
                {
                    Console.WriteLine("Введите новую оценку для " + name + ":");
                    do
                        grade1 = GetInt();
                    while (grade1 > 10 || grade1 < 0);

                    grades[i].EditGrade(grade1);
                    Console.WriteLine("Оценка изменена");
                    return;
                }
                i++;
            }
            Console.WriteLine("Оценка не найдена");
        }
        public void DeleteGrade()
        {
            string name, surname, date;
            int i = 0;

            Console.WriteLine("Введите имя:");
            name = Console.ReadLine();
            Console.WriteLine("Введите фамилию:");
            surname = Console.ReadLine();
            Console.WriteLine("Введите дату:");
            date = GetDate();

            foreach (Grade grade in grades)
            {
                if (grade.IsExsist(name, surname, date))
                {
                    GC.Collect();
                    Console.Read();
                    grades.RemoveAt(i);
                    Console.WriteLine("Оценка удалена");
                    return;
                }
                i++;
            }
            Console.WriteLine("Оценка не найдена");
        }
    }
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
        string name, surname, date;
        int id, grade;

        List<Group> groups = new List<Group>();

        int n = 1;

        while (n != 0)
        {
            Console.WriteLine("\nВыберите опцию:");
            Console.WriteLine("1. Добавить класс");
            Console.WriteLine("2. Просмотреть классы");
            Console.WriteLine("3. Добавить оценку");
            Console.WriteLine("4. Редактировать оценку");
            Console.WriteLine("5. Удалить оценку");
            Console.WriteLine("6. Просмотреть оценки");
            Console.WriteLine("0. Выход");

            do
                n = GetInt();
            while (n < 0 || n > 6);

            Console.Clear();

            switch (n)
            {
                case 1:
                    Console.WriteLine("Введите название класса (напр. \"11А\")");
                    name = Console.ReadLine();
                    foreach (Group group in groups)
                    {
                        if (group.IsExsist(name))
                        {
                            Console.WriteLine("Такой класс уже есть! Введите другое название!");
                            name = Console.ReadLine();
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
                    name = Console.ReadLine();

                    Console.WriteLine("1. Конструктор с параметрами");
                    Console.WriteLine("2. Конструктор без параметров");
                    Console.WriteLine("3. Конструктор копирования");

                    do
                        n = GetInt();
                    while (n < 0 || n > 6);
                    Console.Clear();

                    switch (n)
                    {
                        case 1:
                            foreach (Group group in groups)
                            {
                                if (group.IsExsist(name))
                                {
                                    Console.WriteLine("Введите имя:");
                                    do
                                        name = Console.ReadLine();
                                    while (name.Any(char.IsDigit));
                                    Console.WriteLine("Введите фамилию:");
                                    do
                                        surname = Console.ReadLine();
                                    while (surname.Any(char.IsDigit));
                                    Console.WriteLine("Введите оценку:");
                                    do
                                        grade = GetInt();
                                    while (grade > 10 || grade < 0);
                                    Console.WriteLine("Введите дату:");
                                    do
                                        date = GetDate();
                                    while (Convert.ToDateTime(date) > DateTime.Now || DateTime.Now.Year - Convert.ToDateTime(date).Year > 11);

                                    group.AddGrade(name, surname, grade, date);
                                }
                            }
                            break;
                        case 2:
                            foreach (Group group in groups)
                            {
                                if (group.IsExsist(name))
                                {
                                    group.AddGrade();
                                }
                            }
                            break;
                        case 3:
                            foreach (Group group in groups)
                            {
                                if (group.IsExsist(name))
                                {
                                    int count;
                                    Console.WriteLine("Сколько сделать копий? (макс. 10)");
                                    do
                                        count = GetInt();
                                    while (count < 1 || count > 10);

                                    Console.WriteLine("Введите имя:");
                                    do
                                        name = Console.ReadLine();
                                    while (name.Any(char.IsDigit));
                                    Console.WriteLine("Введите фамилию:");
                                    do
                                        surname = Console.ReadLine();
                                    while (surname.Any(char.IsDigit));
                                    Console.WriteLine("Введите оценку:");
                                    do
                                        grade = GetInt();
                                    while (grade > 10 || grade < 0);
                                    date = "20.02.2023";
                                    group.CopyGrades(new Grade(name, surname, grade, date), count);
                                }
                            }
                            break;
                    }
                    break;
                case 4: // Редактирование
                    Console.WriteLine("Введите название класса:");
                    name = Console.ReadLine();

                    foreach (Group group in groups)
                    {
                        if (group.IsExsist(name))
                        {
                            group.EditGrade();
                        }
                    }
                    break;
                case 5: // Удаление
                    Console.WriteLine("Введите название класса:");
                    name = Console.ReadLine();

                    foreach (Group group in groups)
                    {
                        if (group.IsExsist(name))
                        {
                            group.DeleteGrade();
                        }
                    }
                    break;
                case 6: // Просмотр
                    Console.WriteLine("Введите название класса (либо нажмите Enter для просмотра всех оценок):");
                    name = Console.ReadLine();

                    if (name != "")
                    {
                        foreach (Group group in groups)
                        {
                            group.ShowGrades(name);
                        }
                    }
                    else
                    {
                        for (id = 0; id < groups.Count; id++)
                        {
                            groups[id].ShowGroup();
                            groups[id].ShowGrades();
                        }
                    }

                    break;
            }


        }
    }
}