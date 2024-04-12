#include <iostream>
#include <iomanip>

using namespace std;

int factorial(int number)
{
    if (number == 1)
        return 1;
    return factorial(number - 1) * number;
}

int main()
{
    cout << "Input n: ";
    int n = 0;
    cin >> n;

    for (int i = 1; i <= n; i++)
        cout << factorial(i) << " ";
    return 0;
}