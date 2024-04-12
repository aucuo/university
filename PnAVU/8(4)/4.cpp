#include <iostream>
#include <iomanip>

using namespace std;

int func(int m, int n)
{
    if (m < n)
        return func(n, m);
    else if (!m)
        return n;
    else if (m > n)
        return func(m - n, n);
    return -1;
}

int main()
{
    cout << "Input m,n: \n";
    int m = 0, n = 0;
    cin >> n >> m;
    cout << func(m, n);
    return 0;
}