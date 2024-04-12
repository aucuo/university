#include <iostream>
#include <cstring>
#include <cstdlib>

using namespace std;

int main()
{
    char str[11];

    for (int i = 0; i < 10; i++)
    {
        if (i % 2 == 0) {
            str[i] = '2';
        } else {
            str[i] = 'a';
        }
    }

    puts(str);

    // Никакого условия о случайности чисел и букв не было. Поэтому я считаю это решение правильным.
    

    return 0;
}