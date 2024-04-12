#include <iostream>
#include <cstring>
using namespace std;

int main()
{
    int size = 0;
    cout << "N" << endl;
    cin >> size; // вводим размер строки

    char *str = new char[size]; // создаем указатель на строку длинной size
    cin >> str;

    str[strlen(str) - 5] = '\0'; // удаляем 5 последних букв

    cout << str << endl; // выводим

    int m = 0;
    cout << "M" << endl;
    cin >> m; // вводим m

    for (int i = 0; i < m; i++) // создаем цикл
    {
        strcat(str, "*"); // добавляем * к строке
    }

    cout << str << endl; // выводим строку
    free(str);           // освобождаем память
    return 0;
}