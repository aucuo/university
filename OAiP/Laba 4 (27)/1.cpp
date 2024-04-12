#include <iostream>
#include <stdlib.h>
#include <iomanip>
#include <string.h>
#include <string>
#include <cstring>

using namespace std;

struct B_inf // babies info
{
    char *mname; // имя матери
    char *dname; // имя врача
    char *date;
    char *time;
    char *gender;
    int weight;
    int round;
    char *expdate;
};

B_inf *add_baby(struct B_inf *babies, int pos)
{
    system("CLS");

    if (pos == 0)
    {
        babies = (struct B_inf *)malloc(sizeof(struct B_inf *)); // выделяем память
    }
    else
    {
        babies = (struct B_inf *)realloc(babies, sizeof(struct B_inf *)); // перераспределяем память
    }

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

void zadanie(struct B_inf *babies, int pos, int weight)
{
    int count = 0;
    for (int i = 0; i < pos; i++)
    {
        if (babies[i].weight == weight)
        {
            count++;
        }
    }
    
    if (count == 0)
        cout << "We have no babies with this weight!";
    else if (count == 1)
        cout << "We have " << 1 << " baby with this weight!";
    else
        cout << "We have " << count << " babies with this weight!";
    
    cout << endl;
}

void output(struct B_inf *babies, int pos) // вывод в формате списка
{
    for (int i = 0; i < pos; i++)
    {
        cout << " Mom: " << babies[i].mname << " Doctor: " << babies[i].dname << " Date: " << babies[i].date << " Time: " << babies[i].time;
        cout << " Gender: " << babies[i].gender << " Weight: " << babies[i].weight << " Round: " << babies[i].round << " Expdate: " << babies[i].expdate;
        cout << endl;
    }
}

void table(struct B_inf *babies, int pos) // вывод в табличном формате
{
    cout << setw(20) << " Mom: " << setw(20) << " Doctor: " << setw(20) << " Date: " << setw(20) << " Time: " << setw(20) << " Gender: " << setw(20) << " Weight: " << setw(20) << " Round: " << setw(20) << " Expdate: ";
    for (int i = 0; i < pos; i++)
    {
       cout << setw(20) << babies[i].mname << setw(20) << babies[i].dname << setw(20) << babies[i].date << setw(20) << babies[i].time << setw(20) << babies[i].gender << setw(20) << babies[i].weight << setw(20) << babies[i].round << setw(20) << babies[i].expdate;
       cout << endl;
    }
}

int main()
{
    struct B_inf *babies;

    int n = 0, pos = 0;

    while (n != 5)
    {
        cout << "To add a baby enter 1:\n";
        cout << "To get data enter 2:\n";
        cout << "List 3:\n";
        cout << "Table 4:\n";
        cout << "To exit enter 5:\n";
        cin >> n;

        switch (n)
        {
        case 1:
        {
            system("CLS");
            babies = add_baby(babies, pos);
            pos++;
            break;
        }
        case 2:
        {
            system("CLS");
            cout << "Input weight: ";
            int weight;
            cin >> weight;
            zadanie(babies, pos, weight);
            break;
        }
        case 3:
        {
            system("CLS");
            output(babies, pos);
            break;
        }
        case 4:
        {
            system("CLS");
            table(babies, pos);
            break;
        }
        }
    }

    free(babies); // освобождаем память

    return 0;
}
