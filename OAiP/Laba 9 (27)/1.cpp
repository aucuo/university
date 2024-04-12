#include <iostream>
#include <stdlib.h>
#include <iomanip>
#include <string.h>

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

struct Array
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

void table(struct B_inf *babies, int pos) // вывод в табличном формате
{
    if (pos)
    {
        cout << setw(10) << " Mom: " << setw(10) << " Doctor: " << setw(10) << " Date: " << setw(10) << " Time: " << setw(10) << " Gender: " << setw(10) << " Weight: " << setw(10) << " Round: " << setw(10) << " Expdate: ";
        cout << endl;
        for (int i = 0; i < pos; i++)
        {
            cout << setw(10) << babies[i].mname << setw(10) << babies[i].dname << setw(10) << babies[i].date << setw(10) << babies[i].time << setw(10) << babies[i].gender << setw(10) << babies[i].weight << setw(10) << babies[i].round << setw(10) << babies[i].expdate;
            cout << endl;
        }
    }
    else
        cout << "There are no elements\n";
}

Array *sort(struct Array *array, int arr_pos) // сортировка по weight весу ребенка
{
    for (int i = 0; i < arr_pos - 1; i++)
    {
        for (int j = 0; j < arr_pos - 1; j++)
        {
            if (array[j].weight > array[j + 1].weight)
            {
                Array temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;
            }
        }
    }

    return array;
}

void find(struct Array *array, int arr_pos, int weight) // поиск
{
    bool is_found = 0;
    for (int i = 0; i < arr_pos; i++)
    {
        if (array[i].weight == weight) // поиск по весу ребенка
        {
            cout << setw(10) << " Mom: " << setw(10) << " Doctor: " << setw(10) << " Date: " << setw(10) << " Time: " << setw(10) << " Gender: " << setw(10) << " Weight: " << setw(10) << " Round: " << setw(10) << " Expdate: ";
            cout << endl;
            cout << setw(10) << array[i].mname << setw(10) << array[i].dname << setw(10) << array[i].date << setw(10) << array[i].time << setw(10) << array[i].gender << setw(10) << array[i].weight << setw(10) << array[i].round << setw(10) << array[i].expdate;
            cout << endl;
            is_found = 1;
        }
    }

    if (!is_found)
    {
        cout << "We`ve not found babies with the weight " << weight << endl;
    }

    return;
}

int main()
{
    system("CLS");
    struct B_inf *babies = new B_inf[10];

    struct Array *array = new Array[10];

    int n = -1, pos = 0, arr_pos = 0, weight = 0;

    while (n != 0)
    {
        cout << "-- Main menu --\n";
        cout << "1. Add a baby\n";
        cout << "2. Zadanie\n";
        cout << "3. Output\n";
        cout << "4. Table\n";
        cout << "5. Clear\n";
        cout << "6. Load to array\n";
        cout << "7. Print array\n";
        cout << "8. Load from array\n";
        cout << "9. Sort\n";
        cout << "10. Search\n";
        cout << "0. To exit\n";
        cin >> n;

        switch (n)
        {
        case 1:
            system("CLS");
            babies = add_baby(babies, pos);
            pos++;
            break;

        case 2:
            system("CLS");

            cout << "Input weight: ";
            cin >> weight;
            zadanie(babies, pos, weight);
            break;

        case 3:
            system("CLS");
            output(babies, pos);
            break;

        case 4:
            system("CLS");
            table(babies, pos);
            break;

        case 5:
        {
            system("CLS");
            delete[] babies;
            struct B_inf *babies = new B_inf[10];
            pos = 0;
            break;
        }

        case 6:
            system("CLS");
            for (int i = 0; i < pos; i++)
            {
                array[i].mname = babies[i].mname;
                array[i].dname = babies[i].dname;
                array[i].date = babies[i].date;
                array[i].time = babies[i].time;
                array[i].gender = babies[i].gender;
                array[i].weight = babies[i].weight;
                array[i].round = babies[i].round;
                array[i].expdate = babies[i].expdate;
            }
            arr_pos = pos;
            break;

        case 7:
            system("CLS");
            if (!arr_pos)
            {
                cout << "Structure is empty\n";
            }

            cout << "Array table:\n";
            cout << setw(10) << " Mom: " << setw(10) << " Doctor: " << setw(10) << " Date: " << setw(10) << " Time: " << setw(10) << " Gender: " << setw(10) << " Weight: " << setw(10) << " Round: " << setw(10) << " Expdate: ";
            cout << endl;

            for (int i = 0; i < arr_pos; i++)
            {
                cout << setw(10) << array[i].mname << setw(10) << array[i].dname << setw(10) << array[i].date << setw(10) << array[i].time << setw(10) << array[i].gender << setw(10) << array[i].weight << setw(10) << array[i].round << setw(10) << array[i].expdate;
                cout << endl;
            }
            break;

        case 8:
            system("CLS");
            for (int i = 0; i < arr_pos; i++)
            {
                babies[i].mname = array[i].mname;
                babies[i].dname = array[i].dname;
                babies[i].date = array[i].date;
                babies[i].time = array[i].time;
                babies[i].gender = array[i].gender;
                babies[i].weight = array[i].weight;
                babies[i].round = array[i].round;
                babies[i].expdate = array[i].expdate;
            }
            pos = arr_pos;
            break;

        case 9:
            system("CLS");
            sort(array, arr_pos);
            break;

        case 10:
            system("CLS");
            sort(array, arr_pos);
            int weight;
            cout << "Input weight: ";
            cin >> weight;
            system("CLS");
            find(array, arr_pos, weight);
            break;

        case 0:
            break;

        default:
            system("CLS");
            cout << "Check your input\n";
            break;
        }
    }

    system("CLS");
    delete[] babies;
    delete[] array;

    return 0;
}