#include "input.h"
#include "main.h"

T_inf* add_tenant(struct T_inf* tenants, int pos)
{
    system("CLS");
    cout << "Size: " << pos << endl;

    cout << "-- Adding a tenant --" << endl;
    // информация о квартире
    cout << "Street: ";
    tenants[pos].street = new char[20];
    cin >> tenants[pos].street;
    cout << "House number: ";
    tenants[pos].house_num = new char[20];
    cin >> tenants[pos].house_num;
    cout << "Apartment number: ";
    tenants[pos].apart_num = new char[20];
    cin >> tenants[pos].apart_num;
    cout << "Apartment area: ";
    tenants[pos].area = new char[20];
    cin >> tenants[pos].area;
    cout << "Rooms: ";
    tenants[pos].rooms = new char[20];
    cin >> tenants[pos].rooms;
    // информация о жителе
    cout << "Name: ";
    tenants[pos].name = new char[20];
    cin >> tenants[pos].name;
    cout << "Date of birth: ";
    tenants[pos].birth_date = new char[20];
    cin >> tenants[pos].birth_date;
    cout << "Regestration date: ";
    tenants[pos].reg_date = new char[20];
    cin >> tenants[pos].reg_date;
    cout << "Discharge date: "; // дата выписки
    tenants[pos].disch_date = new char[20];
    cin >> tenants[pos].disch_date;
    cout << "Relations: "; // отношение к владельцу квартиры
    tenants[pos].rel = new char[20];
    cin >> tenants[pos].rel;

    system("CLS");
    cout << tenants[pos].name << " was succesfuly added!\n\n";

    return tenants; // возвращаем новый массив
}

T_inf* clear(struct T_inf* tenants, int pos)
{
    if (pos)
    {
        memset(tenants, 0, sizeof(T_inf));
        cout << "Structure was cleared\n";
    }
    else
    {
        cout << "Structure is already empty\n";
    }
    return tenants;
}