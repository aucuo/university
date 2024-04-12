#include <iostream>
#include <iomanip>

using namespace std;

int func(int number)
{
    if (number == 1)
        return 1;
    return number - func(func(number - 1));
}

int main()
{
    cout << "Input n: ";
    int n = 0;
    cin >> n;

    for (int i = 1; i <= n; i++)
        cout << func(i) << " ";
    return 0;
}