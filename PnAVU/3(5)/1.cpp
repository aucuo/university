#include <iostream>
#include <iomanip>
#include <string>
#include <cmath>
#include <vector>

using namespace std;

int main() {

    double x, y, r, x1[10], y1[10];

    for (int i = 0; i < 10; i++)
    {
        cout << "X: ";
        cin >> x1[i];

        cout << "Y: ";
        cin >> y1[i];
    }
    

    cout << "R: ";
    cin >> r;

    for (int i = 0; i < 10; i++)
    {
        x = x1[i];
        y = y1[i];

        if (x == 0 && (x == r || (x <= r && x >= 0))) {
            cout << i+1 << ". " << "True ";
        } else if (x > 0) {
            if ( (x <= 2*r && y <= r) && (x >= 0 && y <= 0) ) {
                cout << i+1 << ". " << "True ";
            } else {
                cout << i+1 << ". " << "False ";
            }
        } else if (x < 0) {
            if (sqrt((x+r)*(x+r) + (y+r)*(y+r)) <= r) {
                cout << i+1 << ". " << "True ";
            } else {
                cout << i+1 << ". " << "False ";
            }
        }
    }
    

    return 0;
}