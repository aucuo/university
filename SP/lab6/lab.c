#include <windows.h>
#include <stdio.h>

void mainPrint(int id, DWORD parentId)
{
    printf("Процесс №%d с ID %d и ID родителя %d (процесс №%d)\n", id, GetCurrentProcessId(), parentId, GetCurrentProcessId());
}

int main()
{
    mainPrint(1, 0);

    STARTUPINFO si;
    PROCESS_INFORMATION pi;

    ZeroMemory(&si, sizeof(si));
    si.cb = sizeof(si);
    ZeroMemory(&pi, sizeof(pi));

    int pid2 = CreateProcess(NULL, "child.exe", NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi);
    if (pid2 == -1)
    {
        perror("Ошибка!");
    }
    else if (pid2 == 0)
    {
        mainPrint(2, 1);

        int pid3 = CreateProcess(NULL, "child.exe", NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi);
        if (pid3 == -1)
        {
            perror("Ошибка!");
        }
        else if (pid3 == 0)
        {
            mainPrint(3, 1);
        }
        else
        {
            int pid6 = CreateProcess(NULL, "child.exe", NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi);
            if (pid6 == -1)
            {
                perror("Ошибка!");
            }
            else if (pid6 == 0)
            {
                mainPrint(6, 3);
            }
        }

        int pid4 = CreateProcess(NULL, "child.exe", NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi);
        if (pid4 == -1)
        {
            perror("Ошибка!");
        }
        else if (pid4 == 0)
        {
            mainPrint(4, 2);

            int pid7 = CreateProcess(NULL, "child.exe", NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi);
            if (pid7 == -1)
            {
                perror("Ошибка!");
            }
            else if (pid7 == 0)
            {
                mainPrint(7, 4);
            }

            printf("Процесс №4 выполняет команду ls\n");
            system("ls");
        }
        else
        {
            int pid5 = CreateProcess(NULL, "child.exe", NULL, NULL, FALSE, 0, NULL, NULL, &si, &pi);
            if (pid5 == -1)
            {
                perror("Ошибка!");
            }
            else if (pid5 == 0)
            {
                mainPrint(5, 2);
            }
        }
    }

    return 0;
}
