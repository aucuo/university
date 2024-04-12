#include "file.h"
#include "main.h"

void new_DB(struct T_inf* tenants, int pos, string path)
{
    ofstream fout(path, ios_base::out | ios_base::trunc);

    if (fout.is_open())
    {
        for (int i = 0; i < pos; i++)
        {
            fout << tenants[i].street << " " << tenants[i].house_num << " " << tenants[i].apart_num << " " << tenants[i].area << " " << tenants[i].rooms << " " << tenants[i].name << " " << tenants[i].birth_date << " " << tenants[i].reg_date << " " << tenants[i].disch_date << " " << tenants[i].rel;
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

void save_DB(struct T_inf* tenants, int pos, string path)
{
    ofstream fout(path, ios_base::out | ios_base::trunc);

    if (fout.is_open())
    {
        for (int i = 0; i < pos; i++)
        {
            fout << tenants[i].street << " " << tenants[i].house_num << " " << tenants[i].apart_num << " " << tenants[i].area << " " << tenants[i].rooms << " " << tenants[i].name << " " << tenants[i].birth_date << " " << tenants[i].reg_date << " " << tenants[i].disch_date << " " << tenants[i].rel;
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

void remove_DB(struct T_inf* tenants, int pos, string path)
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

struct T_inf* load_DB(struct T_inf* tenants, string path, int pos)
{
    ifstream fin(path);
    if (fin.is_open())
    {
        tenants = (struct T_inf*)malloc(pos * sizeof(struct T_inf*));

        for (int i = 0; i < pos; i++)
        {
            tenants[i].street = new char[20];
            fin >> tenants[i].street;
            tenants[i].house_num = new char[20];
            fin >> tenants[i].house_num;
            tenants[i].apart_num = new char[20];
            fin >> tenants[i].apart_num;
            tenants[i].area = new char[20];
            fin >> tenants[i].area;
            tenants[i].rooms = new char[20];
            fin >> tenants[i].rooms;
            tenants[i].name = new char[20];
            fin >> tenants[i].name;
            tenants[i].birth_date = new char[20];
            fin >> tenants[i].birth_date;
            tenants[i].reg_date = new char[20];
            fin >> tenants[i].reg_date;
            tenants[i].disch_date = new char[20];
            fin >> tenants[i].disch_date;
            tenants[i].rel = new char[20];
            fin >> tenants[i].rel;
        }

        cout << pos << " tenants was loaded\n";
        fin.close();
    }
    else
        cout << "DB File opening error\n";

    return tenants;
}