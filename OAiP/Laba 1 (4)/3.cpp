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

        cout << str[i];

        if (str[i] == 'a') {
            cout << 'b';
        }
    }

    return 0;
}