#include <iostream>
#include <cstring>
#include <cstdlib>

using namespace std;

double powerA3(double a)
{
    double b = a * a * a;

    return b;
}

int main()
{
    double a;

    cout << "Input 5 numbers:\n";

    for (int i = 0; i < 5; i++)
    {
        cin >> a;
        cout << powerA3(a) << "\n";
    }

    return 0;
}