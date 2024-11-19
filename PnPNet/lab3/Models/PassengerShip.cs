using Lab3.Models;
using System.Xml.Linq;

namespace lab3.Models
{
    // Класс-наследник "Пассажирский Корабль"
    public class PassengerShip : Ship, IRepairable, ICrewManagement
    {
        // Конструктор по умолчанию
        public PassengerShip() : base() { }

        // Конструктор с параметрами
        public PassengerShip(string name, double displacement, string type, List<string> cabinCategories)
            : base(name, displacement, type, cabinCategories)
        {
        }

        // Реализация абстрактного метода
        public override void DisplayInfo()
        {
            Console.WriteLine($"\n?= Название корабля: {Name}, Водоизмещение: {Displacement} тонн, Тип: {Type} =?\n");
            Console.WriteLine("Категории кают: " + string.Join(", ", CabinCategories));
        }

        // Реализация методов интерфейсов
        public void PerformRepairs()
        {
            Console.WriteLine($"{Name} проходит ремонт.");
        }

        public void AssignCrew(string crewName)
        {
            Console.WriteLine($"Экипаж {crewName} назначен на корабль {Name}.");
        }
    }
}
