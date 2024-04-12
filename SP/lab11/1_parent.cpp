#include <windows.h>
#include <iostream>
#include <fstream>

int main()
{
    // Создание файла для протоколирования
    std::ofstream logFile("log.txt", std::ios::out | std::ios::app);
    logFile << "Родительский процесс начал работу." << std::endl;

    // Создание управляемого процесса (например, Notepad)
    STARTUPINFO siManaged;
    PROCESS_INFORMATION piManaged;
    ZeroMemory(&siManaged, sizeof(siManaged));
    siManaged.cb = sizeof(siManaged);
    ZeroMemory(&piManaged, sizeof(piManaged));

    if (!CreateProcess(TEXT("C:\\Windows\\System32\\notepad.exe"),   // Путь к исполняемому файлу
        NULL,           // Командная строка
        NULL,           // Атрибуты защиты процесса
        NULL,           // Атрибуты защиты потока
        FALSE,          // Наследование дескрипторов
        0,              // Флаги создания
        NULL,           // Использование родительского окружения
        NULL,           // Использование родительского каталога
        &siManaged,     // Указатель на STARTUPINFO
        &piManaged))    // Указатель на PROCESS_INFORMATION
    {
        std::cerr << "Не удалось создать управляемый процесс." << std::endl;
        return -1;
    }

    // Создание управляющего процесса (для примера, также Notepad)
    STARTUPINFO siControl;
    PROCESS_INFORMATION piControl;
    ZeroMemory(&siControl, sizeof(siControl));
    siControl.cb = sizeof(siControl);
    ZeroMemory(&piControl, sizeof(piControl));

    if (!CreateProcess(TEXT("C:\\Windows\\System32\\notepad.exe"),   // Путь к исполняемому файлу
        NULL,           // Командная строка
        NULL,           // Атрибуты защиты процесса
        NULL,           // Атрибуты защиты потока
        FALSE,          // Наследование дескрипторов
        0,              // Флаги создания
        NULL,           // Использование родительского окружения
        NULL,           // Использование родительского каталога
        &siControl,     // Указатель на STARTUPINFO
        &piControl))    // Указатель на PROCESS_INFORMATION
    {
        std::cerr << "Не удалось создать управляющий процесс." << std::endl;
        return -1;
    }

    // Ожидание завершения дочерних процессов
    WaitForSingleObject(piManaged.hProcess, INFINITE);
    WaitForSingleObject(piControl.hProcess, INFINITE);

    // Запись в log-файл
    logFile << "Дочерние процессы завершили работу." << std::endl;

    // Закрытие дескрипторов
    CloseHandle(piManaged.hProcess);
    CloseHandle(piManaged.hThread);
    CloseHandle(piControl.hProcess);
    CloseHandle(piControl.hThread);

    logFile << "Родительский процесс завершил работу." << std::endl;
    logFile.close();

    return 0;
}
