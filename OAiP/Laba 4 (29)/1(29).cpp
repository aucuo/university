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

F_sch *add_flight(struct F_sch *flights, int count, int start)
{
    system("clear");
    flights = (struct F_sch *) malloc((start+count) * sizeof(struct F_sch *)); // выделяем память

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
        cin >> flights[i].departure_time;
        cout << "Время прибытия: "; 
        cin >> flights[i].arrival_time;

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
    return flights; // возвращаем новый массив
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

void print_fl(struct F_sch *flights, int counts, int type);

int main() {
    struct F_sch *flights; // создаем указатель на структуру
    int c_fl = 0; // кол-во всех рейсов
    int n = 0;
    while(n != 5)
    {

        cout << "Чтобы добавить рейс, напишите 1\n";
        cout << "Чтобы найти подходящий рейс, напишите 2\n";
        cout << "Чтобы посмотреть данные о рейсах в виде 'Поле: значение', напишите 3\n";
        cout << "Чтобы посмотреть данные в табличном виде, напишите 4\n";
        cout << "Чтобы выйти, напишите 5\n";
        cin >> n;

        switch(n)
        {
            case 1:
            {
                system("clear");
                int count = 0;
                cout << "Введите кол-во рейсов: ";
                cin >> count;
                c_fl += count;

                flights = add_flight(flights, count, c_fl-count); // count - сколько добавить, c_fl-count - с какого элемента начать
                break;
            }
            case 2:
            {
                find_flight(flights, c_fl);
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
        }
    }
    free(flights); // освобождаем память
    return 0;
}

void print_fl(struct F_sch *flights, int counts, int type)
{
    cout <<"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
    if(type == 2) cout << "Название\t\tЗначение\n\n";
    cout <<"--------------------------------------" << endl;
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