#include <iostream>
#include <stdlib.h>
#include <cstdlib>
#include <time.h>
#include <list>
#include <iostream>

using namespace std;

class MyList
{ //Список MyList
    int x, count_;
    MyList *Head, *Tail, *Next, *Prev;

public:
    MyList() : count_(0), Head(NULL), Tail(NULL){}; //Инициализация с помощью конструктора по умолчанию
    void Add(int);
    void Add_Start(int);
    int Add_After(int, int);
    void Show();
    int Replace(int, int);
    void Del(int); //Функция принимает целочисленный параметр, обозначающий номер удаляемого элемента
    ~MyList();
};

/*ДОБАВЛЕНИЕ ЭЛЕМЕНТА В СПИСОК*/
void MyList::Add(int x)
{
    MyList *temp = new MyList;
    temp->x = x;
    temp->Next = NULL;
    count_++;
    if (!Head)
    {
        temp->Prev = NULL;
        Head = temp;
        Tail = Head;
    }
    else
    {
        temp->Prev = Tail; //Указываем, что предыдущим элементом списка относительно добавленного, будет последний элемент существующего списка
        Tail->Next = temp; //Следующий за последним существующим это непосредственно сейчас добавляемый элемент списка
        Tail = temp;       //После того как указали что есть настоящий и что предыдущий, объявляем, что последний существующий это только что добавленный элемент
    }
}

void MyList::Add_Start(int x)
{
    MyList *temp = new MyList;
    temp->x = x;
    temp->Next = NULL;
    count_++;
    if (!Head)
    {
        temp->Prev = NULL;
        Head = temp;
        Tail = Head;
    }
    else
    {
        temp->Next = Head; //Указываем, что следующим элементом списка относительно добавленного, будет первый элемент существующего списка
        Head->Prev = temp; //Предыдущий за последним существующим это непосредственно сейчас добавляемый элемент списка
        Head = temp;       //После того как указали что есть настоящий и что следующий, объявляем, что первый существующий это только что добавленный элемент
    }
}

int MyList::Add_After(int x, int elem)
{
    MyList *t = Head;
    while (t)
    {
        if (t->x == elem)
        {
            MyList *temp = new MyList;
            temp->x = x;
            temp->Next = NULL;
            count_++;

            temp->Next = t->Next;
            temp->Prev = t;

            t->Next = temp;
            t = t->Next;
            t->Prev = temp;

            cout << x << " was added\n";
            return 1;
        }
        t = t->Next;
    }
    cout << "Something went wrong\n";
    return 0;
}

/*ПОКАЗЫВАЕТ СПИСОК НА ЭКРАНЕ*/
void MyList::Show()
{
    MyList *t = Head;

    if (t)
    {
        while (t)
        {
            cout << t->x << " ";
            t = t->Next;
        }
        cout << "\n";
    }
    else
        cout << "List is empty\n";
}

int MyList::Replace(int k, int g)
{
    if (k > count_ - 1 || g > count_ - 1) // проверка на дурака
    {
        cout << "Non correct input\n";
        return 0;
    }

    MyList *pk = Head;
    MyList *pg = Head;

    for (int i = 0; i < k; i++)
    {
        pk = pk->Next;
    }

    for (int i = 0; i < g; i++)
    {
        pg = pg->Next;
    }

    int temp;
    temp = pk->x;
    pk->x = pg->x;
    pg->x = temp;

    cout << "Elements were replaced\n";
    return 1;
}

/*ФУНКЦИЯ УДАЛЕНИЯ КОНКРЕТНОГО ЭЛЕМЕНТА ДВУСВЯЗНОГО СПИСКА*/
void MyList::Del(int x)
{
    if ((x == 1) && (Head->Next))
    { //Если удаляем первый, но есть и другие, то
        MyList *temp = Head;
        Head = Head->Next;
        Head->Prev = NULL;
        delete temp;
        count_--;
        return;
    }
    else if ((x == 1) && (Head == Tail))
    { //Если удаляем первый, но в списке только 1 элемент

        Head->Next = NULL;
        Head = NULL;
        delete Head; //Удаляем указатель на начало
        count_ = 0;
        return;
    }

    // удаляемый элемент является последним элементом списка
    if (x == count_)
    {
        MyList *temp = Tail;
        Tail = Tail->Prev; //Отодвигаем хвост назад
        Tail->Next = NULL;
        delete temp; //Очищаем память от бывшего хвоста
        count_--;
        return;
    }

    //Если же удаляемый элемент лежит где-то в середине списка, то тогда его можно удалить

    MyList *temp = Head, *temp2; // temp-Удаляемый элемент, temp2 нужен, чтобы не потерять данные

    for (int i = 0; i < x - 1; i++)
        temp = temp->Next;

    temp2 = temp;
    temp2->Prev->Next = temp->Next;
    temp2->Next->Prev = temp->Prev;
    delete temp;
    count_--;
}

MyList::~MyList()
{
    while (Head)
    {
        Tail = Head->Next;
        delete Head;
        Head = Tail;
    }
}

int main()
{
    system("CLS");
    MyList List;

    int n = -1, value, element, number, k, g;

    while (n != 0)
    {
        cout << "Menu\n";
        cout << "1. Add element\n";
        cout << "2. Add element to start\n";
        cout << "3. Add element after\n";
        cout << "4. Show list\n";
        cout << "5. Replace\n";
        cout << "6. Delete element\n";
        cout << "7. Clear list\n";
        cout << "0. Exit\n";

        cin >> n;

        switch (n)
        {
        case 1: // добавить элемент в конец
            system("CLS");
            cout << "Value: ";
            cin >> value;
            system("CLS");
            List.Add(value);
            break;

        case 2: // добавить элемент в начало
            system("CLS");
            cout << "Value: ";
            cin >> value;
            List.Add_Start(value);
            break;

        case 3: // добавить элемент после элемента
            system("CLS");
            cout << "Value: ";
            cin >> value;
            cout << "Element: ";
            cin >> element;
            List.Add_After(value, element);
            break;

        case 4: // показать список
            system("CLS");
            List.Show();
            break;

        case 5:
            system("CLS");
            cout << "K position: ";
            cin >> k;
            cout << "G position: ";
            cin >> g;
            system("CLS");
            List.Replace(k, g);
            break;

        case 6: // удалить элемент
            system("CLS");
            cout << "Number: ";
            cin >> number;
            system("CLS");
            List.Del(number);
            cout << number << " was deleted\n";
            break;

        case 7: // очистить список
            system("CLS");
            List.~MyList();
            cout << "List was cleared\n";
            break;

        case 0:
            system("CLS");
            return 0;
            break;

        default:
            system("CLS");
            cout << "Check your input\n";
            break;
        }
    }

    return 0;
}