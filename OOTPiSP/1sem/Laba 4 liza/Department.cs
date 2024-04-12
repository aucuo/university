namespace Lab4
{
    internal class Department
    {
        private string phone;
        private string name;
        public string Name { get { return name; } }
        List<Worker> workers = new List<Worker>();
        public Department(string phone, string name)
        {
            this.phone = phone;
            this.name = name;
        }
        public void Print() { Console.WriteLine("{0}\t{1}", name, phone); } // Вывод отделов
        public void PrintWorkers() { foreach (Worker w in workers) w.Print(); } // Вывод рабочих
        public void Add()
        {
            switch (Check.GetWorkerType())
            {
                case 1: // Employee
                    (string, string, int, string) employeeData;
                    switch (Check.GetConstructorOption())
                    {
                        case 1: // Конструктор с параметрами
                            employeeData = Check.GetEmployeeData();
                            workers.Add(new Employee(employeeData.Item1, employeeData.Item2, employeeData.Item3, employeeData.Item4));
                            break;
                        case 2: // Конструктор без параметров
                            workers.Add(new Employee());
                            break;
                        case 3: // Конструктор копирования
                            employeeData = Check.GetEmployeeData();
                            int copies = Check.GetInt(1, 4, "Сколько делать копий? (1-4)");
                            for (int i = 0; i < copies; i++)
                                workers.Add(new Employee(new Employee(employeeData.Item1, employeeData.Item2, employeeData.Item3, employeeData.Item4)));
                            break;
                    }
                    break;
                case 2: // Fired
                    (string, string, string, string) firedData;
                    switch (Check.GetConstructorOption())
                    {
                        case 1: // Конструктор с параметрами
                            firedData = Check.GetFiredData();
                            workers.Add(new Fired(firedData.Item1, firedData.Item2, firedData.Item3, firedData.Item4));
                            break;
                        case 2: // Конструктор без параметров
                            workers.Add(new Fired());
                            break;
                        case 3: // Конструктор копирования
                            firedData = Check.GetFiredData();
                            int copies = Check.GetInt(1, 4, "Сколько делать копий? (1-4)");
                            for (int i = 0; i < copies; i++)
                                workers.Add(new Fired(new Fired(firedData.Item1, firedData.Item2, firedData.Item3, firedData.Item4)));
                            break;
                    }
                    break;
            }
        }
        public void Edit()
        {
            var worker = Check.GetWorker(workers);
            workers.RemoveAll(c => c == worker);

            if (worker != null)
            {
                switch (Check.GetWorkerType())
                {
                    case 1: // Employee
                        (string, string, int, string) employeeData;
                        employeeData = Check.GetEmployeeData();
                        workers.Add(new Employee(employeeData.Item1, employeeData.Item2, employeeData.Item3, employeeData.Item4));
                        break;
                    case 2: // Fired
                        (string, string, string, string) firedData;
                        firedData = Check.GetFiredData();
                        workers.Add(new Fired(firedData.Item1, firedData.Item2, firedData.Item3, firedData.Item4));
                        break;
                }
            }
        }
        public void Delete()
        {
            var worker = Check.GetWorker(workers);
            workers.RemoveAll(c => c == worker);
            
            if (worker != null)
            {
                Console.Clear();
                Console.WriteLine("Работник удален!");
            }
        }
    }
}
