#include <iostream>
#include <iomanip>
#include <string>
#include <cmath>
#include <vector>

using namespace std;

int main() {

    double x1, x2, dx, x, y;

    cout << "x1: ";
    cin >> x1;    
    cout << "x2: ";
    cin >> x2;    
    cout << "dx: ";
    cin >> dx;

    if ((x1 < x2 && dx > 0) || (x1 > x2 && dx < 0)) {
        cout << setw(10) << "x" << setw(10) << "y(x)" << "\n";
        if (dx > 0) {
            for (double i = x1; i <= x2; i += dx) {
                x = -4 * pow(sin((i-5)/2), 2) * sin(i-5);

                cout << setw(10) << i << setw(10) << x << "\n";
            }
        } else {
            for (double i = x2; i >= x1; i += dx) {
                x = -4 * pow(sin((i-5)/2), 2) * sin(i-5);

                cout << setw(10) << i << setw(10) << x << "\n";
            }
        }
        cout << "\n";
    } else {
        cout << "Input is wrong!";
    }

    return 0;
}