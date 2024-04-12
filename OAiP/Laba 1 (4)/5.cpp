#include <stdio.h>
#include <iostream>

using namespace std;

int main(int argc, char *argv[])
{
    char str[101];

    int slashes = 0, currentSlash = 0;

    printf("Text input: ");
    gets(str);

    for (int i = 0; str[i] != 0; i++) {
        if (str[i] == '\\' || str[i] == '/') {
            slashes++;
        }
    }

    if (slashes == 1) {
        cout << '\\';
        return 0;
    }

    for (int i = 0; str[i] != 0; i++) {
        if (str[i] == '\\' || str[i] == '/') {
            currentSlash++;
        } else if (currentSlash == slashes - 1) {
            cout << str[i];
        }
    }

    // Выполняя задание рассчитываю на путь типа: "D:\Microsoft VS Code\resources\app\extensions\debug-server-ready\media\icon.png"
    
    return 0;
}