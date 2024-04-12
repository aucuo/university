#include "input.h"
#include "main.h"

B_inf* add_baby(struct B_inf* babies, int pos)
{
    system("CLS");
    cout << "Size: " << pos << endl;

    cout << "-- Adding a babie --" << endl;
    cout << "Mother name: ";
    babies[pos].mname = new char[40];
    cin >> babies[pos].mname;
    cout << "Doctor name: ";
    babies[pos].dname = new char[40];
    cin >> babies[pos].dname;
    cout << "Birth date ";
    babies[pos].date = new char[40];
    cin >> babies[pos].date;
    cout << "Birth time: ";
    babies[pos].time = new char[40];
    cin >> babies[pos].time;
    cout << "Gender: ";
    babies[pos].gender = new char[40];
    cin >> babies[pos].gender;
    cout << "Weight: ";
    cin >> babies[pos].weight;
    cout << "Round: ";
    cin >> babies[pos].round;
    cout << "Expire date: ";
    babies[pos].expdate = new char[40];
    cin >> babies[pos].expdate;

    system("CLS");
    cout << babies[pos].mname << " was succesfuly added!\n\n";

    return babies; // возвращаем новый массив
}

B_inf* clear(struct B_inf* babies, int pos)
{
    if (pos)
    {
        free(babies);
        cout << "Structure was cleared\n";
    }
    else
    {
        cout << "Structure is already empty\n";
    }
    return babies;
}