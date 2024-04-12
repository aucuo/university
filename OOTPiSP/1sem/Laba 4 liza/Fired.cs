using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Fired : Worker
    {
        private string reason; // причина увольнения
        private string terminationDate; // дата увольнения
        public Fired(string name, string jobTitle, string reason, string terminationDate) : base(name, jobTitle)
        {
            Console.WriteLine("Конструктор Fired с параметрами");
            this.reason = reason;
            this.terminationDate = terminationDate;
        }
        public Fired() : base()
        {
            Console.WriteLine("Конструктор Fired без параметров");
            this.reason = "reason";
            this.terminationDate = "topic";
        }

        public Fired(Fired fired) : base(fired)
        {
            Console.WriteLine("Конструктор Fired копирования");
            this.reason = fired.reason;
            this.terminationDate = fired.terminationDate;
        }
        ~Fired() { Console.WriteLine("Деструктор Fired"); }
        public override void Print()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", "Уволен.", base.name, base.jobTitle, reason, terminationDate);
        }
    }
}