using Lab4;

namespace Laba_4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Department> departments = new List<Department>();
            Department? department;
            int n = 1;

            while (n != 0)
            {
                Console.WriteLine("\nВыберите опцию:");
                Console.WriteLine("1. Добавить отдел");
                Console.WriteLine("2. Просмотреть отдел");
                Console.WriteLine("3. Добавить работника");
                Console.WriteLine("4. Редактировать работника");
                Console.WriteLine("5. Удалить работника");
                Console.WriteLine("6. Просмотреть работников");
                Console.WriteLine("0. Выход");

                n = Check.GetInt(0, 6);

                Console.Clear();

                switch (n)
                {
                    case 1: // Добавить отдел
                        var name = Check.GetName("Введите название отдела");

                        if (departments.Any(c => c.Name == name)) // Проверка отдела на уникальность
                        {
                            Console.Clear();
                            Console.WriteLine("Ошибка: Такой отдел уже есть");
                            break;
                        }

                        var phone = Check.GetPhone("Введите номер телефона (напр. 80293208562 - 11 цифр)");

                        departments.Add(new Department(phone, name));
                        break;

                    case 2: // Просмотр отделов
                        if (departments.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Ошибка: Вы еще не добавили отделы!");
                            break;
                        }

                        Console.WriteLine("Название\tНомер");
                         
                        foreach (Department dep in departments)
                            dep.Print();
                        break;

                    case 3: // Добавить работника
                        department = Check.GetDepartment(departments);
                        department?.Add();
                        break;

                    case 4: // Редактировать работника
                        department = Check.GetDepartment(departments);
                        department?.Edit();
                        break;

                    case 5: // Удалить работника
                        department = Check.GetDepartment(departments);
                        department?.Delete();
                        break;

                    case 6: // Просмотреть работников
                        department = Check.GetDepartment(departments);
                        department?.PrintWorkers();
                        break;
                }
            }
        }
    }
}