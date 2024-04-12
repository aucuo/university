using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Lab5
{
    internal class Check
    {
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
        static public int GetInt(int a, int b)
        {
            int n;
            string str;

            do
                str = Console.ReadLine();
            while (!int.TryParse(str, out n) || Convert.ToInt16(str) < a || Convert.ToInt16(str) > b);

            n = Convert.ToInt16(str);

            return n;
        }
        static public int GetInt(int a, int b, string text)
        {
            int n;
            string str;

            Console.WriteLine(text);

            do
                str = Console.ReadLine();
            while (!int.TryParse(str, out n));

            n = Convert.ToInt16(str);

            if (n < a || n > b) GetInt(a, b);

            return n;
        }

        static public string GetDate(string text)
        {
            Console.WriteLine(text);
            string date;

            do
            {
                date = Console.ReadLine();
                if (date == "")
                {
                    date = DateTime.Now.ToString("dd.MM.yyyy");
                    Console.Write(date + "\n");
                }
            } while (!DateTime.TryParse(date, out DateTime dt) || Convert.ToDateTime(date) > DateTime.Now || DateTime.Now.Year - Convert.ToDateTime(date).Year > 11);

            return date;
        }
        static public string GetName(string text)
        {
            string name;

            Console.WriteLine(text);

            do
                name = Console.ReadLine();
            while (name.Any(char.IsDigit) || name.Length < 2 || name.Length > 20);
            return name;
        }
        static public char GetChar()
        {
            string @char;

            do
            {
                @char = Console.ReadLine();
                if (@char == "") return (char)0;
            }
            while (@char.Any(char.IsDigit) || @char.Length != 1);
            return Convert.ToChar(@char);
        }
        static public string GetGroupName(string text)
        {
            string group;
            Regex regex = new Regex(@"^([1-9]|1[0-1])[А-Яа-я]{1,2}$");

            Console.WriteLine(text);

            do
                group = Console.ReadLine();
            while (!regex.IsMatch(group));
            return group.ToUpper();
        }
        static public Group? GetGroup(List<Group> groups)
        {
            Group? group;
            string groupName;

            if (groups.Count == 0) // Проверка на пустоту
            {
                Console.Clear();
                Console.WriteLine("Ошибка: Вы не добавляли классы!");
                return null;
            }

            Console.WriteLine("     \tКласс");
            foreach (Group g in groups)
                g.Print();

            Console.WriteLine("Введите порядковый номер класса (или его название)");
            while (string.IsNullOrEmpty(groupName = Console.ReadLine().Trim())) ; // Ввод исключающий пустое значение

            if (!groupName.Any(char.IsLetter)) 
                group = Convert.ToInt16(groupName) - 1 >= 0 && Convert.ToInt16(groupName) - 1 < groups.Count
                    ? groups[Convert.ToInt16(groupName) - 1]
                    : null; // Если пользователь ввел ID (т.е. номер заведения)
            else
                group = groups.FirstOrDefault(c => c.Name == groupName); // Если пользователь ввел адрес

            Console.Clear();
            if (group == (object?)null) Console.WriteLine("Ошибка: Такого класса нет!");

            return group;
        }
        static public Grade? GetGrade(List<Grade> grades)
        {
            Grade? grade;
            string gradeID;
            int counter = 1;

            if (grades.Count == 0) // Проверка на пустоту
            {
                Console.Clear();
                Console.WriteLine("Ошибка: Вы не добавили оценки");
                return null;
            }

            foreach (Grade g in grades)
            {
                Console.Write(counter++ + ". ");
                g.Print();
            }

            Console.WriteLine("Введите номер оценки");
            while (string.IsNullOrEmpty(gradeID = Console.ReadLine().Trim())) ; // Ввод исключающий пустое значение

            grade = Convert.ToInt16(gradeID) - 1 >= 0 && Convert.ToInt16(gradeID) - 1 < grades.Count
                    ? grades[Convert.ToInt16(gradeID) - 1]
                    : null;

            Console.Clear();
            if (grade == (object?)null) Console.WriteLine("Ошибка: Такой оценки нет!");

            return grade;
        }
        static public int GetConstructorOption()
        {
            int op;
            Console.WriteLine(
                            "\nВыберите тип конструктора:\n" +
                            "1. Конструктор с параметрами\n" +
                            "2. Конструктор без параметров\n" +
                            "3. Конструктор копирования\n");
            op = Check.GetInt(1, 3);
            return op;
        }
        static public int GetGradeType()
        {
            int op;
            Console.WriteLine(
                            "\nВыберите тип оценки:\n" +
                            "1. Экзамен\n" +
                            "2. Зачет");
            op = Check.GetInt(1, 2);
            return op;
        }
        static public string GetCreditType()
        {
            string creditType;
            Console.WriteLine(
                    "\nВыберите тип зачета\n" +
                    "1. Обычный зачет\n" +
                    "2. Диф. зачет");

            if (Check.GetInt(1, 2) == 1) 
                creditType = "Обычный зачет";
            else 
                creditType = "Диф. зачет";

            return creditType;
        }
        static public string GetExamDifficulty()
        {
            string difficulty = "";

            Console.WriteLine(
                    "\nВыберите сложность экзамена\n" +
                    "1. Легкий\n" +
                    "2. Нормальный\n" +
                    "3. Сложный");
            var n = Check.GetInt(1, 3);
            if (n == 1) difficulty = "Легкий";
            if (n == 2) difficulty = "Нормальный";
            if (n == 3) difficulty = "Сложный";

            return difficulty;
        }
        static public string GetExamDuration()
        {
            string duration = "";

            Console.WriteLine(
                    "\nВыберите продолжительность экзамена\n" +
                    "1. 60 мин.\n" +
                    "2. 90 мин.\n" +
                    "3. 120 мин.");
            var n = Check.GetInt(1, 3);
            if (n == 1) duration = "60 мин.";
            if (n == 2) duration = "90 мин.";
            if (n == 3) duration = "120 мин.";

            return duration;
        }
        static public (string, string, string, int, string, string, string) GetExamData()
        {
            string name = Check.GetName("Введите имя ученика");
            string surname = Check.GetName("Введите фамилию ученика");
            string date = Check.GetDate("Введите дату");
            int grade = Check.GetInt(1, 10, "Введите оценку");
            string examName = Check.GetName("Введите предмет экзамена");
            string examDifficulty = Check.GetExamDifficulty();
            string examDuration = Check.GetExamDuration();
            return (name, surname, date, grade, examName, examDifficulty, examDuration);
        }
        static public (string, string, string, int, string, string, string) GetCreditData()
        {
            string name = Check.GetName("Введите имя ученика");
            string surname = Check.GetName("Введите фамилию ученика");
            string date = Check.GetDate("Введите дату");
            int grade = Check.GetInt(1, 10, "Введите оценку");
            string creditName = Check.GetName("Введите предмет зачета");
            string creditStatus = Check.GetCreditType();
            string creditType = (grade > 4) ? "Зачет" : "Незачет";
            return (name, surname, date, grade, creditName, creditStatus, creditType);
        }

        // Для перегрузки операторов
        public static Grade? OperatorP()
        {
            (string, string, string, int, string, string, string) data;
            Grade? grade = null;

            switch (Check.GetGradeType())
            {
                case 1: // Экзамен
                    data = Check.GetExamData();
                    grade = new Exam(data.Item1, data.Item2, data.Item3, data.Item4, data.Item5, data.Item6, data.Item7);
                    break;
                case 2: // Зачет
                    data = Check.GetCreditData();
                    grade = new Credit(data.Item1, data.Item2, data.Item3, data.Item4, data.Item5, data.Item6, data.Item7);
                    break;
            }
            return grade;
        }
        public static Grade? OperatorPP()
        {
            Grade? grade = null;

            switch (Check.GetGradeType())
            {
                case 1: // Экзамен
                    grade = new Exam();
                    break;
                case 2: // Зачет
                    grade = new Credit();
                    break;
            }
            return grade;
        }

        // Для шаблона

        public static MyArray<Credit> CreditTemplate(MyArray<Credit> creditTemplate)
        {
            Console.Clear();
            Console.WriteLine("\n===creditTemplate===");
            Console.WriteLine("1. Добавление");
            Console.WriteLine("2. Просмотр");
            Console.WriteLine("3. Сортировка");
            Console.WriteLine("4. Найти элемент");
            Console.WriteLine("5. Min");
            Console.WriteLine("6. Max");
            Console.WriteLine("0. Выход");

            int n = Check.GetInt(0, 6);
            Console.Clear();

            switch (n)
            {
                case 1: // Добавление
                    (string, string, string, int, string, string, string) data;

                    do
                    {
                        data = Check.GetCreditData();
                        creditTemplate.AddElement(creditTemplate.Length, new Credit(data.Item1, data.Item2, data.Item3, data.Item4, data.Item5, data.Item6, data.Item7));
                        Console.WriteLine("В шаблоне сейчас {0} элемента(-ов)", creditTemplate.Length);
                        n = Check.GetInt(1, 2, "Добавить еще один зачет? (1. да; 2. нет)");
                    } while (n != 2);
                    break;
                case 2: // Просмотр
                    for (int i = 0; i < creditTemplate.Length; i++)
                    {
                        creditTemplate.GetElement(i)?.Print();
                    }
                    Console.WriteLine();
                    break;
                case 3: // Сортировка
                    creditTemplate.Sort();
                    break;
                case 4: // Найти элемент
                    int grade = Check.GetInt(1, 10, "Введите оценку для нахождения (1-10");
                    var cr = new Credit();
                    cr.Mark = grade;

                    var index = creditTemplate.FindItem(cr);
                    Console.Clear();

                    if (index != -1) Console.WriteLine("Найден элемент с индексом: [{0}]", index);
                    else Console.WriteLine("Элемент не найден");
                    break;
                case 5: // Min
                    Console.WriteLine("Наименьшая оценка:" + creditTemplate.Min().Mark);
                    break;
                case 6: // Max
                    Console.WriteLine("Наибольшая оценка:" + creditTemplate.Max().Mark);
                    break;
                case 0:
                    return creditTemplate;
            }
            return creditTemplate;
        }
        public static MyArray<Exam> ExamTemplate(MyArray<Exam> examTemplate)
        {
            Console.Clear();
            Console.WriteLine("\n===examTemplate===");
            Console.WriteLine("1. Добавление");
            Console.WriteLine("2. Просмотр");
            Console.WriteLine("3. Сортировка");
            Console.WriteLine("4. Найти элемент");
            Console.WriteLine("5. Min");
            Console.WriteLine("6. Max");
            Console.WriteLine("0. Выход");

            int n = Check.GetInt(0, 6);
            Console.Clear();

            switch (n)
            {
                case 1: // Добавление
                    (string, string, string, int, string, string, string) data;

                    do
                    {
                        data = Check.GetExamData();
                        examTemplate.AddElement(examTemplate.Length, new Exam(data.Item1, data.Item2, data.Item3, data.Item4, data.Item5, data.Item6, data.Item7));
                        Console.WriteLine("В шаблоне сейчас {0} элемента(-ов)", examTemplate.Length);
                        n = Check.GetInt(1, 2, "Добавить еще один экзамен? (1. да; 2. нет)");
                    } while (n != 2);
                    break;
                case 2: // Просмотр
                    for (int i = 0; i < examTemplate.Length; i++)
                    {
                        examTemplate.GetElement(i)?.Print();
                    }
                    Console.WriteLine();
                    break;
                case 3: // Сортировка
                    examTemplate.Sort();
                    break;
                case 4: // Найти элемент
                    int grade = Check.GetInt(1, 10, "Введите оценку для нахождения (1-10");
                    var ex = new Exam();
                    ex.Mark = grade;

                    var index = examTemplate.FindItem(ex);
                    Console.Clear();

                    if (index != -1) Console.WriteLine("Найден элемент с индексом: [{0}]", index);
                    else Console.WriteLine("Элемент не найден");
                    break;
                case 5: // Min
                    Console.WriteLine("Наименьшая оценка:" + examTemplate.Min().Mark);
                    break;
                case 6: // Max
                    Console.WriteLine("Наибольшая оценка:" + examTemplate.Max().Mark);
                    break;
                case 0:
                    return examTemplate;
            }
            return examTemplate;
        }

        public static MyArray<char> CharTemplate(MyArray<char> charTemplate)
        {
            Console.Clear();
            Console.WriteLine("\n===charTemplate===");
            Console.WriteLine("1. Добавление");
            Console.WriteLine("2. Просмотр");
            Console.WriteLine("3. Сортировка");
            Console.WriteLine("4. Найти элемент");
            Console.WriteLine("5. Min");
            Console.WriteLine("6. Max");
            Console.WriteLine("0. Выход");

            int n = Check.GetInt(0, 6);
            Console.Clear();

            switch (n)
            {
                case 1: // Добавление
                    char charVal;

                    Console.WriteLine("Вводите значения для элементов массива (enter для выхода):");
                    do
                    {
                        charVal = Check.GetChar();
                        if (charVal >= 0)
                            charTemplate.AddElement(charTemplate.Length, charVal);
                    } while (charVal != 0);
                    break;
                case 2: // Просмотр
                    for (int i = 0; i < charTemplate.Length; i++)
                    {
                        Console.Write(charTemplate.GetElement(i) + " ");
                    }
                    Console.WriteLine();
                    break;
                case 3: // Сортировка
                    charTemplate.Sort();
                    break;
                case 4: // Найти элемент
                    Console.WriteLine("Введите значение элемента");
                    charVal = Check.GetChar();
                    var index = charTemplate.FindItem(charVal);
                    if (index != -1) Console.WriteLine("Найден элемент с индексом: [{0}]", index);
                    else Console.WriteLine("Элемент не найден");
                    break;
                case 5: // Min
                    Console.WriteLine(charTemplate.Min());
                    break;
                case 6: // Max
                    Console.WriteLine(charTemplate.Max());
                    break;
                case 0:
                    return charTemplate;
            }
            return charTemplate;
        }
        public static MyArray<int> IntTemplate(MyArray<int> intTemplate)
        {
            Console.Clear();
            Console.WriteLine("\n===intTemplate===");
            Console.WriteLine("1. Добавление");
            Console.WriteLine("2. Просмотр");
            Console.WriteLine("3. Сортировка");
            Console.WriteLine("4. Найти элемент");
            Console.WriteLine("5. Min");
            Console.WriteLine("6. Max");
            Console.WriteLine("0. Выход");

            int n = Check.GetInt(0, 6);
            Console.Clear();

            switch (n)
            {
                case 1: // Добавление
                    int intVal;

                    Console.WriteLine("Вводите значения для элементов массива (-1 для выхода):");
                    do
                    {
                        intVal = Check.GetInt();
                        if (intVal >= 0)
                            intTemplate.AddElement(intTemplate.Length, intVal);
                    } while (intVal != -1);
                    break;
                case 2: // Просмотр
                    for (int i = 0; i < intTemplate.Length; i++)
                    {
                        Console.Write(intTemplate.GetElement(i) + " ");
                    }
                    Console.WriteLine();
                    break;
                case 3: // Сортировка
                    intTemplate.Sort();
                    break;
                case 4: // Найти элемент
                    Console.WriteLine("Введите значение элемента");
                    intVal = Check.GetInt();
                    var index = intTemplate.FindItem(intVal);
                    if (index != -1) Console.WriteLine("Найден элемент с индексом: [{0}]", index);
                    else Console.WriteLine("Элемент не найден");
                    break;
                case 5: // Min
                    Console.WriteLine(intTemplate.Min());
                    break;
                case 6: // Max
                    Console.WriteLine(intTemplate.Max());
                    break;
                case 0:
                    return intTemplate;
            }
            return intTemplate;
        }
    }
}
