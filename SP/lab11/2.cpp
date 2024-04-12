#include <windows.h>
#include <iostream>
#include <string>

int main()
{
    HANDLE hFile = CreateFile(
        "example.txt",        // Имя файла
        GENERIC_READ,          // Доступ на чтение
        0,                     // Нет совместного доступа
        NULL,                  // Без защиты
        OPEN_EXISTING,         // Открыть существующий файл
        FILE_ATTRIBUTE_NORMAL, // Нормальные атрибуты
        NULL);                 // Без шаблона

    if (hFile == INVALID_HANDLE_VALUE)
    {
        std::cerr << "Error while opening" << std::endl;
        return 1;
    }

    std::cout << "Descriptor: " << hFile << std::endl;

    HANDLE hMapFile = CreateFileMapping(
        hFile,         // Дескриптор файла
        NULL,          // Безопасность по умолчанию
        PAGE_READONLY, // Доступ на чтение
        0,             // Максимальный размер объекта (высокий DWORD)
        0,             // Максимальный размер объекта (низкий DWORD)
        NULL);         // Имя отображения файла

    if (hMapFile == NULL)
    {
        std::cerr << "Error while showing" << std::endl;
        CloseHandle(hFile);
        return 1;
    }

    LPCSTR pBuf = (LPCSTR)MapViewOfFile(
        hMapFile,      // Дескриптор отображения файла
        FILE_MAP_READ, // Доступ на чтение
        0,             // Смещение (высокий DWORD)
        0,             // Смещение (низкий DWORD)
        0);            // Отображать весь файл

    if (pBuf == NULL)
    {
        std::cerr << "Error while showing in memory" << std::endl;
        CloseHandle(hMapFile);
        CloseHandle(hFile);
        return 1;
    }

    std::cout << "Basic adress of file: " << static_cast<const void *>(pBuf) << std::endl;

    int countLatin = 0, countRussian = 0;
    for (size_t i = 0; pBuf[i] != '\0'; ++i)
    {
        if ((pBuf[i] >= 'A' && pBuf[i] <= 'Z') || (pBuf[i] >= 'a' && pBuf[i] <= 'z'))
        {
            ++countLatin;
        }
        if ((unsigned char)pBuf[i] >= 192 && (unsigned char)pBuf[i] <= 255)
        {
            ++countRussian;
        }
    }

    std::cout << "LAT letters: " << countLatin << std::endl;
    std::cout << "RUS letters: " << countRussian << std::endl;

    UnmapViewOfFile(pBuf);
    CloseHandle(hMapFile);
    CloseHandle(hFile);

    return 0;
}
