#include <iostream>
#include <cstdlib>
#include <cstring>

using namespace std;

int lowCaseRus(char str1[255]) {\
    int a;
    for (int i = 0; i < strlen(str1); i++) {
        a = str1[i];
        if (a >= -128 && a <= -96) str1[i] += 32;
    }

    cout << str1;

    return 1;
}

int main() {
    char str[255];
    cout << "3 strings input: ";

    cin >> str;
    lowCaseRus(str);
    cin >> str;
    lowCaseRus(str);
    cin >> str;
    lowCaseRus(str);
    return 0;
}