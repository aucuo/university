using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4
{
    internal class Group
    {
        private string name;
        List<Grade> grades = new List<Grade>();

        public Group(string name)
        {
            this.name = name;
        }
        public void ShowGroup()
        {
            Console.WriteLine(name);
        }
        public void AddGrade(string name, string surname, int grade, string date, string type)
        {
            int n;
            if (type == "Экзамен")
            {
                string examName, examDifficulty = "", examDuration = "";

                Console.WriteLine("Введите название экзамена");
                examName = Check.GetName();

                Console.WriteLine(
                    "\nВыберите сложность экзамена\n" +
                    "1. Легкий\n" +
                    "2. Нормальный\n" +
                    "3. Сложный");
                n = Check.GetInt(1, 3);
                if (n == 1) examDifficulty = "Легкий";
                if (n == 2) examDifficulty = "Нормальный";
                if (n == 3) examDifficulty = "Сложный";

                Console.WriteLine(
                    "\nВыберите продолжительность экзамена\n" +
                    "1. 60 мин.\n" +
                    "2. 90 мин.\n" +
                    "3. 120 мин.");
                n = Check.GetInt(1, 3);
                if (n == 1) examDifficulty = "60 мин.";
                if (n == 2) examDifficulty = "90 мин.";
                if (n == 3) examDifficulty = "120 мин.";
                grades.Add(new Exam(name, surname, grade, date, examName, examDifficulty, examDuration));
            }
            if (type == "Зачет")
            {
                string creditName, creditType = "";

                Console.WriteLine("Введите название зачета");
                creditName = Check.GetName();

                Console.WriteLine(
                    "\nВыберите тип зачета\n" +
                    "1. Обычный зачет\n" +
                    "2. Диф. зачет");
                n = Check.GetInt(1, 2);
                if (n == 1) creditType = "Обычный зачет";
                if (n == 2) creditType = "Диф. зачет";
                grades.Add(new Credit(name, surname, grade, date, creditName, (grade > 4) ? "Зачет" : "Незачет", creditType));
            }
        }
        public void AddGrade(string type)
        {
            if (type == "Экзамен") grades.Add(new Exam());
            if (type == "Зачет") grades.Add(new Credit());
        }
        public void CopyGrades(int count, int type)
        {
            string date;
            Console.WriteLine("Введите имя:");
            string name = Check.GetName();

            Console.WriteLine("Введите фамилию:");
            string surname = Check.GetName();

            Console.WriteLine("Введите оценку:");
            int grade = Check.GetInt(0, 10);

            Console.WriteLine("Введите дату:");
            do
                date = Check.GetDate();
            while (Convert.ToDateTime(date) > DateTime.Now || DateTime.Now.Year - Convert.ToDateTime(date).Year > 11);

            if (type == 1) // экзамен
            {
                int n;
                string examName, examDifficulty = "", examDuration = "";

                Console.WriteLine("Введите название экзамена");
                examName = Check.GetName();

                Console.WriteLine(
                    "\nВыберите сложность экзамена\n" +
                    "1. Легкий\n" +
                    "2. Нормальный\n" +
                    "3. Сложный");
                n = Check.GetInt(1, 3);
                if (n == 1) examDifficulty = "Легкий";
                if (n == 2) examDifficulty = "Нормальный";
                if (n == 3) examDifficulty = "Сложный";

                Console.WriteLine(
                    "\nВыберите продолжительность экзамена\n" +
                    "1. 60 мин.\n" +
                    "2. 90 мин.\n" +
                    "3. 120 мин.");
                n = Check.GetInt(1, 3);
                if (n == 1) examDifficulty = "60 мин.";
                if (n == 2) examDifficulty = "90 мин.";
                if (n == 3) examDifficulty = "120 мин.";

                for (int i = 0; i < count; i++)
                {
                    grades.Add(new Exam(new Exam(name, surname, grade, date, examName, examDifficulty, examDuration)));
                }
            }

            if (type == 2) // зачет
            {
                int n;
                string creditName, creditType = "";

                Console.WriteLine("Введите название зачета");
                creditName = Check.GetName();

                Console.WriteLine(
                    "\nВыберите тип зачета\n" +
                    "1. Обычный зачет\n" +
                    "2. Диф. зачет");
                n = Check.GetInt(1, 2);
                if (n == 1) creditType = "Обычный зачет";
                if (n == 2) creditType = "Диф. зачет";

                for (int i = 0; i < count; i++)
                {
                    grades.Add(new Credit(name, surname, grade, date, creditName, (grade > 4) ? "Зачет" : "Незачет", creditType));
                }
            }
        }
        public bool IsExsist(string name)
        {
            if (this.name == name)
                return true;
            return false;
        }
        public void ShowGrades(string name, int type)
        {
            if (this.name != name)
                return;
            if (type == 1) // все оценки
            {
                Console.WriteLine("Все оценки (" + this.name + ")");

                foreach (Grade grade in grades)
                {
                    grade.Print();
                }
            }
            if (type == 2) // экзамен
            {
                Console.WriteLine("Оценки за экзамен (" + this.name + ")");

                foreach (Grade grade in grades)
                {
                    if (grade is Exam)
                    {
                        (grade as Exam).Print();
                    }
                }
            }
            if (type == 3) // зачет
            {
                Console.WriteLine("Оценки за зачет (" + this.name + ")");

                foreach (Grade grade in grades)
                {
                    if (grade is Credit)
                    {
                        (grade as Credit).Print();
                    }
                }
            }
        }
        public bool DeleteGrade()
        {
            string name, surname, date;
            int i = 0;

            Console.WriteLine("Введите имя:");
            name = Check.GetName();

            Console.WriteLine("Введите фамилию:");
            surname = Check.GetName();

            Console.WriteLine("Введите дату:");
            do
                date = Check.GetDate();
            while (Convert.ToDateTime(date) > DateTime.Now || DateTime.Now.Year - Convert.ToDateTime(date).Year > 11);

            foreach (Grade grade in grades)
            {
                if (grade.IsExsist(name, surname, date))
                {
                    grades.RemoveAt(i);
                    GC.Collect();
                    Console.Read();
                    Console.WriteLine("Оценка удалена");
                    return true;
                }
                i++;
            }
            Console.WriteLine("Оценка не найдена");
            return false;
        }
    }
}
