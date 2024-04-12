#include <iostream>

using namespace std;

int main() 
{
    double **a; // создаем указатель на указатели
    int *m; // создаем указатель на размеры
    int n = 0;
    cout << "Input number of lines: " << endl; // ввод кол-ва строк
    cin >> n;

    a = (double **) malloc(n * sizeof(double *)); // выделяем память
    m = (int *) malloc(n * sizeof(int)); // выделяем память

    // Ввод элементов массива 
    for (int i = 0; i < n; i++) 
    {
        cout << "Input number of columns for the " << i+1 << " line: "; 
        cin >> m[i]; // вводим элемент массива m
        a[i] = (double *) malloc(m[i] * sizeof(double)); // выделяем память под него
        for (int j = 0; j < m[i]; j++) cin >> a[i][j]; // вводим элемент a[i][j]
    }

    // Вывод элементов массива 
    for (int i = 0; i < n; i++)
    {
        cout << "Line " << i+1 << ": ";
        for (int j = 0; j < m[i]; j++)
        { 
            cout << a[i][j] << " \n"; // выводим элемент a[i][j]
        }
    }

    free(a); // освобождаем память
    free(m);
    return 0;
}