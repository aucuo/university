#include "main.h"
#include "menu.h"

using namespace std;

int main()
{
    T_inf* tenants = new T_inf[10];

    menu(tenants);
    
    system("CLS");
    free(tenants); // освобождаем память

    return 0;
}
