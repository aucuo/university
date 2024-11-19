using System;
using System.Collections.Generic;

namespace lab2
{

    // Абстрактный класс "Корабль"
    abstract class Ship
    {
        // Поля
        public string Name { get; set; }
        public double Displacement { get; set; }
        public string Type { get; set; }
        public List<string> CabinCategories { get; set; }

        // Конструктор по умолчанию
        public Ship()
        {
            Name = $"Неизвестный корабль";
            Displacement = 0.0;
            Type = "Неизвестный тип";
            CabinCategories = new List<string>();
        }

        // Конструктор с параметрами
        public Ship(string name, double displacement, string type, List<string> cabinCategories)
        {
            Name = name;
            Displacement = displacement;
            Type = type;
            CabinCategories = cabinCategories;
        }

        // Абстрактный метод для вывода информации
        public abstract void DisplayInfo();

        // Виртуальный метод для работы с водоизмещением
        public virtual void UpdateDisplacement(double newDisplacement)
        {
            Displacement = newDisplacement;
            Console.WriteLine($"Водоизмещение корабля обновлено до: {Displacement}");
        }

        // Метод-свойство для получения и установки типа корабля
        public string ShipType
        {
            get { return Type; }
            set { Type = value; }
        }

        // Индексатор для работы с категориями кают
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < CabinCategories.Count)
                    return CabinCategories[index];
                throw new ShipException("Некорректный индекс");
            }
            set
            {
                if (index >= 0 && index < CabinCategories.Count)
                    CabinCategories[index] = value;
                else
                    throw new ShipException("Некорректный индекс");
            }
        }
    }

    // Класс-наследник "Пассажирский Корабль"
    class PassengerShip : Ship, IRepairable, ICrewManagement
    {
        // Конструктор по умолчанию
        public PassengerShip() : base() { }

        // Конструктор с параметрами
        public PassengerShip(string name, double displacement, string type, List<string> cabinCategories)
            : base(name, displacement, type, cabinCategories) { 
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