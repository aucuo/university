#include "output.h"
#include "main.h"

void output(struct B_inf* babies, int pos) // вывод в формате списка
{
    if (pos)
    {
        for (int i = 0; i < pos; i++)
        {
            cout << " Mom: " << babies[i].mname << " Doctor: " << babies[i].dname << " Date: " << babies[i].date << " Time: " << babies[i].time;
            cout << " Gender: " << babies[i].gender << " Weight: " << babies[i].weight << " Round: " << babies[i].round << " Expdate: " << babies[i].expdate;
            cout << endl;
        }
    }
    else
        cout << "There are no elements\n";
}

void table(struct B_inf* babies, int pos) // вывод в табличном формате
{
    if (pos)
    {
        cout << setw(15) << " Mom: " << setw(15) << " Doctor: " << setw(15) << " Date: " << setw(15) << " Time: " << setw(15) << " Gender: " << setw(15) << " Weight: " << setw(15) << " Round: " << setw(15) << " Expdate: ";
        cout << endl;
        for (int i = 0; i < pos; i++)
        {
            cout << setw(15) << babies[i].mname << setw(15) << babies[i].dname << setw(15) << babies[i].date << setw(15) << babies[i].time << setw(15) << babies[i].gender << setw(15) << babies[i].weight << setw(15) << babies[i].round << setw(15) << babies[i].expdate;
            cout << endl;
        }
    }
    else
        cout << "There are no elements\n";
}