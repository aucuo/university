#include <windows.h>
#include <iostream>
#include <fstream>
#include <string>

int main(int argc, char* argv[])
{
    if (argc < 3) {
        std::cerr << "ukazhi id i put`" << std::endl;
        return -1;
    }

    DWORD processID = std::stoul(argv[1]);
    std::string logFilePath = argv[2];

    // Открытие управляемого процесса
    HANDLE hProcess = OpenProcess(PROCESS_SET_INFORMATION, FALSE, processID);
    if (hProcess == NULL) {
        std::cerr << "cheto s filom ne udalos` " << processID << std::endl;
        return -1;
    }

    // Запись в log-файл
    std::ofstream logFile(logFilePath, std::ios::out | std::ios::app);
    if (!logFile.is_open()) {
        std::cerr << "chet s filom ne udalos` " << logFilePath << std::endl;
        return -1;
    }

    logFile << "upravlaush proc zapushen dlya processa " << processID << std::endl;

    // Изменение приоритета управляемого процесса
    std::cout << "vvedi priority (1-5) ";
    int priority;
    std::cin >> priority;

    if (priority < 1 || priority > 5) {
        std::cerr << "durachek! vvedy verniy" << std::endl;
        return -1;
    }

    DWORD priorities[] = {IDLE_PRIORITY_CLASS, BELOW_NORMAL_PRIORITY_CLASS, NORMAL_PRIORITY_CLASS, ABOVE_NORMAL_PRIORITY_CLASS, HIGH_PRIORITY_CLASS};
    if (!SetPriorityClass(hProcess, priorities[priority - 1])) {
        std::cerr << "cheto poshlo ne tak" << std::endl;
        return -1;
    }

    logFile << "Приоритет процесса изменен на: " << priority << std::endl;
    std::cout << "Пprioritet succesfuly izmenen!" << std::endl;

    // Закрытие дескриптора процесса и log-файла
    CloseHandle(hProcess);
    logFile.close();

    return 0;
}
