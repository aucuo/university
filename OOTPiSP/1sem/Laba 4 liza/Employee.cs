using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Employee : Worker
    {
        private int salary; // зарплата
        private string hireDate; // дата найма
        public Employee(string name, string jobTitle, int salary, string hireDate) : base(name, jobTitle)
        {
            Console.WriteLine("Конструктор Employee с параметрами");
            this.salary = salary;
            this.hireDate = hireDate;
        }
        public Employee() : base()
        {
            Console.WriteLine("Конструктор Employee без параметров");
            this.salary = 1;
            this.hireDate = "supervisor";
        }

        public Employee(Employee lab) : base(lab)
        {
            Console.WriteLine("Конструктор Employee копирования");
            this.salary = lab.salary;
            this.hireDate = lab.hireDate;
        }
        ~Employee() { Console.WriteLine("Деструктор Employee"); }
        public override void Print()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", "Сотруд.", base.name, base.jobTitle, salary, hireDate);
        }
    }
}