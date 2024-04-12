#include <iostream>
#include <iomanip>
#include <string>
#include <cmath>
#include <vector>

using namespace std;

int main() {

    double x, y, r;

    cout << "X: ";
    cin >> x;

    cout << "Y: ";
    cin >> y;

    cout << "R: ";
    cin >> r;

    if ( (x <= 2*r && y <= r) || sqrt((x+r)*(x+r) + (y+r)*(y+r)) <= r ) {
        cout << "True";
        return 1;
    } else {
        cout << "False";
        return 0;
    }

    return 0;
}