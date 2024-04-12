#include <iostream>
#include <cstring>
#include <cstdlib>
#include <vector>
#include <math.h>
#include <stdlib.h>

using namespace std;

double max(double x, double y) {
    double max = 0;
    if (x > y) {
        max = x;
    } else {
        max = y;
    }

    return max;
}

int main()
{
    double a, b, c, d;

    cout << "Input A, B, C, D: ";
    cin >> a >> b >> c >> d;

    cout << max(max(a, b), max(c, d));

    return 0;
}