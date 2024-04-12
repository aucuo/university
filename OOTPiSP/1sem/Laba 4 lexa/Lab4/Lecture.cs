using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Lecture : Lesson
    {
        private int roomNumber; // номер аудитории
        private string topic; // тема
        public Lecture(string name, string day, string time, int roomNumber, string topic) : base(name, day, time)
        {
            Console.WriteLine("Конструктор Lecture с параметрами");
            this.roomNumber = roomNumber;
            this.topic = topic;
        }
        public Lecture() : base()
        {
            Console.WriteLine("Конструктор Lecture без параметров");
            this.roomNumber = 1;
            this.topic = "topic";
        }

        public Lecture(Lecture lecture) : base(lecture)
        {
            Console.WriteLine("Конструктор Lecture копирования");
            this.roomNumber = lecture.roomNumber;
            this.topic = lecture.topic;
        }
        ~Lecture() { Console.WriteLine("Деструктор Lecture"); }
        public override void Print()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", "Лекция", base.name, base.day, base.time, roomNumber, topic);
        }
    }
}