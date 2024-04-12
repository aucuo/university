#include <iostream>
#include <iomanip>
#include <string>
#include <cmath>
#include <vector>

using namespace std;

int main() {

    double x, y;

    cout << "X: ";
    cin >> x;

    cout << "Y: ";
    cin >> y;

    if (x >= 2 && ( (y <= -1,5) || (y >= 1) )) {
        cout << "True";
        return 1;
    } else {
        cout << "False";
        return 0;
    }

    return 0;
}