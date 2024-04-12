#include <iostream>
#include <Windows.h>

using namespace std;

HHOOK hook;
bool isVowel = false;

// Функция для проверки, является ли символ гласной буквой
bool isVowelCharacter(char c) {
    c = tolower(c); // Приводим символ к нижнему регистру для удобства проверки
    return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'y');
}

LRESULT CALLBACK KBProc(int nCode, WPARAM wParam, LPARAM lParam) {
    if (nCode >= 0) {
        KBDLLHOOKSTRUCT* KBLLEvent = (KBDLLHOOKSTRUCT*)lParam;
        if (wParam == WM_KEYDOWN) {
            char keyChar = static_cast<char>(KBLLEvent->vkCode);
            if (isalpha(keyChar) && isVowelCharacter(keyChar) && !isVowel) {
                cout << "Vowel intercepted: " << keyChar << endl;
                isVowel = true;
                return 1; // Возвращаем 1, чтобы заблокировать этот символ
            }
        }
        else if (wParam == WM_KEYUP) {
            isVowel = false;
        }
    }
    return CallNextHookEx(hook, nCode, wParam, lParam);
}

int main() {
    hook = SetWindowsHookEx(WH_KEYBOARD_LL, KBProc, NULL, 0);

    MSG msg;
    while (GetMessage(&msg, NULL, 0, 0) > 0) {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }

    UnhookWindowsHookEx(hook);
    return 0;
}
