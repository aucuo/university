using System;
using System.Collections.Generic;

namespace lab2
{

    // ����������� ����� "�������"
    abstract class Ship
    {
        // ����
        public string Name { get; set; }
        public double Displacement { get; set; }
        public string Type { get; set; }
        public List<string> CabinCategories { get; set; }

        // ����������� �� ���������
        public Ship()
        {
            Name = $"����������� �������";
            Displacement = 0.0;
            Type = "����������� ���";
            CabinCategories = new List<string>();
        }

        // ����������� � �����������
        public Ship(string name, double displacement, string type, List<string> cabinCategories)
        {
            Name = name;
            Displacement = displacement;
            Type = type;
            CabinCategories = cabinCategories;
        }

        // ����������� ����� ��� ������ ����������
        public abstract void DisplayInfo();

        // ����������� ����� ��� ������ � ��������������
        public virtual void UpdateDisplacement(double newDisplacement)
        {
            Displacement = newDisplacement;
            Console.WriteLine($"������������� ������� ��������� ��: {Displacement}");
        }

        // �����-�������� ��� ��������� � ��������� ���� �������
        public string ShipType
        {
            get { return Type; }
            set { Type = value; }
        }

        // ���������� ��� ������ � ����������� ����
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < CabinCategories.Count)
                    return CabinCategories[index];
                throw new ShipException("������������ ������");
            }
            set
            {
                if (index >= 0 && index < CabinCategories.Count)
                    CabinCategories[index] = value;
                else
                    throw new ShipException("������������ ������");
            }
        }
    }

    // �����-��������� "������������ �������"
    class PassengerShip : Ship, IRepairable, ICrewManagement
    {
        // ����������� �� ���������
        public PassengerShip() : base() { }

        // ����������� � �����������
        public PassengerShip(string name, double displacement, string type, List<string> cabinCategories)
            : base(name, displacement, type, cabinCategories) { 
        }

        // ���������� ������������ ������
        public override void DisplayInfo()
        {
            Console.WriteLine($"\n?= �������� �������: {Name}, �������������: {Displacement} ����, ���: {Type} =?\n");
            Console.WriteLine("��������� ����: " + string.Join(", ", CabinCategories));
        }

        // ���������� ������� �����������
        public void PerformRepairs()
        {
            Console.WriteLine($"{Name} �������� ������.");
        }

        public void AssignCrew(string crewName)
        {
            Console.WriteLine($"������ {crewName} �������� �� ������� {Name}.");
        }
    }
}