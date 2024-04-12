#include <iostream>
#include <iomanip>
#include <string>
#include <cmath>
#include <vector>

using namespace std;

int main() {

    double x;

    cout << "X: ";
    cin >> x;

    if (-7 <= x && x <= -3) {
        cout << 3;
    } else if (-3 <= x && x <= 3) {
        cout << 3 - sqrt(9 - x*x);
    } else if (3 < x && x <= 6) {
        cout << 3 - (2 * (x-3));
    } else if (6 <= x && x <= 11) {
        cout << -3 + (x-6);
    }

    return 0;
}