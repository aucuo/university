using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Schedule
    {
        private int number;
        private string address;
        public string Adress { get { return address; } }
        List<Lesson> lessons = new List<Lesson>();
        public Schedule(int number, string adress)
        {
            this.number = number;
            this.address = adress;
        }
        public void Print() { Console.WriteLine("{0}\t{1}", number, address); } // Вывод расписания
        public void PrintLessons() { foreach (Lesson les in lessons) les.Print(); } // Вывод уроков
        public void Add()
        {
            (string, string, string, int, string) data;
            switch (Check.GetLessonType())
            {
                case 1: // Лабораторная
                    switch (Check.GetConstructorOption())
                    {
                        case 1: // Конструктор с параметрами
                            data = Check.GetLabData();
                            lessons.Add(new Lab(data.Item1, data.Item2, data.Item3, data.Item4, data.Item5));
                            break;
                        case 2: // Конструктор без параметров
                            lessons.Add(new Lab());
                            break;
                        case 3: // Конструктор копирования
                            data = Check.GetLabData();
                            int copies = Check.GetInt(1, 4, "Сколько делать копий? (1-4)");
                            for (int i = 0; i < copies; i++)
                                lessons.Add(new Lab(new Lab(data.Item1, data.Item2, data.Item3, data.Item4, data.Item5)));
                            break;
                    }
                    break;
                case 2: // Лекция
                    switch (Check.GetConstructorOption())
                    {
                        case 1: // Конструктор с параметрами
                            data = Check.GetLectureData();
                            lessons.Add(new Lecture(data.Item1, data.Item2, data.Item3, data.Item4, data.Item5));
                            break;
                        case 2: // Конструктор без параметров
                            lessons.Add(new Lecture());
                            break;
                        case 3: // Конструктор копирования
                            data = Check.GetLectureData();
                            int copies = Check.GetInt(1, 4, "Сколько делать копий? (1-4)");
                            for (int i = 0; i < copies; i++)
                                lessons.Add(new Lecture(new Lecture(data.Item1, data.Item2, data.Item3, data.Item4, data.Item5)));
                            break;
                    }
                    break;
            }
        }
        public void Edit()
        {
            var lesson = Check.GetLesson(lessons);
            lessons.RemoveAll(c => c == lesson);

            if (lesson != null)
            {
                (string, string, string, int, string) data;
                switch (Check.GetLessonType())
                {
                    case 1: // Лабораторная
                        data = Check.GetLabData();
                        lessons.Add(new Lab(data.Item1, data.Item2, data.Item3, data.Item4, data.Item5));
                        break;
                    case 2: // Лекция
                        data = Check.GetLectureData();
                        lessons.Add(new Lecture(data.Item1, data.Item2, data.Item3, data.Item4, data.Item5));
                        break;
                }
            }
        }
        public void Delete()
        {
            var lesson = Check.GetLesson(lessons);
            lessons.RemoveAll(c => c == lesson);
            
            if (lesson != null)
            {
                Console.Clear();
                Console.WriteLine("Урок удален!");
            }
        }
    }
}
