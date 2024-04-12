#include <iostream>
#include <cstring>
#include <cstdlib>

using namespace std;

int main()
{
    char str[50];

    int pluses = 0, minuses = 0, zero = 0;

    gets(str);

    for (int i = 0; i < 50; i++) {
        if (str[i] == '+') {
            pluses++;

            if (str[i+1] == '0') {
                zero++;
            }
        } else if (str[i] == '-') {
            minuses++;

            if (str[i+1] == '0') {
                zero++;
            }
        }
        
    }

    cout << "Minuses: " << minuses << "\nPluses: " << pluses << "\nZero: " << zero;
    

    return 0;
}