#include <iostream>
#include <cstring>
#include <cstdlib>

using namespace std;

int main()
{
    char str[100];

    cout << "Text input: ";
    gets(str);

    cout << "The result: ";

    for (int i = 0; str[i] != 0; i++) {

        if (str[i] == ',') {
            for (int l = i + 1; str[l] != ','; l++) {
                cout << str[l];
            }

            return 0;
        }
    }

    return 0;
}