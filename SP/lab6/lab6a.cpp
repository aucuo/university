#include <windows.h>
#include <iostream>

void mainPrint(int id, DWORD parentId) {
    std::cout << "Процесс №" << id << " с ID " << GetCurrentProcessId() 
              << " и ID родителя " << parentId << " (процесс №" << GetCurrentProcessId() << ")\n";
}

int main() {
    mainPrint(1, 0);

    STARTUPINFO si;
    PROCESS_INFORMATION pi;

    ZeroMemory(&si, sizeof(si));
    si.cb = sizeof(si);
    ZeroMemory(&pi, sizeof(pi));

    if (!CreateProcess(nullptr, L"child.exe", nullptr, nullptr, FALSE, 0, nullptr, nullptr, &si, &pi)) {
        std::cerr << "Ошибка!\n";
    } else {
        mainPrint(2, 1);

        if (!CreateProcess(nullptr, L"child.exe", nullptr, nullptr, FALSE, 0, nullptr, nullptr, &si, &pi)) {
            std::cerr << "Ошибка!\n";
        } else {
            mainPrint(3, 1);

            if (!CreateProcess(nullptr, L"child.exe", nullptr, nullptr, FALSE, 0, nullptr, nullptr, &si, &pi)) {
                std::cerr << "Ошибка!\n";
            } else {
                mainPrint(6, 3);
            }
        }

        if (!CreateProcess(nullptr, L"child.exe", nullptr, nullptr, FALSE, 0, nullptr, nullptr, &si, &pi)) {
            std::cerr << "Ошибка!\n";
        } else {
            mainPrint(4, 2);

            if (!CreateProcess(nullptr, L"child.exe", nullptr, nullptr, FALSE, 0, nullptr, nullptr, &si, &pi)) {
                std::cerr << "Ошибка!\n";
            } else {
                mainPrint(7, 4);
            }

            std::cout << "Процесс №4 выполняет команду ls\n";
            system("ls");
        }

        if (!CreateProcess(nullptr, "child.exe", nullptr, nullptr, FALSE, 0, nullptr, nullptr, &si, &pi)) {
            std::cerr << "Ошибка!\n";
        } else {
            mainPrint(5, 2);
        }
    }

    return 0;
}
