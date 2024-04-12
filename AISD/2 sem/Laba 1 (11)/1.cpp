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
    void Show();
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

/*ПОКАЗЫВАЕТ СПИСОК НА ЭКРАНЕ*/
void MyList::Show()
{
    MyList *t = Head;
    while (t)
    {
        cout << t->x << " ";
        t = t->Next;
    }
    cout << "\n\n";
}

/*ФУНКЦИЯ УДАЛЕНИЯ КОНКРЕТНОГО ЭЛЕМЕНТА ДВУСВЯЗНОГО СПИСКА*/
void MyList::Del(int x)
{
    if ((x == 1) && (Head->Next))
    {                        //Если удаляем первый, но есть и другие, то
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
        Tail = Tail->Prev;   //Отодвигаем хвост назад
        Tail->Next = NULL; 
        delete temp;         //Очищаем память от бывшего хвоста
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

int getRandomNumber(int min, int max)
{
    int num = min + rand() % (max - min + 1);

    return num;
}

int main()
{
    MyList List1, List2;

    int rand[20];

    // Заполнение списка
    for (int i = 0; i < 20; i++)
    {
        rand[i] = getRandomNumber(-50, 50);
    }

    rand[2] = 30;

    for (int i = 0; i < 20; i++)
    {
        List1.Add(rand[i]);
    }

    cout << "List at start: " << endl;
    List1.Show();

    cout << endl;

    // Форматирование списка
    int it2 = 20;

    for (int i = 0; i < 19; i++)
    {
        for (int j = i + 1; j < 20; j++)
        {
            if (rand[i] == rand[j])
            {
                rand[j] = 51;
                it2--;
            }
        }
    }

    for (int i = 0; i < it2; i++)
    {
        if (rand[i] != 51)
        {
            List2.Add(rand[i]);
        }
    }

    cout << "List at end: " << endl;
    List2.Show();

    // Удаление списка
    for (int i = 0; i < 20; i++)
    {
        List1.Del(i);
        List2.Del(i);
    }

    return 0;
}