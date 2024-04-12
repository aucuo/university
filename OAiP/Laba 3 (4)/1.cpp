#include <iostream>
#include <cstring>
#include <cstdlib>

using namespace std;

int main()
{
    double *p;

    p = (double *)malloc(1000 * sizeof(int));

    cout << *p;

    free(p);

    return 0;
}