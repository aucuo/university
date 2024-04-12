#include <iostream>
#include <cstring>
using namespace std;

void free(void *ptr);

int main() 
{
    int n = 0;
    cout << "Number of words: " << endl;
    cin >> n; //
    string *a = new string[n]; // создаем указатель на строку
    // a = (string *) malloc(n * sizeof(string *)); // выделяем память

    // Ввод элементов массива 
    for (int i = 0; i < n; i++) 
    {
        string str;
        cin >> str; // вводим строку
        cout << "length -> " << str.length() << endl; // выводим длину
        a[i] = str; // присваиваем значение
    }

    a[0][0] = toupper(a[0][0]); // делаем 1 букву заглавной
    
    for (int i = 0; i < n; i++)
    {
        cout << a[i];
        if(i != n-1) cout << " "; // добавляем пробелы между словами
    }

    cout << ".";
    free(a); // освобождаем память
    return 0;
}