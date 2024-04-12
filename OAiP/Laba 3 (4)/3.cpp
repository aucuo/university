#include <iostream>
using namespace std;

int main() 
{
    int *a; // создаем указатель
    int n = 0; // создаем переменную типа int
    cout << "Array size: " << endl;
    cin >> n; // вводим n

    a = (int *) malloc(n * sizeof(int)); // выделяем память для int

    cout << "Array elements input: " << endl; 
    for (int i = 0; i < n; i++) 
        cin >> a[i]; // вводим элементы массива

    cout << "Array elements output: " << endl; 
    for (int i = 0; i < n; i++) 
        cout << a[i] << " "; // выводим элементы массива

    free(a); // освобождаем память
    return 0;
}