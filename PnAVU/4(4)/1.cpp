#include <iostream>
#include <iomanip>
#include <string>
#include <cmath>
#include <vector>

using namespace std;

int main()
{

    int n;

    cout << "n: ";
    cin >> n;

    vector<int> arr(n);
    int num;

    for (int i = 0; i < n; i++)
    {

        cin >> num;

        arr[i] = num;
    }

    int sum = 0;
    for (int i = 1; i < n; i += 2)
    {
        sum += arr[i];
    }
    cout << "Not even sum: " << sum << endl;

    sum = 0;
    int minusStart, minusEnd;
    for (int i = 0; i < n; i++)
    {
        if (arr[i] < 0)
        {
            minusStart = i;
            break;
        }
    }

    for (int i = n - 1; i >= 0; i--)
    {
        if (arr[i] < 0)
        {
            minusEnd = i;
            break;
        }
    }

    for (int i = minusStart; i <= minusEnd; i++)
    {
        sum += arr[i];
    }

    cout << "Second sum: " << sum;

    return 0;
}