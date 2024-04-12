#include <iostream>
#include <iomanip>
#include <string>
#include <cmath>
#include <vector>

using namespace std;

int input(int a[100][100], int n)
{
    cout << "n: ";
    cin >> n;

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            cin >> a[i][j];
        }
    }

    return a[100][100], n;
}

void multiply(int a[100][100], int n)
{
    cout << "Multiply: \n";
    int m;
    for (int i = 0; i < n; i++)
    {
        m = 1;
        for (int j = 0; j < n; j++)
        {
            m *= a[i][j];

            if (a[i][j] < 0)
                break;
            else if (j == n - 1)
            {
                cout << "Stroka " << i << " m = " << m << endl;
            }
        }
    }
}

void diag(int a[100][100], int n)
{
    cout << "Diag: \n";
    int *ar = new int[2 * n - 1]{0};

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            ar[i + j] += a[i][n - 1 - j];
        }
    }

    int maxi = 0;
    for (int i = 1; i < n * 2 - 1; i++)
    {
        if (ar[i] > ar[maxi])
            maxi = i;
    }

    cout << "max sum: " << ar[maxi];
}

int main()
{

    int a[100][100], n;

    a, n = input(a, n);

    multiply(a, n);

    diag(a, n);

    return 0;
}