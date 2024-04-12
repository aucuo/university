#include <iostream>
#include <stdlib.h>
#include <iomanip>
#include <string.h>
#include <string>
#include <cstring>

using namespace std;

struct S_inf // students info
{
    char *name; // имя
    char *sur;  // фамилия
    char *patr; // отчество
    int height;
    int weight;
};

S_inf *add_student(struct S_inf *students, int pos)
{
    system("CLS");

    if (pos == 0)
    {
        students = (struct S_inf *)malloc(sizeof(struct S_inf *)); // выделяем память
    }
    else
    {
        students = (struct S_inf *)realloc(students, sizeof(struct S_inf *)); // перераспределяем память
    }

    cout << "-- Adding a student --" << endl;
    cout << "Name: ";
    students[pos].name = new char[40];
    cin >> students[pos].name;
    cout << "Surname: ";
    students[pos].sur = new char[40];
    cin >> students[pos].sur;
    cout << "Patronymic: "; // отчество
    students[pos].patr = new char[40];
    cin >> students[pos].patr;
    cout << "Height: ";
    cin >> students[pos].height;
    cout << "Weight: ";
    cin >> students[pos].weight;

    system("CLS");
    cout << students[pos].name << " was succesfuly added!\n\n";

    return students; // возвращаем новый массив
}

void get_data(struct S_inf *students, int pos)
{
    int count = 0, temp = 0, h = 0, w = 0;
    for (int i = 0; i < pos - 1; i++) // находим наиболее часто встречающийся рост и вес
    {
        temp = 0;
        for (int j = i; j < pos; j++)
        {
            if (students[i].weight == students[j].weight || students[i].height == students[j].height)
            {
                temp++;
            }
        }
        if (temp >= count)
        {
            count = temp;
            w = students[i].weight;
            h = students[i].height;
        }
    }

    if (count != 1 && pos != 1)
    {
        for (int i = 0; i < pos; i++)
        {
            if (students[i].weight == w || students[i].height == h)
            {
                cout << students[i].name << " " << students[i].sur << " " << students[i].patr << endl;
            }
        }
    }
    else
    {
        cout << students[0].name << " " << students[0].sur << " " << students[0].patr << endl;
    }
}

int main()
{
    struct S_inf *students;

    int n = 0, pos = 0;

    while (n != 3)
    {
        cout << "-- Main menu --\n";
        cout << "To add a student enter 1:\n";
        cout << "To get data enter 2:\n";
        cout << "To exit enter 3:\n";
        cin >> n;

        switch (n)
        {
        case 1:
        {
            system("CLS");
            students = add_student(students, pos);
            pos++;
            break;
        }
        case 2:
        {
            system("CLS");
            get_data(students, pos);
            break;
        }
        }
    }

    free(students); // освобождаем память

    return 0;
}
