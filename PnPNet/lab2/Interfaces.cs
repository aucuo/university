namespace lab2
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