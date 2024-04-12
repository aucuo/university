#include <iostream>
#include <stack> // подключаем библиотеку для использования стека
#include <vector>

using namespace std;

int main()
{
    stack<double> stack; // создаем стек 1

    int i = 0, n;
    vector<double> arr;

    cout << "N: ";

    cin >> n; // проверка на дурака
    while (n < 0)
    {
        cin >> n;
    }

    cout << "Input " << n << " numbers " << endl; // предлагаем пользователю ввести n чисел

    double mid = 0; // переменная среднего значения
    for (int i = 1; i <= n; i++)
    {
        double num;
        cin >> num;

        mid += num;      // считаем сумму всех чисел
        stack.push(num); // добавляем введенные числа
        arr.push_back(num);

        if (i == n) // делим сумму всех чисел на количество всех чисел
            mid /= i;
    }

    cout << "Middle: " << mid << endl;

    cout << "First stack:\n"; // первый стек

    while (!stack.empty()) // удаление стека 1
    { 
        cout << stack.top() << " ";
        stack.pop();
    }

    cout << "\nSecond stack:\n"; // второй стек

    for (int i = 0; i < arr.size(); i++)
    {
        if (arr[i] > mid) // проверяем, больше ли среднего значения и пушим в стек
            stack.push(arr[i]);
    }

    while (!stack.empty()) // удаление стека 2
    { 
        cout << stack.top() << " ";
        stack.pop();
    }

    return 0;
}