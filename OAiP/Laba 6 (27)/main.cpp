#include "main.h"
#include "menu.h"

using namespace std;

int main()
{
    B_inf* babies = new B_inf[10];

    menu(babies);
    
    system("CLS");
    free(babies); // освобождаем память

    return 0;
}
