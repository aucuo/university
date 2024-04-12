#include <iostream>
#include <stack> // подключаем библиотеку для использования стека
#include <vector>

using namespace std;

int main()
{
    stack<double> stack; // создаем стек

    int i = 0, n;
    vector<double> arr;

    cout << "N: ";

    cin >> n; // проверка на дурака
    while (n < 0)
    {
        cin >> n;
    }

    cout << "Input " << n << " numbers " << endl; // предлагаем пользователю ввести n чисел

    for (int i = 1; i <= n; i++)
    {
        double num;
        cin >> num;

        stack.push(num); // добавляем введенные числа
        arr.push_back(num);
    }

    cout << "First stack:\n"; // первый стек

    while (!stack.empty()) // удаление стека 1
    { 
        cout << stack.top() << " ";
        stack.pop();
    }

    cout << "\nSecond stack:\n"; // второй стек

    for (int i = 0; i < arr.size(); i++)
    {
        if (arr[i] > 0) // проверяем, больше ли среднего значения и пушим в стек
            stack.push(arr[i]);
    }

    while (!stack.empty()) // удаление стека 2
    { 
        cout << stack.top() << " ";
        stack.pop();
    }

    return 0;
}