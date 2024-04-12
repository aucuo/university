#include "file.h"
#include "main.h"

void new_DB(struct B_inf* babies, int pos, string path) // создание БД
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

void save_DB(struct B_inf* babies, int pos, string path) // сохранение БД
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

void remove_DB(struct B_inf* babies, int pos, string path) // удаление БД
{
    char buf[50];
    strcpy_s(buf, path.c_str());
    if (!remove(buf))
        cout << "DB was deleted succesfully\n";
    else
        cout << "Something went wrong\n";
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

struct B_inf* load_DB(struct B_inf* babies, string path, int pos)
{
    ifstream fin(path);
    if (fin.is_open())
    {
        babies = (struct B_inf*)malloc(pos * sizeof(struct B_inf*));

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