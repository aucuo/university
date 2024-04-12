#include <iostream>
#include <cstring>
#include <cstdlib>

using namespace std;

int main()
{
    char str[50];

    int dogPos = 0;

    bool dogDot = false;

    gets(str);

    // Проверка локальной части и разрешенных символов
    for (int i = 0; i < strlen(str); i++) {

        int s = str[i];

        if ( str[0] == '.' || str[strlen(str)-1] == '.' || (str[i] == '.' && str[i+1] == '.') || (str[i] == '.' && str[i+2] == '.') ) {
            cout << "Non-correct e-mail";
            return 0;
        }
        
        if (!( s >= '0' && s <= '9' || s >= 'A' && s <= 'Z' || s >= 'a' && s <= 'z' || s == '.' || s == '@' || s == '#' || s == '-' || s == '~' || s == '!' || s == '$' || s == '&' || s == '\'' || s == '(' || s == ')' || s == '*' || s == '+' || s == ',' || s == ';' || s == '=' || s == ':')) {
            cout << "Non-correct e-mail";
            return 0;
        }

        // Отлавливаю посицию знака собаки
        if (s == '@' && !dogPos) dogPos = i;
    }

    // Проверка доменной части
    for (int i = dogPos + 1; i < strlen(str); i++) {
        if (str[i] == '@') {
            cout << "Non-correct e-mail";
            return 0;
        }

        if (str[i] == '.') {
            if (dogDot) {
                cout << "Non-correct e-mail";
                return 0;
            }
            dogDot = true;
        }

        if (i == strlen(str) - 1 && !dogDot) {
            cout << "Non-correct e-mail";
            return 0;
        }
    }

    cout << "The e-mail is correct!";

    return 0;
}