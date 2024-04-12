#include <iostream>
using namespace std;

int main()
{
    int tail = 0, head = 0, num, n;
    int *queue = new int;

    cout << "Enter N: ";
    cin >> n;

    while (!n) // проверка на ввод
    {
        cin >> n;
    }

    for (int i = 0; i < n; i++)
    {
        cout << "Enter " << i + 1 << "st element of queue: ";
        cin >> num;
        queue[tail] = num;
        tail++;
    }

    cout << "\n\nQueue before:\n";
    for (int i = head; i < tail; i++) // вывод очереди до редактирования
    {
        cout << queue[i] << " ";
    }

    queue[head] = num; // удаление первого элемента очереди
    head++;

    queue[tail] = num; // удаление последнего элемента очереди
    tail--;

    cout << "\n\nQueue after:\n";
    for (int i = head; i < tail; i++) // вывод очереди после редактирования
    {
        cout << queue[i] << " ";
    }
}