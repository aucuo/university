#include <iostream>
#include <cstring>
#include <string>
#include "Device.h"

using namespace std;

int main()
{
    const int N = 2;

    Device arr[N];

    char title[20];
    char mainHead[20];
    int power;
    for (int i = 0; i < N; i++)
    {
        cout << "Cex nomer " << i + 1 << endl;
        arr[i].Enter();
    }
    cout << endl;
    for (int i = 0; i < N; i++)
        arr[i].print(1);
    system("CLS");
    cout << "Nazvanie\tNachalnik\tKol-vo rabotnikov" << endl;

    for (int i = 0; i < N; i++)
        arr[i].print(2);

    return 0;
}