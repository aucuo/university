#include <iostream>
#include <cmath>
#include <iomanip>
using namespace std;
 
double f(double x) {
    return 1.5 * x * exp(x);
}
 
void tabulation(double a, double b, int n) {
    double d = (b - a)/(n - 1);
    cout << setw(10) << "x" << setw(10) << "f(x)" << endl;
    for (double x = a; x <= b || abs(x-b) <= 0.000001; x += d) {
        cout << setw(10) << x << setw(10) << f(x) << endl;
    }
}
 
int main() {
    double a, b;
    int n;
    cout << "a = ";
    cin >> a;
    cout << "b = ";
    cin >> b;
    cout << "n = ";
    cin >> n;
    cout << endl;
    tabulation(a, b, n);
    return 0;
}