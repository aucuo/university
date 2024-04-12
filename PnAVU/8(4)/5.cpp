#include <iostream>
#include <iomanip>

using namespace std;

int func(int numb, int n)
{
    if (!n)
        return 1;
    else if (n == 1)
        return numb;
    else
        return ((2 * n - 1) * func(numb, n - 1) - (n - 1) * func(numb, n - 2)) / n;
}

int main()
{
    cout << "Input n: ";
    int n = 0;
    cin >> n;
    cout << func(1, n);
    return 0;
}