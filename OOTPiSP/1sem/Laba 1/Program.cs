using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

internal class Program
{
    class Grade
    {
        private string name, surname, date;
        private int id, grade;
        public Grade(string name, string surname, int grade, string date, int id)
        {
            this.name = name;
            this.surname = surname;
            this.grade = grade;
            this.date = date;
            this.id = id;
        }
        public void ShowGrade()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}", this.name, this.surname, this.grade, this.date);
        }
        public int IsExsist(string name, string surname, string date)
        {
            if (this.date == date && this.name == name && this.surname == surname)
                return this.id;
            return -1;
        }
        public void EditGrade(int grade)
        {
            this.grade = grade;
        }
    }
    class Group
    {
        private string name;
        int id;

        public Group(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        List<Grade> grades = new List<Grade> ();

        public void ShowGroup()
        {
            Console.WriteLine(name);
        }
        public void AddGrade(Grade grade)
        {
            grades.Add(grade);
        }
        public int IsExsist(string name)
        {
            if (this.name == name)
                return this.id;
            return -1;
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
        public void EditGrade(string name)
        {
            string surname, date;
            int grade1;

            Console.WriteLine("Введите имя:");
            name = Console.ReadLine();
            Console.WriteLine("Введите фамилию:");
            surname = Console.ReadLine();
            Console.WriteLine("Введите дату:");
            date = GetDate();

            foreach (Grade grade in grades)
            {
                if (grade.IsExsist(name, surname, date) != -1)
                {
                    int id = grade.IsExsist(name, surname, date);

                    Console.WriteLine("Введите новую оценку для " + name + ":");
                    do
                        grade1 = GetInt();
                    while (grade1 > 10 || grade1 < 0);

                    grades[id].EditGrade(grade1);
                    Console.WriteLine("Оценка изменена");
                    return;
                }
            }
            Console.WriteLine("Оценка не найдена");
        }
        public void DeleteGrade(string name)
        {
            string surname, date;

            Console.WriteLine("Введите имя:");
            name = Console.ReadLine();
            Console.WriteLine("Введите фамилию:");
            surname = Console.ReadLine();
            Console.WriteLine("Введите дату:");
            date = GetDate();

            foreach (Grade grade in grades)
            {
                if (grade.IsExsist(name, surname, date) != -1)
                {
                    int id = grade.IsExsist(name, surname, date);

                    grades.RemoveAt(id);
                    Console.WriteLine("Оценка удалена");
                    return;
                }
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
        while (!DateTime.TryParse(date, out DateTime dt)) ;

        return date;
    }
    private static void Main(string[] args)
    {
        string name, surname, date;
        int id, grade;

        List<Group> groups = new List<Group> ();

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
                        if (group.IsExsist(name) != -1)
                        {
                            Console.WriteLine("Такой класс уже есть! Введите другое название!");
                            name = Console.ReadLine();
                        }
                    }
                    groups.Add(new Group(name, groups.Count));
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

                    foreach (Group group in groups)
                    {
                        if (group.IsExsist(name) != -1)
                        {
                            id = group.IsExsist(name);

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

                            groups[id].AddGrade(new Grade(name, surname, grade, date, groups[id].GetGradesCount()));
                        }
                    }
                    break;
                case 4: // Редактирование
                    Console.WriteLine("Введите название класса:");
                    name = Console.ReadLine();

                    foreach (Group group in groups)
                    {
                        if (group.IsExsist(name) != -1)
                        {
                            group.EditGrade(name);
                        }
                    }
                    break;
                case 5: // Удаление
                    Console.WriteLine("Введите название класса:");
                    name = Console.ReadLine();

                    foreach (Group group in groups)
                    {
                        if (group.IsExsist(name) != -1)
                        {
                            group.DeleteGrade(name);
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
                        for (id = 0; id < groups.Count; id++ )
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