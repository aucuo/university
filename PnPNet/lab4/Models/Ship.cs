using System;
using System.Collections.Generic;

namespace Lab4.Models
{
    // Абстрактный класс "Корабль"
    public abstract class Ship
    {
        public string Name { get; set; }
        public double Displacement { get; set; }
        public string Type { get; set; }
        public List<string> CabinCategories { get; set; }

        public Ship()
        {
            Name = "Неизвестный корабль";
            Displacement = 0.0;
            Type = "Неизвестный тип";
            CabinCategories = new List<string>();
        }

        public Ship(string name, double displacement, string type, List<string> cabinCategories)
        {
            Name = name;
            Displacement = displacement;
            Type = type;
            CabinCategories = cabinCategories;
        }

        public abstract void DisplayInfo();

        public virtual void UpdateDisplacement(double newDisplacement)
        {
            Displacement = newDisplacement;
        }

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < CabinCategories.Count)
                    return CabinCategories[index];
                throw new IndexOutOfRangeException("Некорректный индекс");
            }
            set
            {
                if (index >= 0 && index < CabinCategories.Count)
                    CabinCategories[index] = value;
                else
                    throw new IndexOutOfRangeException("Некорректный индекс");
            }
        }
    }
}
