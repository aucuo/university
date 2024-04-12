#include <iostream>
#include <stdlib.h>
#include <iomanip>
#include <string.h>

using namespace std;

struct T_inf // tenant info
{
    // данные квартир
    char *street;
    int house_num;
    int apart_num;
    int area;
    int rooms;

    // данные жильцов
    char *name;
    char *birth_date;
    char *reg_date;   // дата прописки
    char *disch_date; // дата выписки
    char *rel;        // отношение к владельцу квартиры
};

T_inf *add_tenant(struct T_inf *tenants, int pos)
{
    system("CLS");
    cout << "Size: " << pos << endl;

    if (pos == 0)
    {
        tenants = (struct T_inf *)malloc(sizeof(struct T_inf *)); // выделяем память
    }
    else
    {
        tenants = (struct T_inf *)realloc(tenants, sizeof(struct T_inf *)); // перераспределяем память
    }

    cout << "-- Adding a tenant --" << endl;
    // информация о квартире
    cout << "Street: ";
    tenants[pos].street = new char[20];
    cin >> tenants[pos].street;
    cin.ignore();
    cout << "House number: ";
    cin >> tenants[pos].house_num;
    cout << "Apartment number: ";
    cin >> tenants[pos].apart_num;
    cout << "Apartment area: ";
    cin >> tenants[pos].area;
    cout << "Rooms: ";
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

void get_data(struct T_inf *tenants, int pos)
{
    int count = 0; // количество проживающих в однокомнатных квартирах
    for (int i = 0; i <= pos; i++)
    {
        if (tenants[i].rooms == 1)
        {
            count++;
        }
    }
    cout << "Number of tenants in 1 room apartments: " << count << endl;
}

void output(struct T_inf *tenants, int pos) // вывод в формате списка
{
    for (int i = 0; i < pos; i++)
    {
        cout << " Street: " << tenants[i].street << " House num: " << tenants[i].house_num << " Apart num: " << tenants[i].apart_num << " Area: " << tenants[i].area;
        cout << " Rooms: " << tenants[i].rooms << " Name: " << tenants[i].name << " Birth date: " << tenants[i].birth_date << " Regestration: " << tenants[i].reg_date;
        cout << " Disch date: " << tenants[i].disch_date << " Relations: " << tenants[i].rel;
        cout << endl;
    }
}

void table(struct T_inf *tenants, int pos) // вывод в табличном формате
{
    cout << setw(20) << "Street" << setw(20) << "House num" << setw(20) << "Apart num" << setw(20) << "Area" << setw(20) << "Rooms" << setw(20) << "Name" << setw(20) << "Birth date" << setw(20) << "Reg" << setw(20) << "Disch" << setw(20) << "Rel" << endl;
    for (int i = 0; i < pos; i++)
    {
        cout << setw(20) << tenants[i].street << setw(20) << tenants[i].house_num << setw(20) << tenants[i].apart_num << setw(20) << tenants[i].area << setw(20) << tenants[i].rooms << setw(20) << tenants[i].name << setw(20) << tenants[i].birth_date << setw(20) << tenants[i].reg_date << setw(20) << tenants[i].disch_date << setw(20) << tenants[i].rel;
        cout << endl;
    }
}

int main()
{
    struct T_inf *tenants;

    int n = 0, pos = 0;

    while (n != 5)
    {
        cout << "-- Main menu --\n";
        cout << "To add a tenant enter 1:\n";
        cout << "To get data enter 2:\n";
        cout << "Output 3:\n";
        cout << "Table 4:\n";
        cout << "To exit enter 5:\n";
        cin >> n;

        switch (n)
        {
        case 1:
        {
            system("CLS");
            tenants = add_tenant(tenants, pos);
            pos++;
            break;
        }
        case 2:
        {
            system("CLS");
            get_data(tenants, pos);
            break;
        }
        case 3:
        {
            system("CLS");
            output(tenants, pos);
            break;
        }
        case 4:
        {
            system("CLS");
            table(tenants, pos);
            break;
        }
        }
    }

    free(tenants); // освобождаем память

    return 0;
}
