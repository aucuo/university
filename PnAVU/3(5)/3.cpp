#include <iostream>
#include <conio.h>
#include <math.h>
#include <iomanip>

using namespace std; 

long double fact(double N) 
{ 
    if (N < 0)
    return 0;
    if (N == 0)
    return 1;
    else
    return N * fact(N - 1);
}

int main() { 
    double x, sum, n, xn, xk, dx, eps, i; 

    cout << "Granici otrezka" << endl; 
    do { 
        cout << "X nachalnoe: "; 
        cin >> xn; 
        cout << "X konechnoe: "; 
        cin >> xk; 
        if (xn>xk) cout << "Non correct granitsi" << endl; 
    } while (xn > xk); 

    cout << "Shag dx "; 
    cin >> dx; 
    cout <<"Tochnost e: "; 
    cin >> eps; 

    while (xn <= xk) {
        x = xn, 
        sum = 1,
        n = 1;
        i = 1;

        while ((abs(pow(-x, i)) / fact(i)) > eps) {
            sum += (pow(-x, i)) / fact(i);
            i++;
            n++;
        } 

        cout.precision(5); 
        cout<<setw(10) << "x: " << xn << setw(10) << " f(x): " << sum << setw(40) << " kol-vo chlenov: " << n << endl; 
        xn += dx; 
    } 

    return 0; 
} 
