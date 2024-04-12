#include <iostream>
#include <iomanip>
#include <fstream>
#include <string.h>
#include <string>

using namespace std;

struct T_inf // tenant info
{
    // данные квартир
    char* street;
    char* house_num;
    char* apart_num;
    char* area;
    char* rooms;

    // данные жильцов
    char* name;
    char* birth_date;
    char* reg_date;   // дата прописки
    char* disch_date; // дата выписки
    char* rel;        // отношение к владельцу квартиры
};

T_inf* add_tenant(struct T_inf* tenants, int pos)
{
    system("CLS");
    cout << "Size: " << pos << endl;

    if (pos == 0)
    {
        tenants = (struct T_inf*)malloc(sizeof(struct T_inf*)); // выделяем память
    }
    else
    {
        tenants = (struct T_inf*)realloc(tenants, sizeof(struct T_inf*)); // перераспределяем память
    }

    cout << "-- Adding a tenant --" << endl;
    // информация о квартире
    cout << "Street: ";
    tenants[pos].street = new char[20];
    cin >> tenants[pos].street;
    cout << "House number: ";
    tenants[pos].house_num = new char[20];
    cin >> tenants[pos].house_num;
    cout << "Apartment number: ";
    tenants[pos].apart_num = new char[20];
    cin >> tenants[pos].apart_num;
    cout << "Apartment area: ";
    tenants[pos].area = new char[20];
    cin >> tenants[pos].area;
    cout << "Rooms: ";
    tenants[pos].rooms = new char[20];
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
    strcpy(buf, path.c_str());
    if (!remove(buf))
        cout << "DB was deleted succesfully\n";
    else
        cout << "Something went wrong\n";
}

T_inf* clear(struct T_inf* tenants, int pos)
{
    if (pos)
    {
        memset(tenants, 0, sizeof(T_inf));
        cout << "Structure was cleared\n";
    }
    else
    {
        cout << "Structure is already empty\n";
    }
    return tenants;
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

int main()
{
    struct T_inf* tenants;
    string path = "DB.txt";

    int n = -1, pos = 0;

    while (n != 0)
    {
        // cout << "-- Main menu --\n";
        cout << "Input 1:\n";
        cout << "Output 2:\n";
        cout << "Table 3:\n";
        cout << "New DB 4:\n";
        cout << "Load DB 5:\n";
        cout << "Save DB 6:\n";
        cout << "Remove DB 7:\n";
        cout << "Clear structure 8:\n";
        cout << "To exit enter 0:\n";
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
            output(tenants, pos);
            break;
        }
        case 3:
        {
            system("CLS");
            table(tenants, pos);
            break;
        }
        case 4:
        {
            system("CLS");
            new_DB(tenants, pos, path);
            break;
        }
        case 5:
        {
            system("CLS");
            tenants = clear(tenants, pos);
            pos = DB_length(path);
            tenants = load_DB(tenants, path, pos);
            break;
        }
        case 6:
        {
            system("CLS");
            save_DB(tenants, pos, path);
            break;
        }
        case 7:
        {
            system("CLS");
            remove_DB(tenants, pos, path);
            break;
        }
        case 8:
        {
            system("CLS");
            tenants = clear(tenants, pos);
            pos = 0;
            break;
        }
        }
    }

    system("CLS");
    free(tenants); // освобождаем память

    return 0;
}
