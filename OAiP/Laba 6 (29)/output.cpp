#include "output.h"
#include "main.h"

void output(struct T_inf* tenants, int pos) // вывод в формате списка
{
    if (pos)
    {
        for (int i = 0; i < pos; i++)
        {
            cout << i + 1 << ". ";
            cout << " Street: " << tenants[i].street << " House: " << tenants[i].house_num << " Apart: " << tenants[i].apart_num << " Area: " << tenants[i].area;
            cout << " Rooms: " << tenants[i].rooms << " Name: " << tenants[i].name << " Birth: " << tenants[i].birth_date << " Reg: " << tenants[i].reg_date;
            cout << " Disch: " << tenants[i].disch_date << " Rel: " << tenants[i].rel;
            cout << endl;
        }
    }
    else
        cout << "There are no elements\n";
}

void table(struct T_inf* tenants, int pos) // вывод в табличном формате
{
    if (pos)
    {
        cout << setw(10) << "Street" << setw(10) << "House" << setw(10) << "Apart" << setw(10) << "Area" << setw(10) << "Rooms" << setw(10) << "Name" << setw(10) << "Birth" << setw(10) << "Reg" << setw(10) << "Disch" << setw(10) << "Rel" << endl;
        for (int i = 0; i < pos; i++)
        {
            cout << setw(10) << tenants[i].street << setw(10) << tenants[i].house_num << setw(10) << tenants[i].apart_num << setw(10) << tenants[i].area << setw(10) << tenants[i].rooms << setw(10) << tenants[i].name << setw(10) << tenants[i].birth_date << setw(10) << tenants[i].reg_date << setw(10) << tenants[i].disch_date << setw(10) << tenants[i].rel;
            cout << endl;
        }
    }
    else
        cout << "There are no elements\n";
}