#include <windows.h>
#include <iostream>
#include <fstream>

char TransformChar(char ch) {
    switch (ch) {
        case 'A': return 'А';
        case 'B': return 'Б';
        case 'C': return 'С';
        case 'D': return 'Д';
        case 'E': return 'Е';
        case 'F': return 'Ф';
        case 'G': return 'Г';
        case 'H': return 'Х';
        case 'I': return 'И';
        case 'J': return 'Й';
        case 'K': return 'К';
        case 'L': return 'Л';
        case 'M': return 'М';
        case 'N': return 'Н';
        case 'O': return 'О';
        case 'P': return 'П';
        case 'Q': return 'К'; 
        case 'R': return 'Р';
        case 'S': return 'С';
        case 'T': return 'Т';
        case 'U': return 'У';
        case 'V': return 'В';
        case 'W': return 'В'; 
        case 'X': return 'Х';
        case 'Y': return 'Ы';
        case 'Z': return 'З';
        default: return ch;
    }
}


int main() {
    // Открытие файла
    HANDLE hFile = CreateFileW(
        L"example.txt",           // Имя файла
        GENERIC_READ | GENERIC_WRITE, // Доступ на чтение и запись
        0,                       // Нет совместного доступа
        NULL,                    // Без защиты
        OPEN_EXISTING,           // Открыть существующий файл
        FILE_ATTRIBUTE_NORMAL,   // Нормальные атрибуты
        NULL);                   // Без шаблона

    if (hFile == INVALID_HANDLE_VALUE) {
        std::cerr << "oshibka pri otkritii file" << std::endl;
        return 1;
    }

    // Создание объекта File Mapping
    HANDLE hMapFile = CreateFileMapping(
        hFile,
        NULL,
        PAGE_READWRITE,          // Доступ на чтение и запись
        0,
        0,
        NULL);

    if (hMapFile == NULL) {
        std::cerr << "oshibka pri sozdanii faila" << std::endl;
        CloseHandle(hFile);
        return 1;
    }

    // Отображение файла в память
    LPSTR pBuf = (LPSTR) MapViewOfFile(
        hMapFile,
        FILE_MAP_ALL_ACCESS,     // Полный доступ
        0,
        0,
        0);

    if (pBuf == NULL) {
        std::cerr << "oshibka pri otobrazhenii" << std::endl;
        CloseHandle(hMapFile);
        CloseHandle(hFile);
        return 1;
    }

    // Трансформация содержимого файла
    for (size_t i = 0; pBuf[i] != '\0'; ++i) {
        pBuf[i] = TransformChar(pBuf[i]);
    }

    // Освобождение ресурсов
    UnmapViewOfFile(pBuf);
    CloseHandle(hMapFile);
    CloseHandle(hFile);

    std::cout << "soderzhimoe bilo izmeneno" << std::endl;

    return 0;
}
