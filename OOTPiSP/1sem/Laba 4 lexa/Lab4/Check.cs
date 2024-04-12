using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab4
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

        static public int GetInt(string text)
        {
            int n;
            string str;

            Console.WriteLine(text);

            do
                str = Console.ReadLine();
            while (!int.TryParse(str, out n));

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
            int op;
            string[] day = {
                "Понедельник",
                "Вторник",
                "Среда",
                "Четверг",
                "Пятница",
                "Суббота"
            };

            Console.WriteLine(text);
            foreach (string d in day) Console.WriteLine("{0}. {1}", Array.IndexOf(day, d) + 1, d); // Выводим дни

            op = Check.GetInt(1, 6);

            return day[op-1];
        }
        static public string GetGroup()
        {
            string group;
            string pattern = @"^([1-9]|1[0-1])[А-Яа-я]{1,2}$";
            Regex regex = new Regex(pattern);

            do
                group = Console.ReadLine();
            while (!regex.IsMatch(group));

            return group.ToUpper();
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
        static public string GetAddress(string text)
        {
            string addr;

            Console.WriteLine(text);

            do
                addr = Console.ReadLine();
            while (addr.Length < 2 || addr.Length > 30);
            return addr;
        }
        static public string GetTime(string text)
        {
            string time;
            Regex regex = new Regex(@"^\d{1,2}:\d{2}$"); // ЧЧ:ММ

            Console.WriteLine(text);

            do
                time = Console.ReadLine();
            while (!regex.IsMatch(time));
            return time;
        }
        static public Schedule? GetSchedule(List<Schedule> schedules)
        {
            string numOrAddr;

            if (schedules.Count == 0) // Проверка на пустоту
            {
                Console.Clear();
                Console.WriteLine("Ошибка: Вы не добавили учебные заведения!");
                return null;
            }

            Console.WriteLine("Номер\tАдрес"); // Вывод таблицы с заведениями
            foreach (Schedule sch in schedules)
                sch.Print();

            Console.WriteLine("Введите номер учебного заведения (или напишите адрес)");
            while (string.IsNullOrEmpty(numOrAddr = Console.ReadLine().Trim())) ; // Ввод исключающий пустое значение

            Schedule? schedule;
            if (!numOrAddr.Any(char.IsLetter)) 
                schedule = Convert.ToInt16(numOrAddr) - 1 >= 0 && Convert.ToInt16(numOrAddr) - 1 < schedules.Count
                    ? schedules[Convert.ToInt16(numOrAddr) - 1]
                    : null; // Если пользователь ввел ID (т.е. номер заведения)
            else
                schedule = schedules.FirstOrDefault(c => c.Adress == numOrAddr); // Если пользователь ввел адрес

            Console.Clear();
            if (schedule == null) Console.WriteLine("Ошибка: Такого учебного заведения нет!");

            return schedule;
        }
        static public Lesson? GetLesson(List<Lesson> lessons)
        {
            string numOrAddr;
            int counter = 1;

            if (lessons.Count == 0) // Проверка на пустоту
            {
                Console.Clear();
                Console.WriteLine("Ошибка: Вы не добавили уроки");
                return null;
            }

            foreach (Lesson les in lessons)
            {
                Console.Write(counter++ + ". ");
                les.Print();
            }

            Console.WriteLine("Введите номер урока для редактирования");
            while (string.IsNullOrEmpty(numOrAddr = Console.ReadLine().Trim())) ; // Ввод исключающий пустое значение

            Lesson? lesson;
            lesson = Convert.ToInt16(numOrAddr) - 1 >= 0 && Convert.ToInt16(numOrAddr) - 1 < lessons.Count
                    ? lessons[Convert.ToInt16(numOrAddr) - 1]
                    : null; // Если пользователь ввел ID (т.е. номер заведения)

            Console.Clear();
            if (lesson == null) Console.WriteLine("Ошибка: Такого урока нет!");

            return lesson;
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
        static public int GetLessonType()
        {
            int op;
            Console.WriteLine(
                            "\nВыберите тип занятия:\n" +
                            "1. Лабораторная\n" +
                            "2. Лекция");
            op = Check.GetInt(1, 2);
            return op;
        }
        static public (string, string, string, int, string) GetLabData()
        {
            string  lessonName = Check.GetName("Введите название занятия");
            string  lessonDay = Check.GetDate("Введите день");
            string  lessonTime = Check.GetTime("Введите время занятия (чч:мм)");
            int     labNumber = Check.GetInt(1, 20, "Введите номер занятия");
            string  labSupervisor = Check.GetName("Введите имя преподавателя");
            return (lessonName, lessonDay, lessonTime, labNumber, labSupervisor);
        }
        static public (string, string, string, int, string) GetLectureData()
        {
            string lessonName = Check.GetName("Введите название занятия");
            string lessonDay = Check.GetDate("Введите день");
            string lessonTime = Check.GetTime("Введите время занятия (чч:мм)");
            int labRoomNumber = Check.GetInt(1, 999, "Введите номер аудитории");
            string labTopic = Check.GetName("Введите тему занятия");
            return (lessonName, lessonDay, lessonTime, labRoomNumber, labTopic);
        }
    }
}
