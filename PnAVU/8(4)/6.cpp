#include <iostream>
#include <iomanip>

using namespace std;

int func(int number)
{
    if (number == 0)
        return 1;
    return func(number / 2) + func(number / 3);
}

int main()
{
    cout << "Input n: ";
    int n = 0;
    cin >> n;

    for (int i = 0; i <= n; i++)
        cout << func(i) << " ";
    return 0;
}