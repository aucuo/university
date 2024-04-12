using System.Text.RegularExpressions;

namespace Lab4
{
    internal class Check
    {
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
        static public string GetPhone(string text)
        {
            string phone;

            Console.WriteLine(text);

            do
                phone = Console.ReadLine();
            while (!Regex.IsMatch(phone, @"^80\d{9}$"));
            return phone;
        }
        static public Department? GetDepartment(List<Department> department)
        {
            string numOrDep;
            int counter = 1;

            if (department.Count == 0) // Проверка на пустоту
            {
                Console.Clear();
                Console.WriteLine("Ошибка: Вы еще не добавили отделы!");
                return null;
            }

            Console.WriteLine("Отдел\tНомер"); // Вывод таблицы с отделами
            foreach (Department dep in department)
            {
                Console.Write(counter++ + ". ");
                dep.Print();
            }

            Console.WriteLine("Введите номер отдела (или напишите название)");
            while (string.IsNullOrEmpty(numOrDep = Console.ReadLine().Trim())) ; // Ввод исключающий пустое значение

            Department? departmentReturn;
            if (!numOrDep.Any(char.IsLetter)) 
                departmentReturn = Convert.ToInt16(numOrDep) - 1 >= 0 && Convert.ToInt16(numOrDep) - 1 < department.Count
                    ? department[Convert.ToInt16(numOrDep) - 1]
                    : null; // Если пользователь ввел ID
            else
                departmentReturn = department.FirstOrDefault(c => c.Name == numOrDep); // Если пользователь ввел название отдела

            Console.Clear();
            if (departmentReturn == null) Console.WriteLine("Ошибка: Такого учебного заведения нет!");

            return departmentReturn;
        }
        static public Worker? GetWorker(List<Worker> workers)
        {
            string numOrDep;
            int counter = 1;

            if (workers.Count == 0) // Проверка на пустоту
            {
                Console.Clear();
                Console.WriteLine("Ошибка: Вы еще не добавляли работников!");
                return null;
            }

            foreach (Worker w in workers)
            {
                Console.Write(counter++ + ". ");
                w.Print();
            }

            Console.WriteLine("Введите порядковый номер работника для редактирования");
            while (string.IsNullOrEmpty(numOrDep = Console.ReadLine().Trim())) ; // Ввод исключающий пустое значение

            Worker? worker;
            worker = Convert.ToInt16(numOrDep) - 1 >= 0 && Convert.ToInt16(numOrDep) - 1 < workers.Count
                    ? workers[Convert.ToInt16(numOrDep) - 1]
                    : null;

            Console.Clear();
            if (worker == null) Console.WriteLine("Ошибка: Такого работника нет!");

            return worker;
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
        static public int GetWorkerType()
        {
            int op;
            Console.WriteLine(
                            "\nВыберите тип добавления:\n" +
                            "1. Сотрудник\n" +
                            "2. Уволенный");
            op = Check.GetInt(1, 2);
            return op;
        }
        static public (string, string, int, string) GetEmployeeData()
        {
            string workerName = Check.GetName("Введите имя и фамилию работника");
            string workerJobTitle = Check.GetName("Введите должность");
            int    salary = Check.GetInt(554, 10000, "Введите зарплату (554 - 10000 BYN)");
            string hireDate = Check.GetDate("Введите дату найма");
            return (workerName, workerJobTitle, salary, hireDate);
        }
        static public (string, string, string, string) GetFiredData()
        {
            string workerName = Check.GetName("Введите имя и фамилию работника");
            string workerJobTitle = Check.GetName("Введите должность");
            string firedReason = Check.GetName("Введите причину увольнения");
            string terminationDate = Check.GetDate("Введите дату увольнения");
            return (workerName, workerJobTitle, firedReason, terminationDate);
        }
    }
}
