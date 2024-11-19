using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace lab4.Models
{
    // Класс-наследник "Пассажирский Корабль"
    [Serializable]
    public class PassengerShip : Ship, IRepairable, ICrewManagement
    {
        [NonSerialized]
        [JsonIgnore] // Указывает, что поле не должно сериализоваться в JSON
        private DateTime creationDate;

        public string PhotoPath { get; set; }  // Добавлено поле для хранения пути к фотографии

        // Конструктор по умолчанию
        public PassengerShip() : base()
        {
            creationDate = DateTime.Now;
        }

        // Конструктор с параметрами
        public PassengerShip(string name, double displacement, string type, List<string> cabinCategories, string photoPath = "")
            : base(name, displacement, type, cabinCategories)
        {
            creationDate = DateTime.Now;
            PhotoPath = photoPath;
        }

        // Свойство для получения даты создания объекта
        public DateTime CreationDate
        {
            get => creationDate;
            set => creationDate = value;
        }

        // Реализация абстрактного метода
        public override void DisplayInfo()
        {
            Console.WriteLine($"\nНазвание корабля: {Name}, Водоизмещение: {Displacement} тонн, Тип: {Type}, Дата создания: {CreationDate}\n");
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

        // Метод для установки даты создания при десериализации
        [OnDeserialized]
        public void OnDeserializedMethod()
        {
            creationDate = DateTime.Now;
        }
    }
}
