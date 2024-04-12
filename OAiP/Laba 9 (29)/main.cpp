#include <iostream>
#include <stdlib.h>
#include <iomanip>
#include <string.h>

using namespace std;

struct T_inf // tenant info
{
    // данные квартир
    char *street;
    int house_num;
    int apart_num;
    int area;
    int rooms;

    // данные жильцов
    char *name;
    char *birth_date;
    char *reg_date;   // дата прописки
    char *disch_date; // дата выписки
    char *rel;        // отношение к владельцу квартиры
};

struct Array
{
    // данные квартир
    char *street;
    int house_num;
    int apart_num;
    int area;
    int rooms;

    // данные жильцов
    char *name;
    char *birth_date;
    char *reg_date;   // дата прописки
    char *disch_date; // дата выписки
    char *rel;        // отношение к владельцу квартиры
};

T_inf *add_tenant(struct T_inf *tenants, int pos)
{
    system("CLS");
    cout << "Size: " << pos << endl;

    cout << "-- Adding a tenant --" << endl;
    // информация о квартире
    cout << "Street: ";
    tenants[pos].street = new char[20];
    cin >> tenants[pos].street;
    cin.ignore();
    cout << "House number: ";
    cin >> tenants[pos].house_num;
    cout << "Apartment number: ";
    cin >> tenants[pos].apart_num;
    cout << "Apartment area: ";
    cin >> tenants[pos].area;
    cout << "Rooms: ";
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

void get_data(struct T_inf *tenants, int pos)
{
    if (!pos)
    {
        cout << "Structure is empty\n";
        return;
    }

    int count = 0; // количество проживающих в однокомнатных квартирах
    for (int i = 0; i <= pos; i++)
    {
        if (tenants[i].rooms == 1)
        {
            count++;
        }
    }
    cout << "Number of tenants in 1 room apartments: " << count << endl;
}

void output(struct T_inf *tenants, int pos) // вывод в формате списка
{
    if (!pos)
    {
        cout << "Structure is empty\n";
        return;
    }

    cout << "Structure output:\n";
    for (int i = 0; i < pos; i++)
    {
        cout << i << ". ";
        cout << "Street: " << tenants[i].street << " House num: " << tenants[i].house_num << " Apart num: " << tenants[i].apart_num << " Area: " << tenants[i].area;
        cout << " Rooms: " << tenants[i].rooms << " Name: " << tenants[i].name << " Birth date: " << tenants[i].birth_date << " Regestration: " << tenants[i].reg_date;
        cout << " Disch date: " << tenants[i].disch_date << " Relations: " << tenants[i].rel;
        cout << endl;
    }
}

void table(struct T_inf *tenants, int pos) // вывод в табличном формате
{
    if (!pos)
    {
        cout << "Structure is empty\n";
        return;
    }

    cout << "Structure table:\n";
    cout << setw(15) << "Street" << setw(15) << "House num" << setw(15) << "Apart num" << setw(15) << "Area" << setw(15) << "Rooms" << setw(15) << "Name" << setw(15) << "Birth date" << setw(15) << "Reg" << setw(15) << "Disch" << setw(15) << "Rel" << endl;
    for (int i = 0; i < pos; i++)
    {
        cout << setw(15) << tenants[i].street << setw(15) << tenants[i].house_num << setw(15) << tenants[i].apart_num << setw(15) << tenants[i].area << setw(15) << tenants[i].rooms << setw(15) << tenants[i].name << setw(15) << tenants[i].birth_date << setw(15) << tenants[i].reg_date << setw(15) << tenants[i].disch_date << setw(15) << tenants[i].rel;
        cout << endl;
    }
}

Array *sort(struct Array *array, int arr_pos) // сортировка по house_num
{
    for (int i = 0; i < arr_pos - 1; i++)
    {
        for (int j = 0; j < arr_pos - 1; j++)
        {
            if (array[j].house_num > array[j + 1].house_num)
            {
                Array temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;
            }
        }
    }

    return array;
}

void find(struct Array *array, int arr_pos, int house_num) // поиск
{
    bool is_found = 0;
    for (int i = 0; i < arr_pos; i++)
    {
        if (array[i].house_num == house_num)
        {
            cout << setw(15) << "Street" << setw(15) << "House num" << setw(15) << "Apart num" << setw(15) << "Area" << setw(15) << "Rooms" << setw(15) << "Name" << setw(15) << "Birth date" << setw(15) << "Reg" << setw(15) << "Disch" << setw(15) << "Rel" << endl;
            cout << setw(15) << array[i].street << setw(15) << array[i].house_num << setw(15) << array[i].apart_num << setw(15) << array[i].area << setw(15) << array[i].rooms << setw(15) << array[i].name << setw(15) << array[i].birth_date << setw(15) << array[i].reg_date << setw(15) << array[i].disch_date << setw(15) << array[i].rel;
            cout << endl;
            is_found = 1;
        }
    }

    if (!is_found)
    {
        cout << "We`ve not found " << house_num << endl;
    }

    return;
}

int main()
{
    system("CLS");
    system("Color 09");
    struct T_inf *tenants = new T_inf[10];

    struct Array *array = new Array[10];

    int n = -1, pos = 0, arr_pos = 0;

    while (n != 0)
    {
        cout << "-- Main menu --\n";
        cout << "1. Add a tenant\n";
        cout << "2. Get data\n";
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
            tenants = add_tenant(tenants, pos);
            pos++;
            break;

        case 2:
            system("CLS");
            get_data(tenants, pos);
            break;

        case 3:
            system("CLS");
            output(tenants, pos);
            break;

        case 4:
            system("CLS");
            table(tenants, pos);
            break;

        case 5:
        {
            system("CLS");
            delete[] tenants;
            struct T_inf *tenants = new T_inf[10];
            pos = 0;
            break;
        }

        case 6:
            system("CLS");
            for (int i = 0; i < pos; i++)
            {
                array[i].street = tenants[i].street;
                array[i].house_num = tenants[i].house_num;
                array[i].apart_num = tenants[i].apart_num;
                array[i].area = tenants[i].area;
                array[i].rooms = tenants[i].rooms;
                array[i].name = tenants[i].name;
                array[i].birth_date = tenants[i].birth_date;
                array[i].reg_date = tenants[i].reg_date;
                array[i].disch_date = tenants[i].disch_date;
                array[i].rel = tenants[i].rel;
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
            cout << setw(15) << "Street" << setw(15) << "House num" << setw(15) << "Apart num" << setw(15) << "Area" << setw(15) << "Rooms" << setw(15) << "Name" << setw(15) << "Birth date" << setw(15) << "Reg" << setw(15) << "Disch" << setw(15) << "Rel" << endl;
            for (int i = 0; i < arr_pos; i++)
            {
                cout << setw(15) << array[i].street << setw(15) << array[i].house_num << setw(15) << array[i].apart_num << setw(15) << array[i].area << setw(15) << array[i].rooms << setw(15) << array[i].name << setw(15) << array[i].birth_date << setw(15) << array[i].reg_date << setw(15) << array[i].disch_date << setw(15) << array[i].rel;
                cout << endl;
            }
            break;

        case 8:
            system("CLS");
            for (int i = 0; i < arr_pos; i++)
            {
                tenants[i].street = array[i].street;
                tenants[i].house_num = array[i].house_num;
                tenants[i].apart_num = array[i].apart_num;
                tenants[i].area = array[i].area;
                tenants[i].rooms = array[i].rooms;
                tenants[i].name = array[i].name;
                tenants[i].birth_date = array[i].birth_date;
                tenants[i].reg_date = array[i].reg_date;
                tenants[i].disch_date = array[i].disch_date;
                tenants[i].rel = array[i].rel;
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
            int house_num;
            cout << "Input house number: ";
            cin >> house_num;
            system("CLS");
            find(array, arr_pos, house_num);
            break;

        case 0:
            break;

        default:
            system("CLS");
            cout << "Check your input\n";
            break;
        }
    }

    system("Color 07");
    system("CLS");
    delete[] tenants;
    delete[] array;

    return 0;
}