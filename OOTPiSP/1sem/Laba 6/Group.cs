using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Group
    {
        private int number;
        private string name;
        List<Grade> grades = new List<Grade>();
        public string Name { get { return name; } }
        public List<Grade> Grades { get { return grades; } }

        public Group(int number, string name)
        {
            this.number = number;
            this.name = name;
        }
        public void Print() { Console.WriteLine("{0}\t{1}", number, name); } // Вывод группы
        public void PrintGrades() // Вывод оценок
        {
            for (int i = 0; i < grades.Count; i++)
            {
                Console.Write(i + ". ");
                grades[i].Print();
            }
        }
        public void Add()
        {
            (string, string, string, int, string, string, string) data;
            switch (Check.GetGradeType())
            {
                case 1: // Экзамен
                    switch (Check.GetConstructorOption())
                    {
                        case 1: // Конструктор с параметрами
                            data = Check.GetExamData();
                            grades.Add(new Exam(data.Item1, data.Item2, data.Item3, data.Item4, data.Item5, data.Item6, data.Item7));
                            break;
                        case 2: // Конструктор без параметров
                            grades.Add(new Exam());
                            break;
                        case 3: // Конструктор копирования
                            data = Check.GetExamData();
                            int copies = Check.GetInt(1, 4, "Сколько делать копий? (1-4)");
                            for (int i = 0; i < copies; i++)
                                grades.Add(new Exam(new Exam(data.Item1, data.Item2, data.Item3, data.Item4, data.Item5, data.Item6, data.Item7)));
                            break;
                    }
                    break;
                case 2: // Зачет
                    switch (Check.GetConstructorOption())
                    {
                        case 1: // Конструктор с параметрами
                            data = Check.GetCreditData();
                            grades.Add(new Credit(data.Item1, data.Item2, data.Item3, data.Item4, data.Item5, data.Item6, data.Item7));
                            break;
                        case 2: // Конструктор без параметров
                            grades.Add(new Credit());
                            break;
                        case 3: // Конструктор копирования
                            data = Check.GetCreditData();
                            int copies = Check.GetInt(1, 4, "Сколько делать копий? (1-4)");
                            for (int i = 0; i < copies; i++)
                                grades.Add(new Credit(new Credit(data.Item1, data.Item2, data.Item3, data.Item4, data.Item5, data.Item6, data.Item7)));
                            break;
                    }
                    break;
            }
        }
        public void Edit()
        {
            var grade = Check.GetGrade(grades);
            grades.RemoveAll(c => c == grade);

            if (grade != (object?)null)
            {
                (string, string, string, int, string, string, string) data;
                switch (Check.GetGradeType())
                {
                    case 1: // Экзамен
                        data = Check.GetExamData();
                        grades.Add(new Exam(data.Item1, data.Item2, data.Item3, data.Item4, data.Item5, data.Item6, data.Item7));
                        break;
                    case 2: // Зачет
                        data = Check.GetCreditData();
                        grades.Add(new Credit(data.Item1, data.Item2, data.Item3, data.Item4, data.Item5, data.Item6, data.Item7));
                        break;
                }
            }
        }
        public void Delete()
        {
            var grade = Check.GetGrade(grades);

            if (grade != (object?)null)
            {
                grades.RemoveAll(c => c == grade);
                Console.Clear();
                Console.WriteLine("Оценка удалена!");
            }
        }

        // Перегрузка операторов
        public static Group? operator +(Group group, Grade grade) // a + b
        {
            group.grades.Add(grade);
            return group;
        }
        public static Group? operator ++(Group group) // ++a
        {
            group.grades.Insert(0, Check.OperatorPP()); // Добавляем новый объект в начало списка
            return group;
        }
        public Grade? this[int index] // []
        {
            get
            {
                if (index >= grades.Count || index < 0) return null;
                return grades[index];
            }
            set
            {
                grades[index] = value;
            }
        }
        public static Group? operator <<(Group group, int index)
        {
            if (group?[index] == (object?)null)
            {
                Console.WriteLine("Ошибка: Оценки с таким номером нет!");
                return null;
            }
            group[index]?.Print();
            return group;
        }
    }
}