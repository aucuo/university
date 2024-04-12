#include <stdio.h>
#include <time.h>
#include <stdlib.h>

void fillArray(int *mas)
{
    for (int i = 0; i < 20; i++)   // цикл по всем элементам массива
        mas[i] = rand() % 21 - 10; // генерируем случайное число
}
// функция выводит на экран содержимое массива
void printArray(int *mas)
{
    printf("{");
    for (int i = 0; i < 20; i++)
        printf("%4i", mas[i]);
    printf("}\n");
}
int calcElems(int *mas)
{
    int cnt1 = 0, cnt2 = 0;      // временная переменная-счетчик отриц и пол.
    for (int i = 0; i < 20; i++) // цикл по всем элементам
    {
        if (mas[i] < 0)
            cnt1++;
        else if (mas[i] > 0)
            cnt2++;
    }
    if (cnt1 > cnt2)
        return 1; // если отриц. больше
    else if (cnt2 > cnt1)
        return 0; // если полож. больше
    else
        return -1;
}
// функция возвращаем указатель на массив, в котором количество элементов меньших
int *searchArray(int *mas1, int *mas2)
{
    int cnt1 = calcElems(mas1), cnt2 = calcElems(mas2);
    if (cnt1 == -1)
        return mas2;
    else if (cnt2 == -1)
        return mas1;
    // else return (;

    if (cnt1 < cnt2)      // сравниваем результаты
        return mas1;      // возвращаем указатель на массив...
    else if (cnt2 > cnt1) // сравниваем результаты
        return mas2;      // возвращаем указатель на массив...
    return 0;
}

// функция обмениваем местами значения ячеек памяти по указателям a и b
void swap(int *a, int *b)
{
    int tmp = *a;
    *a = *b;
    *b = tmp;
}
// функция сортировки массива методом пузырька
void sortArray(int *mas)
{
    for (int i = 0; i < 20; i++)
        for (int j = 0; j < 20; j++)
        {
            if (mas[i] < mas[j])
                swap(&mas[i], &mas[j]);
        }
}
// головная функция
int main()
{
    srand((unsigned)time(NULL)); // инициализация счетчика случайных чисел
    int m1[20], m2[20], m3[20];  // описание трех массивов
    // последовательно заполняем массивы случайными числами и
    // выводим их на экран
    fillArray(m1);
    printf("M1=");
    printArray(m1);
    fillArray(m2);
    printf("M2=");
    printArray(m2);
    fillArray(m3);
    printf("M3=");
    printArray(m3);
    // за два захода выбираем массив удовлетворяющий условию
    int *min = searchArray(m1, m2);
    min = searchArray(min, m3);
    printf("MN=");
    printArray(min); // и выводим его на экран
    sortArray(min);  // сортируем массив
    printf("ST=");
    printArray(min); // и выводим на экран
    return 0;
}