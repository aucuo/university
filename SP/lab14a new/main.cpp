#include <windows.h>
#include <iostream>

// Прототип функции фильтра хука
LRESULT CALLBACK CallWndProc(int nCode, WPARAM wParam, LPARAM lParam) {
    if (nCode >= 0) {
        // Обработайте сообщение или выполните действие
        std::cout << "hook perehvatil" << std::endl;
        
    }

    // Передача управления следующему хуку в цепочке
    return CallNextHookEx(NULL, nCode, wParam, lParam);
}

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow) {
    // Установка хука
    HHOOK hHook = SetWindowsHookEx(WH_CALLWNDPROC, CallWndProc, hInstance, 0);
    
    if (hHook == NULL) {
        // Обработка ошибки
    }

    // Запуск цикла сообщений
    MSG msg;
    while (GetMessage(&msg, NULL, 0, 0)) {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }

    // Снятие хука перед выходом
    UnhookWindowsHookEx(hHook);

    return msg.wParam;
}
