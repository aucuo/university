#include <iostream>
#include <stdlib.h>
#include <cstdlib>

using namespace std;

class Dequeue
{ //дек Dequeue
    int data, count_;
    Dequeue *start, *end, *next, *prev;

public:
    Dequeue() : count_(0), start(NULL), end(NULL){}; //Инициализация с помощью конструктора по умолчанию
    void push_front(double);                         // добавление в начало
    void push_back(double);                          // добавление в конец
    void size();                                     // размер дека
    void pop_front();                                // удаление первого
    void pop_back();                                 // удаление последнего
    void front();                                    // печать первого
    void back();                                     // печать последнего
    ~Dequeue();
};

void Dequeue::push_front(double x)
{
    Dequeue *temp = new Dequeue;
    temp->data = x;
    temp->next = NULL;
    count_++;
    if (!start)
    {
        temp->prev = NULL;
        start = temp;
        end = start;
    }
    else
    {
        temp->next = start; //Указываем, что следующим элементом списка относительно добавленного, будет первый элемент существующего списка
        start->prev = temp; //Предыдущий за последним существующим это непосредственно сейчас добавляемый элемент списка
        start = temp;       //После того как указали что есть настоящий и что следующий, объявляем, что первый существующий это только что добавленный элемент
    }
    cout << x << " was pushed at front\n";
}

void Dequeue::push_back(double x)
{
    Dequeue *temp = new Dequeue;
    temp->data = x;
    temp->next = NULL;
    count_++;
    if (!start)
    {
        temp->prev = NULL;
        start = temp;
        end = start;
    }
    else
    {
        temp->prev = end; //Указываем, что предыдущим элементом списка относительно добавленного, будет последний элемент существующего списка
        end->next = temp; //Следующий за последним существующим это непосредственно сейчас добавляемый элемент списка
        end = temp;       //После того как указали что есть настоящий и что предыдущий, объявляем, что последний существующий это только что добавленный элемент
    }
    cout << x << " was pushed at back\n";
}

void Dequeue::size()
{
    cout << "The size of dequeue is " << count_ << endl;
}

void Dequeue::pop_front()
{
    if (!count_)
    {
        cout << "Deck is empty\n";
        return;
    }

    if (start->next)
    { //Если удаляем первый, но есть и другие, то
        Dequeue *temp = start;
        cout << temp->data << " was deleted\n";
        start = start->next;
        start->prev = NULL;
        delete temp;
        count_--;
        return;
    }
    else if (start == end)
    { //Если удаляем первый, но в деке только 1 элемент
        cout << start->data << " was deleted\n";
        start->next = NULL;
        start = NULL;
        delete start; //Удаляем указатель на начало
        count_ = 0;
        return;
    }
}

void Dequeue::pop_back()
{
    if (!count_)
    {
        cout << "Deck is empty\n";
        return;
    }

    if (start != end)
    {
        Dequeue *temp = end;
        cout << temp->data << " was deleted\n";
        end = end->prev; //Отодвигаем хвост назад
        end->next = NULL;
        delete temp; //Очищаем память от бывшего хвоста
        count_--;
        return;
    }
    else
    {
        cout << start->data << " was deleted\n";
        start->next = NULL;
        start = NULL;
        delete start; //Удаляем указатель на начало
        count_ = 0;
        return;
    }
}

void Dequeue::front()
{
    if (count_)
        cout << "Front is " << start->data << endl;
    else
        cout << "Deck is empty\n";
}

void Dequeue::back()
{
    if (count_)
        cout << "Back is " << end->data << endl;
    else
        cout << "Deck is empty\n";
}

Dequeue::~Dequeue()
{
    while (start)
    {
        end = start->next;
        delete start;
        start = end;
    }
}

int main()
{
    system("CLS");
    Dequeue D;

    int n = -1;
    double value;

    while (n != 0)
    {
        cout << "Menu\n";
        cout << "1. Push front\n";
        cout << "2. Push back\n";
        cout << "3. Size\n";
        cout << "4. Pop front\n";
        cout << "5. Pop back\n";
        cout << "6. Print front\n";
        cout << "7. Print back\n";
        cout << "0. Exit\n";

        cin >> n;

        switch (n)
        {
        case 1: // push front
            system("CLS");
            cout << "Value: ";
            cin >> value;
            system("CLS");
            D.push_front(value);
            break;

        case 2: // push back
            system("CLS");
            cout << "Value: ";
            cin >> value;
            system("CLS");
            D.push_back(value);
            break;

        case 3: // size
            system("CLS");
            D.size();
            break;

        case 4: // pop front
            system("CLS");
            D.pop_front();
            break;

        case 5: // pop back
            system("CLS");
            D.pop_back();
            break;

        case 6: // print front
            system("CLS");
            D.front();
            break;

        case 7: // print back
            system("CLS");
            D.back();
            break;

        case 0:
            system("CLS");
            D.~Dequeue();
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