// lab5
#include <fstream>
#include <iostream>
#include <iomanip>
#include <string.h>

using namespace std;

struct F_sch // flight schedule	struct									 
{												  
    int number;								  
    char* type;							 
    char* destination;						 
    double departure_time;								
    double arrival_time;							
}; 

void new_DB(struct F_sch *flights, string path, int c_fl); // создаем новую БД
int load_DB_n(string path); // находим, сколько рейсов записано в БД
struct F_sch *load_DB(string path, int c_fl); // загружаем сами рейсы
void save_DB(struct F_sch *flights, string path, int count, int start); // сохраняем рейсы
void remove_DB(string path);
void clear_DB(struct F_sch *flights, int c_fl);

void add_flight(struct F_sch *flights, int count, int start);
void find_flight(struct F_sch *flights, int counts);
void print_fl(struct F_sch *flights, int counts, int type);

int main() {
    struct F_sch *flights; // создаем указатель на структуру
    string path = "database.txt";

    int c_fl = load_DB_n(path); // кол-во всех рейсов
    flights = load_DB(path, c_fl);

    int n = 0;
    while(n != 6)
    {

        cout << "Чтобы добавить рейс, напишите 1\n";
        cout << "Чтобы найти подходящий рейс, напишите 2\n";
        cout << "Чтобы посмотреть данные о рейсах в виде 'Поле: значение', напишите 3\n";
        cout << "Чтобы посмотреть данные в табличном виде, напишите 4\n";
        cout << "Чтобы удалить БД, напишите 5\n";
        cout << "Чтобы выйти, напишите 6\n";
        cin >> n;

        switch(n)
        {
            case 1:
            {
                system("clear");
                int count = 0;
                cout << "Введите кол-во рейсов: ";
                cin >> count;
                if(!c_fl) flights = (struct F_sch *) malloc(count * sizeof(struct F_sch *)); // выделяем память
                else flights = (struct F_sch *) realloc(flights, (c_fl+count) * sizeof(struct F_sch *)); // выделяем память
                c_fl += count;
                add_flight(flights, count, c_fl-count); // count - сколько добавить, c_fl-count - с какого элемента начать
                break;
            }
            case 2:
            {
                if(!c_fl) cout << "Рейсов нет.\n";
                else find_flight(flights, c_fl);
                break;
            }
            case 3:
            {
                if(!c_fl) cout << "Рейсов нет.\n";
                else print_fl(flights, c_fl, 1);
                break;
            }
            case 4:
            {
                if(!c_fl) cout << "Рейсов нет.\n";
                else print_fl(flights, c_fl, 2);
                break;                
            }
            case 5:
            {
                if(!c_fl) cout << "Рейсов нет.\n";
                else
                { 
                    remove_DB(path);
                    clear_DB(flights, c_fl);
                }
                break;
            }
        }
    }
    // free(flights); // освобождаем память
    clear_DB(flights, c_fl);
    return 0;
}

void add_flight(struct F_sch *flights, int count, int start)
{
    system("clear");

    for (int i = start; i < start+count; i++) // запускаем цикл от последнего элемента до веденного + последнего 
    {
        cout << "-------------------------------" << endl;
        cout << "Номер рейса: " << i+1 << endl; // выставляем номер рейса автоматически
        flights[i].number = i+1; 
        cout << "Тип рейса: "; 
        flights[i].type = new char[20]; // выделяем память под тип
        cin >> flights[i].type;
        cout << "Место назначения: ";
        flights[i].destination = new char[20]; // выделяем память под пункт назначения
        cin >> flights[i].destination;
        cout << "Время отправления: "; 
        while(!(cin >> flights[i].departure_time))
        {
            cout << "Введите правильный формат времени (11.11)!\n";
            cin.clear();
            fflush(stdin);
        }
        cout << "Время прибытия: "; 
        while(!(cin >> flights[i].arrival_time))
        {
            cout << "Введите правильный формат времени (11.11)!\n";
            cin.clear();
            fflush(stdin);
        }
        while(flights[i].departure_time < 0.0 || flights[i].departure_time > 23.59 ||
        flights[i].arrival_time < 0.0 || flights[i].arrival_time > 23.59) // если время ведено неверно, не пропускаем дальше
        {
            system("clear");
            cout << "Номер рейса: " << i+1 << endl; 
            cout << "Тип рейса: " << flights[i].type << endl;
            cout << "Место назначения: " << flights[i].destination << endl;

            if(flights[i].departure_time < 0.0 || flights[i].departure_time > 23.59)
            { 
                cout << "\nНеправильно введено время отправления!" << endl;
                cout << "Время отправления: ";
                cin >> flights[i].departure_time;
                cout << "Время прибытия: "; 
                cin >> flights[i].arrival_time;
            }
            else
            {

                cout << "Время отправления: " << flights[i].departure_time << endl;
                cout << "\nНеправильно введено время прибытия!" << endl;
                cout << "Время прибытия: "; 
                cin >> flights[i].arrival_time;
            }
        }
    }
    system("clear");
    cout << count << " рейсов успешно добавлено.\n"; 
    cout << count+start << " - Всего.\n\n"; 
    // new_DB(flights, count+start);
    save_DB(flights, "database.txt", count, start);
    // return flights; // возвращаем новый массив
}

void find_flight(struct F_sch *flights, int counts)
{
    char f_destination[20];
    double time = 0.0;

    system("clear");
    cout <<"Введите интересующее место назначения: "<<endl;
    cin.get();
    cin.getline(f_destination, 20);
    cout<<"Введите время отправления (Формат: часы.минуты - 12.00): ";
    cin >> time;
    cout<<endl<<"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" <<endl;

    int find = -1;
    for(int i = 0; i < counts; i++)
    {
        cout << flights[i].destination << endl;
        char *str = flights[i].destination; // создаем указатель на пункт назначения
        if(strcmp(f_destination, str) == 0)
        {
            if(flights[i].departure_time <= time) // если время отправления меньше запрашиваемого
            {
                find = 1;
                cout <<"Номер рейса: \t\t" << flights[i].number << endl;
                cout<<"Тип рейса: \t\t" << flights[i].type << endl;
                cout<<"Место назначения: \t" << flights[i].destination << endl;
                cout<<"Время отправления: \t" << setprecision(4) << flights[i].departure_time << endl;
                cout<<"Время прибытия: \t" << setprecision(4) << flights[i].arrival_time << endl;
                cout <<"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
            }
        }

    }
    if(find == -1) cout << "Рейсов не найдено!" << endl;
}

void print_fl(struct F_sch *flights, int counts, int type)
{
    cout <<"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
    if(type == 2) cout << "Название\t\tЗначение\n\n";
    // cout <<"--------------------------------------" << endl;
    for(int i = 0; i < counts; i++)
    {
        cout <<"Номер рейса: ";
        if(type == 2) cout << "\t\t";
        cout << flights[i].number << endl;
        cout<<"Тип рейса: ";
        if(type == 2) cout << "\t\t";
        cout << flights[i].type << endl;
        cout<<"Место назначения: ";
        if(type == 2) cout << "\t";
        cout << flights[i].destination << endl;
        cout<<"Время отправления: ";
        if(type == 2) cout << "\t";
        cout << setprecision(4) << flights[i].departure_time << endl;
        cout<<"Время прибытия: ";
        if(type == 2) cout << "\t";
        cout << setprecision(4) << flights[i].arrival_time << endl;
        cout <<"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
        cout << endl;

    }
}

void clear_DB(struct F_sch *flights, int c_fl)
{
    if(c_fl) free(flights); // очищаем только если что-то есть
}

void remove_DB(string path)
{
    char buf[20];
    strcpy(buf,path.c_str());
    if(!remove(buf)) cout << "БД успешно удалена!\n";
    else cout << "Ошибка с удалением БД!\n";
}

void save_DB(struct F_sch *flights, string path, int count, int start)
{
    ofstream fout(path, ios::app);
    if(fout.is_open())
    {
        // fout.write((char *) &flights, sizeof(F_sch)); // записываем массив
        for (int i = start; i < start+count; i++)
        {
            fout << flights[i].number << " ";
            fout << flights[i].type << " ";
            fout << flights[i].destination << " ";
            fout << flights[i].departure_time << " ";
            fout << flights[i].arrival_time << " ";
            fout << endl;
        }
        
        fout.close();
        cout << "записали новое!\n";
    }
    else cout << "Ошибка открытия файла\n"; 
}

void new_DB(struct F_sch *flights, string path, int c_fl)
{
    ofstream fout(path, ios_base::out|ios_base::trunc);
    if(fout.is_open())
    {
        for (int i = 0; i < c_fl; i++)
        {
            fout << flights[i].number << " ";
            fout << flights[i].type << " ";
            fout << flights[i].destination << " ";
            fout << flights[i].departure_time << " ";
            fout << flights[i].arrival_time << " ";
            fout << endl;
        }
        
        fout.close();
        cout << "Database succesessful created!\n";
    }
    else cout << "Ошибка открытия файла\n";
}

int load_DB_n(string path)
{
    int count = 0;
    ifstream fin(path);
    if(!fin.is_open()) cout << "Ошибка открытия файла\n";
    else
    {
        string currentline;
        while (getline(fin, currentline) != NULL)
        {
            count++;
        }
        fin.close();
    }
    return count;
}

struct F_sch *load_DB(string path, int c_fl)
{
    struct F_sch *flights;
    ifstream fin(path);
    if(fin.is_open())
    {
        flights = (struct F_sch *) malloc(c_fl * sizeof(struct F_sch *));

        for (int i = 0; i < c_fl; i++)
        {
            fin >> flights[i].number;
            flights[i].type = new char[20];
            fin >> flights[i].type;
            flights[i].destination = new char[20];
            fin >> flights[i].destination;
            fin >> flights[i].departure_time;
            fin >> flights[i].arrival_time;
        }

        cout << c_fl << " загружено рейсов из БД" << endl;
        fin.close();
    }
    else cout << "Ошибка открытия файла БД!\n";
    return flights;
}