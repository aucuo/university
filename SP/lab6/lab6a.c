#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/wait.h>

void mainPrint(int id, int parentId) {
    printf("Процесс №%d с ID %d и ID родителя %d (процесс №%d)\n", id, getpid(), getppid(), parentId);
}

int main() {
    mainPrint(1, 0);
    int pid2 = fork();

    if (pid2 == -1) {
        perror("Ошибка!");
    } else if (pid2 == 0) {
        mainPrint(2, 1);

        int pid3 = fork();
        if (pid3 == -1) {
            perror("Ошибка!");
        } else if (pid3 == 0) {
            mainPrint(3, 2);

            int pid5 = fork();
            if (pid5 == -1) {
                perror("Ошибка!");
            } else if (pid5 == 0) {
                mainPrint(5, 3);
                exit(0);
            } else {
                wait(NULL);
            }
        } else {
            wait(NULL);
            int pid4 = fork();
            if (pid4 == -1) {
                perror("Ошибка!");
            } else if (pid4 == 0) {
                mainPrint(4, 2);

                int pid6 = fork();
                if (pid6 == -1) {
                    perror("Ошибка!");
                } else if (pid6 == 0) {
                    mainPrint(6, 4);

                    int pid7 = fork();
                    if (pid7 == -1) {
                        perror("Ошибка!");
                    } else if (pid7 == 0) {
                        mainPrint(7, 6);
                        exit(0);
                    } else {
                        wait(NULL);
                        printf("Процесс №6 выполняет команду ps\n");
                        execlp("ps", "ps", NULL);
                        exit(0);
                    }
                } else {
                    wait(NULL);
                }
            }
        }
    } else {
        wait(NULL);
    }

    return 0;
}
