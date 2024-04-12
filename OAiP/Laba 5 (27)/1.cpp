#include <iostream>
#include <stdlib.h>
#include <iomanip>
#include <string.h>
#include <string>
#include <cstring>
#include <fstream>

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

void new_DB(struct B_inf *babies, int pos, string path) // создание БД
{
    ofstream fout(path, ios_base::out | ios_base::trunc);

    if (fout.is_open())
    {
        for (int i = 0; i < pos; i++)
        {
            fout << " " << babies[i].mname << " " << babies[i].dname << " " << babies[i].date << " " << babies[i].time << " " << babies[i].gender << " " << babies[i].weight << " " << babies[i].round << " " << babies[i].expdate;
            fout << endl;
        }

        fout.close();
        cout << "Database was created\n";
    }
    else
    {
        cout << "Something went wrong";
    }
}

void save_DB(struct B_inf *babies, int pos, string path) // сохранение БД
{
    ofstream fout(path, ios_base::out | ios_base::trunc);

    if (fout.is_open())
    {
        for (int i = 0; i < pos; i++)
        {
            fout << " " << babies[i].mname << " " << babies[i].dname << " " << babies[i].date << " " << babies[i].time << " " << babies[i].gender << " " << babies[i].weight << " " << babies[i].round << " " << babies[i].expdate;
            fout << endl;
        }

        fout.close();
        cout << "Database was saved\n";
    }
    else
    {
        cout << "Something went wrong\n";
    }
}

void remove_DB(struct B_inf *babies, int pos, string path) // удаление БД
{
    char buf[50];
    strcpy(buf, path.c_str());
    if (!remove(buf))
        cout << "DB was deleted succesfully\n";
    else
        cout << "Something went wrong\n";
}

B_inf *clear(struct B_inf *babies, int pos)
{
    if (pos)
    {
        memset(babies, 0, sizeof(B_inf));
        cout << "Structure was cleared\n";
    }
    else
    {
        cout << "Structure is already empty\n";
    }
    return babies;
}

int DB_length(string path)
{
    int pos = 0;
    ifstream fin(path);
    if (!fin.is_open())
        cout << "File opening error\n";
    else
    {
        string line;
        while (getline(fin, line))
        {
            pos++;
        }
        fin.close();
    }

    return pos;
}

struct B_inf *load_DB(struct B_inf *babies, string path, int pos)
{
    ifstream fin(path);
    if (fin.is_open())
    {
        babies = (struct B_inf *)malloc(pos * sizeof(struct B_inf *));

        for (int i = 0; i < pos; i++)
        {
            babies[i].mname = new char[20];
            fin >> babies[i].mname;
            babies[i].dname = new char[20];
            fin >> babies[i].dname;
            babies[i].date = new char[20];
            fin >> babies[i].date;
            babies[i].time = new char[20];
            fin >> babies[i].time;
            babies[i].gender = new char[20];
            fin >> babies[i].gender;
            fin >> babies[i].weight;
            fin >> babies[i].round;
            babies[i].expdate = new char[20];
            fin >> babies[i].expdate;
        }

        cout << pos << " babies was loaded\n";
        fin.close();
    }
    else
        cout << "DB File opening error\n";

    return babies;
}

int main()
{
    struct B_inf *babies;

    int n = -1, pos = 0;
    string path = "DB.txt";

    while (n != 0)
    {
        cout << "To add a baby enter 1:\n";
        cout << "To get data enter 2:\n";
        cout << "List 3:\n";
        cout << "Table 4:\n";
        cout << "New DB 5:\n";
        cout << "Load DB 6:\n";
        cout << "Save DB 7:\n";
        cout << "Remove DB 8:\n";
        cout << "Clear structure 9:\n";
        cout << "To exit enter 0:\n";
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
        case 5:
        {
            system("CLS");
            new_DB(babies, pos, path);
            break;
        }
        case 6:
        {
            system("CLS");
            babies = clear(babies, pos);
            pos = DB_length(path);
            babies = load_DB(babies, path, pos);
            break;
        }
        case 7:
        {
            system("CLS");
            save_DB(babies, pos, path);
            break;
        }
        case 8:
        {
            system("CLS");
            remove_DB(babies, pos, path);
            break;
        }
        case 9:
        {
            system("CLS");
            babies = clear(babies, pos);
            pos = 0;
            break;
        }
        }
    }

    free(babies); // освобождаем память

    return 0;
}
