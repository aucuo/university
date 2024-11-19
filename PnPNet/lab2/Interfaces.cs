namespace lab2
{
    // Интерфейс для ремонта корабля
    interface IRepairable
    {
        void PerformRepairs();
    }

    // Интерфейс для управления экипажем
    interface ICrewManagement
    {
        void AssignCrew(string crewName);
    }

}