#include <iostream>

using namespace std;

int akk(int n, int m)
{
    int a;
    if (n == 0)
        a = m + 1;
    else if (n > 0 && m == 0)
        a = akk(n - 1, 1);
    else
        a = akk(n - 1, akk(n, m - 1));

    return a;
}

int main()
{
    int n, m, y;

    cout << "n, m:\n";
    cin >> n >> m;

    y = akk(n, m);
    cout << "A(" << n << "," << m << ") = " << y << endl;

    return 0;
}

