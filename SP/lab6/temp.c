#include <windows.h>
#include <stdio.h>

void mainPrint(int id, DWORD parentId) {
    printf("Процесс №%d с ID %d и ID родителя %d (процесс №%d)\n", id, GetCurrentProcessId(), parentId, GetCurrentProcessId());
}

int main() {
    mainPrint(1, 0);

    STARTUPINFO si;
    PROCESS_INFORMATION pi;

    ZeroMemory(&si, sizeof(si));
    si.cb = sizeof(si);
    ZeroMemory(&pi, sizeof(pi));

    // Процесс 2
    if (CreateProcess(NULL, "child.exe", NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi)) {
        mainPrint(2, GetCurrentProcessId());
        WaitForSingleObject(pi.hProcess, INFINITE);
        CloseHandle(pi.hProcess);
        CloseHandle(pi.hThread);
    } else {
        perror("Ошибка!");
    }

    // Процесс 3
    if (CreateProcess(NULL, "child.exe", NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi)) {
        mainPrint(3, GetCurrentProcessId());
        WaitForSingleObject(pi.hProcess, INFINITE);
        CloseHandle(pi.hProcess);
        CloseHandle(pi.hThread);
    } else {
        perror("Ошибка!");
    }

    return 0;
}
