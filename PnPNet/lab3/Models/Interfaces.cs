namespace lab3.Models
{
    // ��������� ��� ������� �������
    interface IRepairable
    {
        void PerformRepairs();
    }

    // ��������� ��� ���������� ��������
    interface ICrewManagement
    {
        void AssignCrew(string crewName);
    }

}